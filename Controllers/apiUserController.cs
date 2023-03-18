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

        [HttpGet]
        [Route("getbyid/{id}")]
        public string Get(int id)
        {
            ApiResult api = new ApiResult();
            UserInfoData obj = new UserInfoData();
            List<ShoppingApplication.Models.Datamodel.UserProfile> userList = new List<ShoppingApplication.Models.Datamodel.UserProfile>();

            db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> listUserinfo = new List<KeyValuePair<string, string>>();
            listUserinfo.Add(new KeyValuePair<string, string>("@Type", "get"));
            listUserinfo.Add(new KeyValuePair<string, string>("@Id", id.ToString()));            

            ds = db.ExecuteProcedure("SP_UserInfo", listUserinfo);

            if (ds != null)
            {

                userList = obj.ConvertToUsersList(ds.Tables[0]);
                if (userList.Count > 0)
                {
                    api.userinfo = userList[0];
                    api.id = userList[0].Id.ToString();
                    if (Convert.ToInt32(api.id) > 0)
                    {
                        api.result = Resources.Global.Success;
                    }
                    else
                    {
                        api.result = Resources.Global.Usernamtaken;
                    }
                }
                else
                {
                    api.userinfo = null;
                    api.id = "0";
                    api.result = Resources.Global.Usernamtaken;
                }

            }
            else
            {
                api.userinfo = null;
                api.id = "0";
                api.result = Resources.Global.ErrorOccured;
            }


            var jsonString = JsonConvert.SerializeObject(api);

            return jsonString;

        }

        [HttpPost]
        [Route("create")]
        public string Create([FromBody] UserProfile objUser)
        {
            
            ApiResult api = new ApiResult();
            UserInfoData obj = new UserInfoData();
            List<ShoppingApplication.Models.Datamodel.UserProfile> userList = new List<ShoppingApplication.Models.Datamodel.UserProfile>();

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

                userList = obj.ConvertToUsersList(ds.Tables[0]);
                if (userList.Count > 0)
                {
                    api.userinfo = userList[0];
                    api.id = userList[0].Id.ToString();
                    if (Convert.ToInt32(api.id) > 0)
                    {
                        api.result = Resources.Global.Success;
                    }
                    else
                    {
                        api.result = Resources.Global.Usernamtaken;
                    }
                }
                else
                {
                    api.userinfo = null;
                    api.id = "0";
                    api.result = Resources.Global.Usernamtaken;
                }

            }
            else
            {
                api.userinfo = null;
                api.id = "0";
                api.result = Resources.Global.ErrorOccured;
            }


            var jsonString = JsonConvert.SerializeObject(api);

            return jsonString;


        }

        [HttpPost]
        [Route("update")]
        public string post([FromBody] UserProfile objUser)
        {
            ApiResult api = new ApiResult();
            UserInfoData obj = new UserInfoData();
            List<ShoppingApplication.Models.Datamodel.UserProfile> userList = new List<ShoppingApplication.Models.Datamodel.UserProfile>();

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

                userList = obj.ConvertToUsersList(ds.Tables[0]);
                if (userList.Count > 0)
                {
                    api.userinfo = userList[0];
                    api.id = userList[0].Id.ToString();
                    if (Convert.ToInt32(api.id) > 0)
                    {
                        api.result = Resources.Global.Success;
                    }
                    else
                    {
                        api.result = Resources.Global.ErrorOccured;
                    }
                }
                else
                {
                    api.userinfo = null;
                    api.id = "0";
                    api.result = Resources.Global.ErrorOccured;
                }

            }
            else
            {
                api.userinfo = null;
                api.id = "0";
                api.result = Resources.Global.ErrorOccured;
            }


            var jsonString = JsonConvert.SerializeObject(api);

            return jsonString;
        }

        [HttpPost]
        [Route("delete")]
        public string Delete([FromBody] UserProfile objUser)
        {
            ApiResult api = new ApiResult();
            UserInfoData obj = new UserInfoData();
            List<ShoppingApplication.Models.Datamodel.UserProfile> userList = new List<ShoppingApplication.Models.Datamodel.UserProfile>();

            db = new ShoppingDatabase();
            List<KeyValuePair<string, string>> listUserinfo = new List<KeyValuePair<string, string>>();
            listUserinfo.Add(new KeyValuePair<string, string>("@Type", "delete"));
            listUserinfo.Add(new KeyValuePair<string, string>("@Id", Convert.ToString(objUser.Id)));
            listUserinfo.Add(new KeyValuePair<string, string>("@CreatedBy", objUser.CreatedBy.ToString()));

            ds = db.ExecuteProcedure("SP_UserInfo", listUserinfo);
            if (ds != null)
            {

                userList = obj.ConvertToUsersList(ds.Tables[0]);
                if (userList.Count > 0)
                {
                    api.userinfo = userList[0];
                    api.id = userList[0].Id.ToString();
                    if (Convert.ToInt32(api.id) > 0)
                    {
                        api.result = Resources.Global.Success;
                    }
                    else
                    {
                        api.result = Resources.Global.ErrorOccured;
                    }
                }
                else
                {
                    api.userinfo = null;
                    api.id = "0";
                    api.result = Resources.Global.ErrorOccured;
                }

            }
            else
            {
                api.userinfo = null;
                api.id = "0";
                api.result = Resources.Global.ErrorOccured;
            }


            var jsonString = JsonConvert.SerializeObject(api);

            return jsonString;

        }
    }
}