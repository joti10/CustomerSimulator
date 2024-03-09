using CustomerSimulator.Models;

namespace CustomerSimulator.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
        public Customer ToDomain()
        {
            return new Customer(Id, FirstName, LastName, Age);
        }
    }
}
