using Bogus;
using HotelEC.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Data
{
    public class BogusCustomers
    {
        public static List<Customer> Create(int customerNum)
        {
            // Skapa en Faker för Customer
            var customerFaker = new Faker<Customer>()
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())// Efternamn
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.EmailAddress, f => f.Internet.Email()) // Giltig e-postadress
                .RuleFor(c => c.PhoneNumber, f => "0" + f.Random.Number(100000000, 999999999)) // Telefonnummer börjar med 0
                ;

            return customerFaker.Generate(customerNum);
        }
    }
}
