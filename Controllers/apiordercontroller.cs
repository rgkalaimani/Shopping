using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Viewmodel = ShoppingApplication.Models.Viewmodel;
using DBLayer;
using System.Data;
using ShoppingApplication.Models.Viewmodel;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

namespace ShoppingAPI.Controllers
{

    [RoutePrefix("apiorder")]
    public class apiordercontroller : ApiController
    {
        DataSet ds;


        #region Dashboard APIs

        [Route("allorder")]
        [HttpPost]
        public string Dashboard([FromBody] Viewmodel.Order objOrders)
        {
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pagesize"]);

            List<Viewmodel.Order> orderList = new List<Viewmodel.Order>();

            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();


            var profile = objOrders.userRole;


            if (profile != null)
            {
                if (profile == "callcentre")
                {
                    lst.Add(new KeyValuePair<string, string>("@Type", "getallbycreateid"));
                    lst.Add(new KeyValuePair<string, string>("@CreatedBy", objOrders.UserId.ToString()));
                    
                }
                else
                {
                    lst.Add(new KeyValuePair<string, string>("@Type", "getall"));
                }

            }
            else
            {
                lst.Add(new KeyValuePair<string, string>("@Type", "getall"));

            }

            lst.Add(new KeyValuePair<string, string>("@PageNumber", objOrders.pageNumber));
            lst.Add(new KeyValuePair<string, string>("@RowsOfPage", pageSize.ToString()));
            lst.Add(new KeyValuePair<string, string>("@Status", objOrders.Status.ToString()));



            ds = db.ExecuteProcedure("SP_Orders", lst);
            if (ds != null)
            {
                orderList = DataTableConverter.DashboardList(ds.Tables[0]);
            }


            var jsonString = JsonConvert.SerializeObject(orderList);

            return jsonString;
        }


        [Route("delivery")]
        [HttpPost]
        public string Delivery([FromBody] Viewmodel.Order objOrders)
        {
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pagesize"]);

            long userId = objOrders.UserId;

            List<Viewmodel.Order> orderList = new List<Viewmodel.Order>();

            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>("@Type", "getbyuserid"));
            lst.Add(new KeyValuePair<string, string>("@DriverId", userId.ToString()));

            lst.Add(new KeyValuePair<string, string>("@PageNumber", objOrders.pageNumber));
            lst.Add(new KeyValuePair<string, string>("@RowsOfPage", pageSize.ToString()));
            lst.Add(new KeyValuePair<string, string>("@Status", objOrders.Status.ToString()));

            ds = db.ExecuteProcedure("SP_Orders", lst);
            if (ds != null)
            {
                orderList = DataTableConverter.DashboardList(ds.Tables[0]);
            }



            var jsonString = JsonConvert.SerializeObject(orderList);

            return jsonString;

        }


            #endregion


            [Route("get")]
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



        // api/apiorder/1
        // GET api/<controller>/5
        [Route("getbyid/{id}")]
        [HttpGet]
        public string Getbyid(long id)
        {
            Viewmodel.OrderInfo orderinfo = new Viewmodel.OrderInfo();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@orderid", id.ToString()));

            ds = db.ExecuteProcedure("SP_OrderDetail", lst);
            if (ds != null)
            {
                orderinfo = DataTableConverter.OrderItemInfo(ds);
            }

            var jsonString = JsonConvert.SerializeObject(orderinfo);


            return jsonString;
        }




