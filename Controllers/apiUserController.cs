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
using ShoppingApplication.Models.Datamodel;

namespace ShoppingAPI.Controllers
{




    [RoutePrefix("apiuser")]
    public class apiUserController : ApiController
    {
        DataSet ds;

        ShoppingDatabase db;

        [HttpGet]
        [Route("getall")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("create")]
        public string Create([FromBody] UserProfile objUser)
        {

            db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> listUserinfo = new List<KeyValuePair<string, string>>();
            listUserinfo.Add(new KeyValuePair<string, string>("@Type", "add"));
            listUserinfo.Add(new KeyValuePair<string, string>("@FirstName", objUser.FirstName));
            listUserinfo.Add(new KeyValuePair<string, string>("@LastName", objUser.LastName));
            listUserinfo.Add(new KeyValuePair<string, string>("@UserName", objUser.UserName));
            listUserinfo.Add(new KeyValuePair<string, string>("@password", objUser.Password));
            listUserinfo.Add(new KeyValuePair<string, string>("@UserType", objUser.UserType));
            listUserinfo.Add(new KeyValuePair<string, string>("@Role", objUser.UserType.ToString().ToLower()));
            listUserinfo.Add(new KeyValuePair<string, string>("@CreatedBy", objUser.Id.ToString()));

            ds = db.ExecuteProcedure("SP_UserInfo", listUserinfo);
            if (ds != null)
            {
                return ds.Tables[0].Rows[0]["Id"].ToString();
            }
            else
            {
                return "0";
            }

        }

        [HttpPost]
        [Route("update")]
        public string post([FromBody] UserProfile objUser)
        {
            db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> listUserinfo = new List<KeyValuePair<string, string>>();
            listUserinfo.Add(new KeyValuePair<string, string>("@Type", "update"));
            listUserinfo.Add(new KeyValuePair<string, string>("@FirstName", objUser.FirstName));
            listUserinfo.Add(new KeyValuePair<string, string>("@LastName", objUser.LastName));
            listUserinfo.Add(new KeyValuePair<string, string>("@UserName", objUser.UserName));
            listUserinfo.Add(new KeyValuePair<string, string>("@password", objUser.Password));
            listUserinfo.Add(new KeyValuePair<string, string>("@UserType", objUser.UserType));
            listUserinfo.Add(new KeyValuePair<string, string>("@Role", objUser.UserType.ToString().ToLower()));
            listUserinfo.Add(new KeyValuePair<string, string>("@CreatedBy", objUser.Id.ToString()));

            ds = db.ExecuteProcedure("SP_UserInfo", listUserinfo);
            if (ds != null)
            {
                return ds.Tables[0].Rows[0]["Id"].ToString();
            }
            else
            {
                return "0";
            }

        }

        [HttpPost]
        [Route("delete")]
        public string Delete([FromBody] UserProfile objUser)
        {

            db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> listUserinfo = new List<KeyValuePair<string, string>>();
            listUserinfo.Add(new KeyValuePair<string, string>("@Type", "delete"));
            listUserinfo.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(objUser.Id)));            
            listUserinfo.Add(new KeyValuePair<string, string>("@CreatedBy", objUser.CreatedBy.ToString()));

            ds = db.ExecuteProcedure("SP_UserInfo", listUserinfo);
            if (ds != null)
            {
                return ds.Tables[0].Rows[0]["Id"].ToString();
            }
            else
            {
                return "0";
            }

        }
    }
}