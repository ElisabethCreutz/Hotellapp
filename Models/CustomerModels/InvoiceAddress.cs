using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Models.CustomerModels
{
    public class InvoiceAddress
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }

        public InvoiceAddress()
        {

        }
    }
}