        public string GenerateVoucher(int length)
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var voucher = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                voucher.Append(validChars[random.Next(validChars.Length)]);
            }
            return voucher.ToString();
        }


        [Route("GetVoucher")]
        [HttpGet]
        public string GetVoucher()
        {

            string voucher = GenerateVoucher(6);
            return voucher.ToString();
        }



        [Route("voucher")]
        [HttpPost]
        public string VoucherPost([FromBody] Voucher objVoucher)
        {
            Voucher cs = new Voucher();
            VoucherData obj = new VoucherData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "Insert"));
            lst.Add(new KeyValuePair<string, string>("@Name", objVoucher.Name));
            lst.Add(new KeyValuePair<string, string>("@StartDate", objVoucher.startdate));
            lst.Add(new KeyValuePair<string, string>("@EndDate", objVoucher.enddate));
            lst.Add(new KeyValuePair<string, string>("@OfferType", objVoucher.OfferType));
            lst.Add(new KeyValuePair<string, string>("@OfferPercent", objVoucher.OfferPercent));
            lst.Add(new KeyValuePair<string, string>("@OfferAmount", objVoucher.OfferAmount));
            lst.Add(new KeyValuePair<string, string>("@CreatedBY", objVoucher.CreatedBy));



            ds = db.ExecuteProcedure("SP_Voucher", lst);
            if (ds != null)
            {
                cs = obj.ConvertToVoucher(ds.Tables[0]);
            }
            var jsonString = JsonConvert.SerializeObject(cs);
            return jsonString;
        }


        [Route("verifyvoucher")]
        [HttpPost]
        public string VoucherVerify([FromBody] Voucher objVoucher)
        {

            Voucher cs = new Voucher();
            VoucherData obj = new VoucherData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "verify"));
            lst.Add(new KeyValuePair<string, string>("@StartDate", objVoucher.startdate));
            lst.Add(new KeyValuePair<string, string>("@EndDate", objVoucher.enddate));

            ds = db.ExecuteProcedure("SP_Customer", lst);
            if (ds != null)
            {
                cs = obj.ConvertToVoucher(ds.Tables[0]);
            }
            var jsonString = JsonConvert.SerializeObject(cs);
            return jsonString;
        }

        [Route("checkVoucher/{name}")]
        [HttpGet]
        public string checkVoucher(string name)
        {

            Voucher cs = new Voucher();
            VoucherData obj = new VoucherData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "check"));
            lst.Add(new KeyValuePair<string, string>("@Name", name));

            ds = db.ExecuteProcedure("SP_Voucher", lst);
            if (ds != null)
            {
                cs = obj.ConvertToVoucher(ds.Tables[0]);
            }
            var jsonString = JsonConvert.SerializeObject(cs);
            return jsonString;
        }



        [HttpPost]
        [Route("confirm")]
        public string Confirm(Customer cusvalue)
        {

            string orderNumber = "";

            List<UserProduct> prodObj = JsonConvert.DeserializeObject<List<UserProduct>>(cusvalue.SelectedProd.ToString());
            Customer cs = new Customer();
            CustomerData obj = new CustomerData();
            ShoppingDatabase db = new ShoppingDatabase();

            VoucherOrder objVoucher = new VoucherOrder();
            objVoucher = cusvalue.VouvherOrderInfo;

            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            if (cusvalue.Id == 0)
            {
                lst.Add(new KeyValuePair<string, string>("@Type", "add"));
                lst.Add(new KeyValuePair<string, string>("@mobile", cusvalue.Mobile.ToString()));
                lst.Add(new KeyValuePair<string, string>("@fullname", cusvalue.FullName.ToString()));
                lst.Add(new KeyValuePair<string, string>("@city", cusvalue.City.ToString()));
                lst.Add(new KeyValuePair<string, string>("@cityid", cusvalue.CityId.ToString()));

                lst.Add(new KeyValuePair<string, string>("@address1", cusvalue.Address1.ToString()));
                lst.Add(new KeyValuePair<string, string>("@Address2", cusvalue.Address2.ToString()));
                lst.Add(new KeyValuePair<string, string>("@Address3", cusvalue.Address3.ToString()));
                lst.Add(new KeyValuePair<string, string>("@AddressType", cusvalue.AddressType.ToString()));
                lst.Add(new KeyValuePair<string, string>("@Note", cusvalue.Note.ToString()));
                lst.Add(new KeyValuePair<string, string>("@CreatedBy", cusvalue.CreatedBy.ToString()));

                ds = db.ExecuteProcedure("SP_Customer", lst);
                if (ds != null)
                {
                    cs = obj.ConvertToCustomer(ds.Tables[0]);
                    cusvalue.Id = cs.Id;
                }
            }
            else
            {
                lst.Add(new KeyValuePair<string, string>("@Type", "update"));
                lst.Add(new KeyValuePair<string, string>("@Id", cusvalue.Id.ToString()));
                lst.Add(new KeyValuePair<string, string>("@mobile", cusvalue.Mobile.ToString()));
                lst.Add(new KeyValuePair<string, string>("@fullname", cusvalue.FullName.ToString()));
                lst.Add(new KeyValuePair<string, string>("@city", cusvalue.City.ToString()));
                lst.Add(new KeyValuePair<string, string>("@cityid", cusvalue.CityId.ToString()));

                lst.Add(new KeyValuePair<string, string>("@address1", cusvalue.Address1.ToString()));
                lst.Add(new KeyValuePair<string, string>("@Address2", cusvalue.Address2.ToString()));
                lst.Add(new KeyValuePair<string, string>("@Address3", cusvalue.Address3.ToString()));
                lst.Add(new KeyValuePair<string, string>("@AddressType", cusvalue.AddressType.ToString()));
                lst.Add(new KeyValuePair<string, string>("@Note", cusvalue.Note.ToString()));
                lst.Add(new KeyValuePair<string, string>("@CreatedBy", cusvalue.CreatedBy.ToString()));

                ds = db.ExecuteProcedure("SP_Customer", lst);
                if (ds != null)
                {
                    cs = obj.ConvertToCustomer(ds.Tables[0]);
                    cusvalue.Id = cs.Id;
                }
            }

            if (cusvalue.Id > 0)
            {
                string orderSts = "";// cusvalue.paymentType.ToString().ToLower() == "cash on delivery" ? "accepted" : "pending";

                if (cusvalue.paymentType.ToString().ToLower() == "cash")
                {
                    orderSts = "Accepted";
                }
                else
                {
                    orderSts = "pending";
                }


                lst = new List<KeyValuePair<string, string>>();
                lst.Add(new KeyValuePair<string, string>("@Type", "insertorder"));
                lst.Add(new KeyValuePair<string, string>("@CustomerId", cusvalue.Id.ToString()));
                lst.Add(new KeyValuePair<string, string>("@Status", orderSts));
                lst.Add(new KeyValuePair<string, string>("@scheduleTime", cusvalue.scheduleTime.ToString()));
                lst.Add(new KeyValuePair<string, string>("@PaymentType", cusvalue.paymentType.ToString()));
                lst.Add(new KeyValuePair<string, string>("@CreatedBy", cusvalue.CreatedBy.ToString()));
                lst.Add(new KeyValuePair<string, string>("@CityId", cusvalue.CityId.ToString()));
                lst.Add(new KeyValuePair<string, string>("@DriverId", cusvalue.DriverId.ToString()));

                lst.Add(new KeyValuePair<string, string>("@TotalAmount", objVoucher.TotalAmunt));
                lst.Add(new KeyValuePair<string, string>("@NetAmount", objVoucher.NetAmount));
                lst.Add(new KeyValuePair<string, string>("@DiscountedAmount", objVoucher.DiscountedAmount));
                lst.Add(new KeyValuePair<string, string>("@DiscountPercent", objVoucher.DiscountPercent));
                lst.Add(new KeyValuePair<string, string>("@DiscountType", objVoucher.DiscountType));
                lst.Add(new KeyValuePair<string, string>("@DiscountId", objVoucher.DiscountId));
                lst.Add(new KeyValuePair<string, string>("@Quantity", prodObj.Count.ToString()));
                lst.Add(new KeyValuePair<string, string>("@DeliveryDate", cusvalue.DeliveryDate.ToString()));

                ds = db.ExecuteProcedure("SP_Orders", lst);
                string orderId = ds.Tables[0].Rows[0]["id"].ToString();

                orderNumber= ds.Tables[0].Rows[0]["OrderNumber"].ToString();



                foreach (UserProduct ordetitem in prodObj)
                {
                    lst = new List<KeyValuePair<string, string>>();
                    lst.Add(new KeyValuePair<string, string>("@Type", "insertorderitem"));
                    lst.Add(new KeyValuePair<string, string>("@orderId", orderId.ToString()));
                    lst.Add(new KeyValuePair<string, string>("@ProductId", ordetitem.productId.ToString()));
                    lst.Add(new KeyValuePair<string, string>("@Quantity", ordetitem.count.ToString()));
                    ds = db.ExecuteProcedure("SP_Orders", lst);
                }

            }
                    
            return orderNumber;
        }

        [HttpPost]
        [Route("updatestatus")]
        public string updatestatus([FromBody] Order objOrder)
        {
            try
            {
                List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
                ShoppingDatabase db = new ShoppingDatabase();

                lst = new List<KeyValuePair<string, string>>();
                lst.Add(new KeyValuePair<string, string>("@Type", "updatests"));
                lst.Add(new KeyValuePair<string, string>("@orderId", objOrder.OrderId.ToString()));
                lst.Add(new KeyValuePair<string, string>("@Status", objOrder.Status));
                lst.Add(new KeyValuePair<string, string>("@CreatedBy", Convert.ToString(objOrder.UserId)));

                ds = db.ExecuteProcedure("SP_Orders", lst);

                string orderId = ds.Tables[0].Rows[0][0].ToString();

                return orderId;
            }
            catch (Exception ex)
            {
                return "0";
            }

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}