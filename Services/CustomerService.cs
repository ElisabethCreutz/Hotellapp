using FluentValidation.Results;
using HotelEC.Controllers;
using HotelEC.Data;
using HotelEC.Models.CustomerModels;

namespace HotelEC.Services
{
    public class CustomerService
    {
        public ApplicationDbContext dbContext { get; set; }
        public CustomerService(ApplicationDbContext db)
        {
            dbContext = db;
        }
   

        public void UpdateCustomer() { }
    }
}
