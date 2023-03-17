using DBLayer;
using Newtonsoft.Json;
using ShoppingApplication.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingAPI.Controllers
{


    [RoutePrefix("apireport")]
    public class apiReportController : ApiController
    {


        DataSet ds;

        // GET: api/apiReport
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [Route("daily")]
        [HttpGet]
        public string getDailyReport()
        {

            Report rpt = new Report();
            List<ReportInfo> rptList = new List<ReportInfo>();
            ReportTotalInfo rptTotal = new ReportTotalInfo();
            List<DeliveryCount> deliveryCountList = new List<DeliveryCount>();


            ReportData obj = new ReportData();
            ShoppingDatabase db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> lst = new List<KeyValuePair<string, string>>();

            lst.Add(new KeyValuePair<string, string>("@Type", "daily"));

            ds = db.ExecuteProcedure("SP_Reports", lst);
            if (ds != null)
            {
                rptList = obj.ConvertToReportList(ds.Tables[1]);

                rptTotal = obj.ConvertToReportTotal(ds.Tables[0]);

                deliveryCountList= obj.ConvertToDeliveryCountList(ds.Tables[2]);

                rpt.reportInfo = rptList;
                rpt.reportTtotalInfo = rptTotal;
                rpt.deliveryInfo = deliveryCountList;

            }

            var jsonString = JsonConvert.SerializeObject(rpt);
            return jsonString;
       
        }

        // POST: api/apiReport
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/apiReport/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/apiReport/5
        public void Delete(int id)
        {
        }
    }
}
