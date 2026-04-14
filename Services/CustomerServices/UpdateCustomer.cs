using HotelEC.Data;

namespace HotelEC.Services.CustomerServices
{
    public class UpdateCustomer : ICrud
    {
        public ApplicationDbContext dbContext { get; set; }
        public UpdateCustomer(ApplicationDbContext db)
        {
            dbContext = db;
        }


        public void Run() { }

    }
}

