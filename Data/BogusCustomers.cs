using Bogus;
using HotelEC.Models.CustomerModels;

namespace HotelEC.Data
{
    public class BogusCustomers
    {
        public static List<Customer> Create(int customerNum)
        {
            var customerFaker = new Faker<Customer>()
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
                .RuleFor(c => c.PhoneNumber, f => "0" + f.Random.Number(100000000, 999999999));

            return customerFaker.Generate(customerNum);
        }
    }
}
