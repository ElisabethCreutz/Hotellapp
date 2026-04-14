using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Models.CustomerModels
{
    public class CustomerAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        public CustomerAddress()
        {

        }
    }
}
