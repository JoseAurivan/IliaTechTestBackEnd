namespace Core
{
    public class Customer
    {
        public Customer()
        {
            
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public ICollection<string>? Orders;

    }
}