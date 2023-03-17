using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApplication.Models.Datamodel
{
    public class UserProfile
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }        
    }

    public class Customer
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Mobile { get; set; }

        public string City { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsActive { get; set; }

    }

    public class Product
    {

        public long Id { get; set; }
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string img { get; set; }
        public string Price { get; set; }
        public string priceLbl { get; set; }
        public string priceLblAr { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime  ModifiedOn { get; set; }
    }
}