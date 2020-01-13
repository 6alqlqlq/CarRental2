using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestCarRental3.Models
{
    public class City : BaseEntity
    {

        public int CountryID { get; set; }
        public string CityName { get; set; }

    }
}