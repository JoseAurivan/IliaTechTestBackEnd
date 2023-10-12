using Core.Validations;

namespace Core
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public Customer(int customerId, string name, string email)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Order>? Orders { get; set; }

    }
}