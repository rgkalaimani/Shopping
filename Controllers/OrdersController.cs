using DBLayer;
using ShoppingApplication.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viewmodel = ShoppingApplication.Models.Viewmodel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.Text;


namespace ShoppingAPI.Controllers
{
    public class OrdersController : Controller
    {
        DataSet ds;
        List<Product> productList;

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delivery()
        {
            try
            {
                if (Session["UserProfile"] != null)
                {

                    //ShoppingApplication.Models.Datamodel.UserProfile objProfile = new ShoppingApplication.Models.Datamodel.UserProfile();
                    //objProfile = (ShoppingApplication.Models.Datamodel.UserProfile)Session["UserProfile"];
                    //long userId = objProfile.Id;

                    //List<Viewmodel.Order> orderList = new List<Viewmodel.Order>();

                    //ShoppingDatabase db = new ShoppingDatabase();
                    //List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
                    //lst.Add(new KeyValuePair<string, string>("@Type", "getbyuserid"));
                    //lst.Add(new KeyValuePair<string, string>("@DriverId", userId.ToString()));

                    //ds = db.ExecuteProcedure("SP_Orders", lst);
                    //if (ds != null)
                    //{
                    //    orderList = DataTableConverter.DashboardList(ds.Tables[0]);
                    //}

                    //return View(orderList);

                    return View();
                }
            }
            catch (Exception ex) { }

            return RedirectToAction("login", "user");


        }

        ///   [CustomizeAuthorize(Roles ="admin")]
        public ActionResult Home()
        {

            List<Viewmodel.Order> orderList = new List<Viewmodel.Order>();

            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();


            var profile = (ShoppingApplication.Models.Datamodel.UserProfile)Session["UserProfile"];
            if (profile != null)
            {
                if (profile.UserRole == "callcentre")
                {
                    lst.Add(new KeyValuePair<string, string>("@Type", "getallbycreateid"));
                    lst.Add(new KeyValuePair<string, string>("@CreatedBy", profile.Id.ToString()));
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

            ds = db.ExecuteProcedure("SP_Orders", lst);
            if (ds != null)
            {
                orderList = DataTableConverter.DashboardList(ds.Tables[0]);
            }

            //return View(orderList);

            return View();
        }

        public ActionResult Order()
        {
            productList = new List<Product>();

            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>("@Type", "all"));
            ds = db.ExecuteProcedure("SP_Product", lst);
            if (ds != null)
            {
                productList = DataTableConverter.ProductList(ds.Tables[0]);
            }

            return View(productList);
        }

        public ActionResult Salesreport()
        {
            return View();
        }

        public ActionResult Customer()
        {

            //List<Customer> csList = new List<Customer>();
            //CustomerData obj = new CustomerData();
            //ShoppingDatabase db = new ShoppingDatabase();
            //List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            //lst.Add(new KeyValuePair<string, string>("@Type", "getall"));

            //ds = db.ExecuteProcedure("SP_Customer", lst);
            //if (ds != null)
            //{
            //    csList = obj.ConvertToCustomerList(ds.Tables[0]);
            //}

            return View();
        }

        public ActionResult voucher()
        {

            List<Viewmodel.Voucher> voucherList = new List<Viewmodel.Voucher>();
            VoucherData obj = new VoucherData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>("@Type", "getall"));
            ds = db.ExecuteProcedure("SP_Voucher", lst);
            if (ds != null)
            {
                voucherList = obj.ConvertToVoucherList(ds.Tables[0]);
            }

            return View(voucherList);
        }

        public ActionResult Confirm()
        {
            return View();
        }

        public ActionResult Slaughter()
        {
            List<Viewmodel.Slaughter> slaughterList = new List<Viewmodel.Slaughter>();
            SlaughterData obj = new SlaughterData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>("@Type", "slaughter"));
            ds = db.ExecuteProcedure("SP_Orders", lst);
            if (ds != null)
            {
                slaughterList = obj.ConvertToSlaughterList(ds.Tables[0]);
            }

