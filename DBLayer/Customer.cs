using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingAPI.DBLayer
{
    public class Customer
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Mobile  { get; set; }

        public string City { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public bool IsActive { get; set; }        

    }
}