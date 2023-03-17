using Newtonsoft.Json;
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
using System.Configuration;

namespace ShoppingAPI.Controllers
{

    [RoutePrefix("apicustomer")]
    public class apicustomerController : ApiController
    {

        DataSet ds;


        // GET: api/apicustomer
        [HttpGet]
        [Route("cities")]
        public string Getcities()
        {
            List<City> cityList = new List<City>();
            CustomerData obj = new CustomerData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "cities"));            

            ds = db.ExecuteProcedure("SP_Customer", lst);
            if (ds != null)
            {
                cityList = obj.ConvertToCityList(ds.Tables[0]);
            }
            var jsonString = JsonConvert.SerializeObject(cityList);
            return jsonString;
        }


        [HttpPost]
        [Route("customerlist")]
        public string CustomerList([FromBody] Viewmodel.Customer objCustomer)
        {
            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pagesize"]);

            List<Customer> csList = new List<Customer>();
            CustomerData obj = new CustomerData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "getall"));
            lst.Add(new KeyValuePair<string, string>("@PageNumber", objCustomer.PageNumber.ToString()));
            lst.Add(new KeyValuePair<string, string>("@RowsOfPage", pageSize.ToString()));

            ds = db.ExecuteProcedure("SP_Customer", lst);
            if (ds != null)
            {
                csList = obj.ConvertToCustomerList(ds.Tables[0]);
            }
                                 

            var jsonString = JsonConvert.SerializeObject(csList);
            return jsonString;            
        }


        // GET: api/apicustomer/5
        [HttpGet]
        [Route("getbynumber/{id}")]
        public string Get(string id)
        {
            Customer cs = new Customer();
            CustomerData obj = new CustomerData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "search"));
            lst.Add(new KeyValuePair<string, string>("@mobile", id.ToString()));

            ds = db.ExecuteProcedure("SP_Customer", lst);
            if (ds != null)
            {
                cs = obj.ConvertToCustomer(ds.Tables[0]);
            }

            var jsonString = JsonConvert.SerializeObject(cs);
            return jsonString;
        }

        // GET: api/apicustomer/5        
        public string search(string id)
        {



            return "value";
        }


        // POST: api/apicustomer
        [HttpPost]        
        [Route("create")]
        public string Post(Customer cusvalue)
        {

            //  List<UserProduct> prodObj = JsonSerializer.Deserialize<List<UserProduct>>(cusvalue.SelectedProd.ToString());

            List<UserProduct> prodObj = JsonConvert.DeserializeObject<List<UserProduct>>(cusvalue.SelectedProd.ToString());




            Customer cs = new Customer();
            CustomerData obj = new CustomerData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "add"));
            lst.Add(new KeyValuePair<string, string>("@mobile", cusvalue.Mobile.ToString()));
            lst.Add(new KeyValuePair<string, string>("@fullname", cusvalue.FullName.ToString()));
            lst.Add(new KeyValuePair<string, string>("@city", cusvalue.City.ToString()));
            lst.Add(new KeyValuePair<string, string>("@address1", cusvalue.Address1.ToString()));
            lst.Add(new KeyValuePair<string, string>("@Address2", cusvalue.Address2.ToString()));
            lst.Add(new KeyValuePair<string, string>("@Address3", cusvalue.Address3.ToString()));

            ds = db.ExecuteProcedure("SP_Customer", lst);
            if (ds != null)
            {
                cs = obj.ConvertToCustomer(ds.Tables[0]);
            }

            if (cs.Id > 0)
            {
                lst = new List<KeyValuePair<string, string>>();
                lst.Add(new KeyValuePair<string, string>("@Type", "insertorder"));
                lst.Add(new KeyValuePair<string, string>("@CustomerId", cs.Id.ToString()));
                lst.Add(new KeyValuePair<string, string>("@Status", "P"));
                ds = db.ExecuteProcedure("SP_Orders", lst);

                string orderId = ds.Tables[0].Rows[0][0].ToString();


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

          //  var jsonString = JsonConvert.SerializeObject(cs);
         //   return jsonString;
            

            return "success";
        }

        // PUT: api/apicustomer/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/apicustomer/5
        public void Delete(int id)
        {
        }
    }
}
