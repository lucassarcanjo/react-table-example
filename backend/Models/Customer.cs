namespace Backend.Models
{
    public class Customer
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }

        public Customer()
        {
            
        }

        public Customer(string name, Address address, string phone)
        {
          Name = name;
          Address = address;
          Phone = phone;
        }
    }
}