
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TestCarRental3.Models
{
    public class Product : BaseEntity
    {
        [StringLength(20)]
        [DisplayName("Product name")]
        public string car_brand { get; set; }
        public string car_model { get; set; }
        public int YearOfManufacturing { get; set; }
        public string image { get; set; }
        public int capacity { get; set; }
        public int doors { get; set; }
        public string Engine { get; set; }
        public string Gearbox { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        
        public int hire_cost { get; set; }

       
    }

}