            return View(slaughterList);
        }

        public ActionResult SlaughterPrint()
        {
            List<Viewmodel.Slaughter> slaughterList = new List<Viewmodel.Slaughter>();
            SlaughterData obj = new SlaughterData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
            lst.Add(new KeyValuePair<string, string>("@Type", "slaughter"));
            ds = db.ExecuteProcedure("SP_Orders", lst);
            if (ds != null)
            {
                slaughterList = obj.ConvertToSlaughterList(ds.Tables[0]);
            }

            return View(slaughterList);
        }

        public ActionResult Print()
        {
            try
            {
                var orderId = Request.QueryString["oid"].ToString();
                var lang = Request.QueryString["la"].ToString();

                if(lang.ToLower()=="english")
                {
                    
                    ViewBag.lang = "en";
                    ViewBag.dir = "ltr";
                }
                else
                {
                    ViewBag.lang = "ar";
                    ViewBag.dir = "rtl";
                }

                Viewmodel.OrderInfo orderinfo = new Viewmodel.OrderInfo();
                ShoppingDatabase db = new ShoppingDatabase();
                List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

                lst.Add(new KeyValuePair<string, string>("@orderid", orderId.ToString()));

                ds = db.ExecuteProcedure("SP_OrderDetail", lst);
                if (ds != null)
                {
                    orderinfo = DataTableConverter.OrderItemInfo(ds);
                }

                ///   var jsonString = JsonConvert.SerializeObject(orderinfo);




                return View(orderinfo);
            }
            catch (Exception ex) { }

            return View();
        }

        // [HttpPost]
        //[ValidateInput(false)]
        public FileResult Export()
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {


                List<Viewmodel.Slaughter> slaughterList = new List<Viewmodel.Slaughter>();
                SlaughterData obj = new SlaughterData();
                ShoppingDatabase db = new ShoppingDatabase();
                List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();
                lst.Add(new KeyValuePair<string, string>("@Type", "slaughter"));
                ds = db.ExecuteProcedure("SP_Orders", lst);
                if (ds != null)
                {
                    slaughterList = obj.ConvertToSlaughterList(ds.Tables[0]);
                }

                StringBuilder str = new StringBuilder();
                int frozenTotal = 0;
                int freshTotal = 0;
                int freshEggsTotal = 0;

                foreach (var item in slaughterList)
                {

                    str.Append("<tr> <td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>" + @item.DeliveryDate + "</h7></td>");
                    str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>" + @item.Name + "</h7></td>");
                    str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>" + @item.Name_Ar + "</h7></td>");
                    str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>" + @item.Frozen + "</h7></td>");
                    str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>" + @item.FreshEggs + "</h7></td>");
                    str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>" + @item.Fresh + "</h7></td></tr>" + Environment.NewLine);

                    frozenTotal = frozenTotal + Convert.ToInt32(@item.Frozen);
                    freshEggsTotal = freshEggsTotal + Convert.ToInt32(@item.FreshEggs);
                    freshTotal = freshTotal + Convert.ToInt32(@item.Fresh);

                }

                str.Append("<tr> <td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7></h7></td>");
                str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7></h7></td>");
                str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>Total:</h7></td>");
                str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>" + frozenTotal.ToString() + "</h7></td>");
                str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>" + freshEggsTotal.ToString() + "</h7></td>");
                str.Append("<td style='width: 100px;border: 1px; border-style: solid; padding: 5px;'><h7>" + freshTotal.ToString() + "</h7></td></tr>");


                string text = System.IO.File.ReadAllText(Server.MapPath("~/template.html"));

                text = text.Replace("{slaughtercontent}", str.ToString());

                StringReader sr = new StringReader(text.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    pdfDoc.Open();

                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();

                    return File(bytes, "application/pdf", "Slaughter.pdf");
                }


            }
        }
    }
}