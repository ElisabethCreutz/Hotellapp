using HotelEC.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelEC.Services.CustomerServices
{
    public class DeleteCustomer:ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public DeleteCustomer(ApplicationDbContext db)
        {
            dbContext = db;
        }


        public void Run() { }
    }
}

