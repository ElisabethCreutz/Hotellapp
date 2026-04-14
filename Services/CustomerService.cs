using FluentValidation.Results;
using HotelEC.Controllers;
using HotelEC.Data;
using HotelEC.Models.CustomerModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Services
{
    public class CustomerService
    {
        public ApplicationDbContext dbContext { get; set; }
        public CustomerService(ApplicationDbContext db)
        {
            dbContext = db;
        }
        public void CreateCustomer()
        {
            var customerService = new CustomerService(dbContext);
            Console.WriteLine("Vad heter du?");
            string firstName = Console.ReadLine();
            Console.WriteLine("Vad är ditt efternamn?");
            string lastName = Console.ReadLine();
            Console.WriteLine("Vad är din e-postadress?");
            string email = Console.ReadLine();
            Console.WriteLine("Vad är ditt telefonnummer?");
            string phone = Console.ReadLine();

            var customer = new Customer { FirstName = firstName, 
                LastName = lastName, 
                EmailAddress = email, 
                PhoneNumber = phone
            };
            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(customer);
            dbContext.Customers.Add(customer);

            dbContext.SaveChanges();
                     
        }
        public void UpdateCustomer() { }
        //public void DeleteCustomer() { }
    }
}
