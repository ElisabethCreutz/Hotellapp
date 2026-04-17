namespace HotelEC.Models.CustomerModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        //public CustomerAddress Address { get; set; }
        //public InvoiceAddress InvoiceAddress { get; set; }
    }
}
