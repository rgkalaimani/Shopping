using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShoppingApplication.Models.Viewmodel
{
    public class Order
    {
        public long OrderId { get; set; }

        public string UserName { get; set; }

        public long UserId { get; set; }

        public string LName { get; set; }

        public string EntryDate { get; set; }

        public string EntryTime { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

        public long Quantity { get; set; }

        public long Price { get; set; }

        public long TPrice { get; set; }

        public string Status { get; set; }

        public string ScheduleTime { get; set; }

        public string PaymentType { get; set; }

        public string DeliveryDate { get; set; }

        public string DeliveryPerson { get; set; }

        public string userRole { get; set; }

        public string pageNumber { get; set; }

        public string rowsOfPage { get; set; }

        public string totalRows { get; set; }

        public string OrderNumber { get; set; }

        public string PickupTime { get; set; }

        public string DiscountId { get; set; }

        public string DisType { get; set; }

        public string DisAmount { get; set; }

    }

    public class Customer
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Mobile { get; set; }

        public string City { get; set; }

        public string CityId { get; set; }

        public string DriverId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public bool IsActive { get; set; }

        public string SelectedItem { get; set; }

        public string SelectedProd { get; set; }

        public string paymentType { get; set; }

        public string scheduleTime { get; set; }

        public string AddressType { get; set; }

        public string DeliveryDate { get; set; }

        public string Note { get; set; }

        public VoucherOrder VouvherOrderInfo { get; set; }

        public long CreatedBy { get; set; }

        public string lastOrderdate { get; set; }

        public int totalOrders { get; set; }

        public int cancelled { get; set; }

        public int PageNumber { get; set; }

        public int RowsOfPage { get; set; }

        public int totalrows { get; set; }


    }

    public class VoucherOrder
    {

        public string TotalAmunt { get; set; }

        public string NetAmount { get; set; }

        public string CounponCode { get; set; }

        public long CounponId { get; set; }

        public string DiscountPercent { get; set; }

        public string DiscountedAmount { get; set; }

        public string DiscountType { get; set; }

        public string DiscountId { get; set; }

    }


    public class Voucher
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string startdate { get; set; }

        public string enddate { get; set; }

        public string OfferType { get; set; }

        public string OfferPercent { get; set; }

        public string OfferAmount { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }


    public class Slaughter
    {
        public string DeliveryDate { get; set; }

        public int Id { get; set; }

        public string ProductType { get; set; }

        public string Name { get; set; }

        public string Name_Ar { get; set; }

        public int Frozen { get; set; }

        public int FreshEggs { get; set; }

        public int Fresh { get; set; }


    }

    public class UserProduct
    {
        public string productId { get; set; }

        public string count { get; set; }

        public string productType { get; set; }
    }

    public class Product
    {

        public long Id { get; set; }
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string img { get; set; }
        public double Price { get; set; }
        public string priceLbl { get; set; }
        public string priceLblAr { get; set; }
        public string Description { get; set; }

        public bool isActive { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }


    public class OrderInfo
    {
        public List<OrderItem> orderItems { get; set; }

        public Delivery delivery { get; set; }


    }

    public class OrderItem
    {
        public string OrderId { get; set; }

        public string Item { get; set; }

        public string Amount { get; set; }

        public string TotalAmount { get; set; }

    }

    public class Delivery
    {
        public string OrderId { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string TotalAmount { get; set; }

        public string DisAmount { get; set; }

        public string NetAmounT { get; set; }

        public string DisType { get; set; }

        public string DiscountId { get; set; }

    }

    public class City
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Name_Ar { get; set; }

        public long CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public long DriverId { get; set; }

    }

    public class ReportInfo
    {
        public int CreatedBy { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public string CreatedOrders { get; set; }


    }

    public class ReportTotalInfo
    {

        public string Month { get; set; }

        public string MonthlySales { get; set; }

        public string MonthlyOrders { get; set; }

        public string Today { get; set; }

        public string TodaySales { get; set; }

        public string TodayOrders { get; set; }


    }

    public class DeliveryCount
    {

        public string FirstName { get; set; }

        public string TotalOrder { get; set; }

        public string Pending { get; set; }

        public string Completed { get; set; }

        public string Cancelled { get; set; }

    }


    public class Report
    {
        public List<ReportInfo> reportInfo { get; set; }

        public ReportTotalInfo reportTtotalInfo { get; set; }

        public List<DeliveryCount> deliveryInfo { get; set; }

    }

    public static class DataTableConverter
    {
        public static List<Order> DashboardList(DataTable dtInput)
        {
            if (dtInput.Rows.Count > 0)
            {
                List<Order> orderList = new List<Order>();
                try
                {
                    foreach (DataRow item in dtInput.Rows)
                    {

                        orderList.Add(new Order
                        {
                            OrderId = Convert.ToInt64(item["OID"]),
                            UserName = item["OID"].ToString(),
                            UserId = Convert.ToInt64(item["UID"]),
                            LName = Convert.ToString(item["Iname"]),
                            EntryDate = Convert.ToString(item["EntryDate"]),

                            Image = Convert.ToString(item["Image"]),
                            IsActive = Convert.ToBoolean(item["IsActive"]),
                            Quantity = Convert.ToInt64(item["Qnt"]),
                            Price = Convert.ToInt64(item["Price"]),
                            TPrice = Convert.ToInt64(item["TPrice"]),
                            Status = Convert.ToString(item["Status"]),
                            EntryTime = Convert.ToString(item["EntryTime"]),
                            ScheduleTime = Convert.ToString(item["scheduleTime"]),
                            PaymentType = Convert.ToString(item["PaymentType"]),
                            DeliveryPerson = Convert.ToString(item["DeliveryPerson"]),
                            totalRows = Convert.ToString(item["totalrows"]),
                            pageNumber = Convert.ToString(item["PageNumber"]),
                            rowsOfPage = Convert.ToString(item["RowsOfPage"]),
                            OrderNumber = Convert.ToString(item["OrderNumber"]),
                            PickupTime = Convert.ToString(item["PickupTime"]),
                          
                            DiscountId = Convert.ToString(item["DiscountId"]),
                            DisType = Convert.ToString(item["DisType"]),
                            DisAmount = Convert.ToString(item["DisAmount"])

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return orderList;

            }

            return new List<Order>();

        }

        public static OrderInfo OrderItemInfo(DataSet dsInput)
        {
            List<OrderItem> OrderItemList = new List<OrderItem>();
            Delivery dvInfo = new Delivery();

            if (dsInput.Tables.Count > 0)
            {

                try
                {
                    foreach (DataRow item in dsInput.Tables[0].Rows)
                    {

                        OrderItemList.Add(new OrderItem
                        {
                            OrderId = Convert.ToString(item["OID"]),
                            Item = item["Item"].ToString(),
                            Amount = Convert.ToString(item["Amount"]),
                            TotalAmount = Convert.ToString(item["TotalAmount"])

                        });


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                try
                {
                    dvInfo.OrderId = Convert.ToString(dsInput.Tables[1].Rows[0]["OID"]);
                    dvInfo.Address = Convert.ToString(dsInput.Tables[1].Rows[0]["Address"]);
                    dvInfo.ContactNumber = Convert.ToString(dsInput.Tables[1].Rows[0]["ContactNumber"]);
                    dvInfo.Email = Convert.ToString(dsInput.Tables[1].Rows[0]["Email"]);

                    dvInfo.TotalAmount = Convert.ToString(dsInput.Tables[1].Rows[0]["TotalAmount"]);
                    dvInfo.DisAmount = Convert.ToString(dsInput.Tables[1].Rows[0]["DisAmount"]);
                    dvInfo.NetAmounT = Convert.ToString(dsInput.Tables[1].Rows[0]["NetAmounT"]);
                    dvInfo.DisType = Convert.ToString(dsInput.Tables[1].Rows[0]["DisType"]);
                    dvInfo.DiscountId = Convert.ToString(dsInput.Tables[1].Rows[0]["DiscountId"]);

                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }

            OrderInfo info = new OrderInfo();
            info.delivery = dvInfo;
            info.orderItems = OrderItemList;
            return info;

        }

        public static List<Product> ProductList(DataTable dtInput)
        {
            List<Product> productList = new List<Product>();

            if (dtInput.Rows.Count > 0)
            {

                try
                {
                    foreach (DataRow item in dtInput.Rows)
                    {

                        productList.Add(new Product
                        {
                            Id = Convert.ToInt64(item["Id"]),
                            ProductType = item["ProductType"].ToString(),
                            Name = Convert.ToString(item["Name"]),
                            NameAr = Convert.ToString(item["NameAr"]),
                            img = Convert.ToString(item["img"]),
                            Price = Convert.ToDouble(item["Price"]),
                            priceLbl = Convert.ToString(item["priceLbl"]),
                            priceLblAr = Convert.ToString(item["priceLblAr"]),
                            Description = Convert.ToString(item["Description"])

                        });


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return productList;

            }

            return productList;
        }
    }
}