using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShoppingApplication.Models.Viewmodel
{
    public class CustomerData
    {
        public Customer ConvertToCustomer(DataTable dtInput)
        {
            Customer cus = new Customer();
            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    cus.Id = Convert.ToInt64(dtInput.Rows[0]["Id"].ToString());
                    cus.FullName = Convert.ToString(dtInput.Rows[0]["FullName"]);
                    cus.Mobile = Convert.ToString(dtInput.Rows[0]["Mobile"]);
                    cus.City = Convert.ToString(dtInput.Rows[0]["City"]);
                    cus.CityId = Convert.ToString(dtInput.Rows[0]["CityId"]);
                    cus.Address1 = Convert.ToString(dtInput.Rows[0]["Address1"]);
                    cus.Address2 = Convert.ToString(dtInput.Rows[0]["Address2"]);
                    cus.Address3 = Convert.ToString(dtInput.Rows[0]["Address3"]);
                    cus.Note = Convert.ToString(dtInput.Rows[0]["Note"]);
                    cus.AddressType = Convert.ToString(dtInput.Rows[0]["AddressType"]);
                    cus.totalOrders = Convert.ToInt32(dtInput.Rows[0]["totalOrders"]);
                    cus.cancelled = Convert.ToInt32(dtInput.Rows[0]["Cancelled"]);

                    cus.totalrows = Convert.ToInt32(dtInput.Rows[0]["totalrows"]);
                    cus.PageNumber = Convert.ToInt32(dtInput.Rows[0]["PageNumber"]);
                    cus.RowsOfPage = Convert.ToInt32(dtInput.Rows[0]["RowsOfPage"]);
                    cus.lastOrderdate = Convert.ToString(dtInput.Rows[0]["lastOrderdate"]);


                }
            }
            catch (Exception ex) { }
            return cus;
        }

        public List<Customer> ConvertToCustomerList(DataTable dtInput)
        {


            List<Customer> cusList = new List<Customer>();

            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInput.Rows.Count; i++)
                    {
                        Customer cus = new Customer();
                        cus.Id = Convert.ToInt64(dtInput.Rows[i]["Id"].ToString());
                        cus.FullName = Convert.ToString(dtInput.Rows[i]["FullName"]);
                        cus.Mobile = Convert.ToString(dtInput.Rows[i]["Mobile"]);
                        cus.City = Convert.ToString(dtInput.Rows[i]["City"]);
                        cus.Address1 = Convert.ToString(dtInput.Rows[i]["Address1"]);
                        cus.Address2 = Convert.ToString(dtInput.Rows[i]["Address2"]);
                        cus.Address3 = Convert.ToString(dtInput.Rows[i]["Address3"]);
                        cus.AddressType = Convert.ToString(dtInput.Rows[i]["AddressType"]);
                        cus.Note = Convert.ToString(dtInput.Rows[i]["Note"]);
                        cus.totalOrders = Convert.ToInt32(dtInput.Rows[i]["totalOrders"]);
                        cus.cancelled = Convert.ToInt32(dtInput.Rows[i]["Cancelled"]);
                        cus.CityId = Convert.ToString(dtInput.Rows[i]["CityId"]);

                        cus.totalrows = Convert.ToInt32(dtInput.Rows[i]["totalrows"]);
                        cus.PageNumber = Convert.ToInt32(dtInput.Rows[i]["PageNumber"]);
                        cus.RowsOfPage = Convert.ToInt32(dtInput.Rows[i]["RowsOfPage"]);
                        cus.lastOrderdate = Convert.ToString(dtInput.Rows[i]["lastOrderdate"]);

                        

                        cusList.Add(cus);
                    }
                }
            }
            catch (Exception ex) { }

            return cusList;
        }

        public List<City> ConvertToCityList(DataTable dtInput)
        {


            List<City> cusList = new List<City>();

            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInput.Rows.Count; i++)
                    {
                        City city = new City();
                        city.Id = Convert.ToInt64(dtInput.Rows[i]["Id"].ToString());
                        city.Name = Convert.ToString(dtInput.Rows[i]["Name"]);
                        city.Name_Ar = Convert.ToString(dtInput.Rows[i]["Name_Ar"]);
                        city.DriverId = Convert.ToInt64(dtInput.Rows[i]["DriverId"]);
                        city.IsActive = Convert.ToBoolean(dtInput.Rows[i]["IsActive"]);
                        cusList.Add(city);
                    }
                }
            }
            catch (Exception ex) { }

            return cusList;
        }
    }

    public class VoucherData
    {
        public Voucher ConvertToVoucher(DataTable dtInput)
        {
            Voucher cus = new Voucher();
            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    cus.Id = Convert.ToInt64(dtInput.Rows[0]["Id"].ToString());
                    cus.Name = Convert.ToString(dtInput.Rows[0]["Name"]);
                    cus.startdate = Convert.ToString(dtInput.Rows[0]["startdate"]);
                    cus.enddate = Convert.ToString(dtInput.Rows[0]["enddate"]);
                    cus.OfferType = Convert.ToString(dtInput.Rows[0]["OfferType"]);
                    cus.OfferPercent = Convert.ToString(dtInput.Rows[0]["OfferPercent"]);
                    cus.OfferAmount = Convert.ToString(dtInput.Rows[0]["OfferAmount"]);
                    cus.CreatedBy = Convert.ToString(dtInput.Rows[0]["CreatedBy"]);
                }
            }
            catch (Exception ex) { }
            return cus;
        }

        public List<Voucher> ConvertToVoucherList(DataTable dtInput)
        {
            List<Voucher> cusList = new List<Voucher>();
            try
            {

                if (dtInput.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInput.Rows.Count; i++)
                    {
                        Voucher cus = new Voucher();
                        cus.Id = Convert.ToInt64(dtInput.Rows[i]["Id"].ToString());
                        cus.Name = Convert.ToString(dtInput.Rows[i]["Name"]);
                        cus.startdate = Convert.ToString(dtInput.Rows[i]["startdate"]);
                        cus.enddate = Convert.ToString(dtInput.Rows[i]["enddate"]);
                        cus.OfferType = Convert.ToString(dtInput.Rows[i]["OfferType"]);
                        cus.OfferPercent = Convert.ToString(dtInput.Rows[i]["OfferPercent"]);
                        cus.OfferAmount = Convert.ToString(dtInput.Rows[i]["OfferAmount"]);
                        cus.CreatedBy = Convert.ToString(dtInput.Rows[i]["CreatedBy"]);
                        cusList.Add(cus);
                    }

                }
            }
            catch (Exception ex) { }
            return cusList;
        }
    }


    public class SlaughterData
    {
        public Slaughter ConvertToSlaughterData(DataTable dtInput)
        {
            Slaughter slaughter = new Slaughter();
            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    slaughter.Id = Convert.ToInt32(dtInput.Rows[0]["Id"].ToString());
                    slaughter.DeliveryDate = Convert.ToString(dtInput.Rows[0]["DeliveryDate"]);
                    slaughter.Name = Convert.ToString(dtInput.Rows[0]["Name"]);
                    slaughter.Name_Ar = Convert.ToString(dtInput.Rows[0]["NameAr"]);
                    slaughter.Frozen = Convert.ToInt32(dtInput.Rows[0]["Frozen"]);
                    slaughter.FreshEggs = Convert.ToInt32(dtInput.Rows[0]["FreshEggs"]);
                    slaughter.Fresh = Convert.ToInt32(dtInput.Rows[0]["Fresh"]);
                    slaughter.ProductType = Convert.ToString(dtInput.Rows[0]["ProductType"]);
                }
            }
            catch (Exception ex) { }
            return slaughter;
        }

        public List<Slaughter> ConvertToSlaughterList(DataTable dtInput)
        {
            List<Slaughter> slaughterList = new List<Slaughter>();
            Slaughter slaughter;// = new Slaughter();
            try
            {



                foreach (DataRow item in dtInput.Rows)
                {
                    slaughter = new Slaughter();

                    //slaughter.Id = Convert.ToInt32(item["Id"].ToString());
                    slaughter.DeliveryDate = Convert.ToString(item["DeliveryDate"]);
                    slaughter.Name = Convert.ToString(item["Name"]);
                    slaughter.Name_Ar = Convert.ToString(item["NameAr"]);
                    slaughter.Frozen = Convert.ToInt32(item["Frozen"]);
                    slaughter.FreshEggs = Convert.ToInt32(item["FreshEggs"]);                    
                    slaughter.Fresh = Convert.ToInt32(item["Fresh"]);
                    slaughterList.Add(slaughter);

                }

                if (dtInput.Rows.Count > 0)
                {
                }
            }
            catch (Exception ex) { }

            return slaughterList;
        }


    }
    public class UserInfoDdata
    {
        public Datamodel.UserProfile ConvertToUserInfo(DataTable dtInput)
        {
            Datamodel.UserProfile user = new Datamodel.UserProfile();
            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    user.Id = Convert.ToInt64(dtInput.Rows[0]["Id"].ToString());
                    user.UserName = Convert.ToString(dtInput.Rows[0]["UserName"]);
                    user.UserType = Convert.ToString(dtInput.Rows[0]["UserType"]);
                    user.UserRole = Convert.ToString(dtInput.Rows[0]["userrole"]);
                    user.IsActive = Convert.ToBoolean(dtInput.Rows[0]["IsActive"]);
                }
            }
            catch (Exception ex) { }
            return user;
        }

        public List<Datamodel.UserProfile> ConvertToUsersList(DataTable dtInput)
        {
            List<Datamodel.UserProfile> userList = new List<Datamodel.UserProfile>();
            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInput.Rows.Count; i++)
                    {
                        Datamodel.UserProfile user = new Datamodel.UserProfile();
                        user.Id = Convert.ToInt64(dtInput.Rows[i]["Id"].ToString());
                        user.UserName = Convert.ToString(dtInput.Rows[i]["UserName"]);
                        user.UserType = Convert.ToString(dtInput.Rows[i]["UserType"]);
                        user.UserRole = Convert.ToString(dtInput.Rows[i]["userrole"]);
                        user.IsActive = Convert.ToBoolean(dtInput.Rows[i]["IsActive"]);
                        user.FirstName = Convert.ToString(dtInput.Rows[i]["FirstName"]);
                        user.LastName = Convert.ToString(dtInput.Rows[i]["LastName"]);
                        userList.Add(user);
                    }

                }
            }
            catch (Exception ex) { }
            return userList;
        }
    }


    public class ReportData
    {
        public ReportTotalInfo ConvertToReportTotal(DataTable dtInput)
        {
            ReportTotalInfo rpt = new ReportTotalInfo();
            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    rpt.Month = Convert.ToString(dtInput.Rows[0]["Month"].ToString());
                    rpt.MonthlySales = Convert.ToString(dtInput.Rows[0]["MonthSales"]);
                    rpt.MonthlyOrders = Convert.ToString(dtInput.Rows[0]["MonthOrders"].ToString());
                    rpt.Today = Convert.ToString(dtInput.Rows[0]["Today"]);

                    rpt.TodaySales = Convert.ToString(dtInput.Rows[0]["TodaySales"]);
                    rpt.TodayOrders = Convert.ToString(dtInput.Rows[0]["TodayOrders"]);
                }
            }
            catch (Exception ex) { }
            return rpt;
        }

        public List<ReportInfo> ConvertToReportList(DataTable dtInput)
        {
            List<ReportInfo> rptList = new List<ReportInfo>();
            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInput.Rows.Count; i++)
                    {
                        ReportInfo rpt = new ReportInfo();
                        rpt.CreatedBy = Convert.ToInt32(dtInput.Rows[i]["CreatedBy"].ToString());
                        rpt.Name = Convert.ToString(dtInput.Rows[i]["Name"]);
                        rpt.CreatedOn = Convert.ToString(dtInput.Rows[i]["CreatedOn"]);
                        rpt.CreatedOrders = Convert.ToString(dtInput.Rows[i]["CreatedOrders"]);
                        rptList.Add(rpt);
                    }
                }
            }
            catch (Exception ex) { }
            return rptList;
        }

        public List<DeliveryCount> ConvertToDeliveryCountList(DataTable dtInput)
        {
            List<DeliveryCount> rptList = new List<DeliveryCount>();
            try
            {
                if (dtInput.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInput.Rows.Count; i++)
                    {
                        DeliveryCount rpt = new DeliveryCount();
                        rpt.FirstName = Convert.ToString(dtInput.Rows[i]["FirstName"].ToString());
                        rpt.TotalOrder = Convert.ToString(dtInput.Rows[i]["TotalOrder"]);
                        rpt.Pending = Convert.ToString(dtInput.Rows[i]["Pending"]);
                        rpt.Completed = Convert.ToString(dtInput.Rows[i]["Completed"]);
                        rpt.Cancelled = Convert.ToString(dtInput.Rows[i]["Cancelled"]);
                        rptList.Add(rpt);
                    }
                }
            }
            catch (Exception ex) { }
            return rptList;
        }
    }
}