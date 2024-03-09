using CustomerSimulator.Models;

namespace CustomerSimulator.Services
{
    public interface ICustomerService
    {
        public void AddCustomer(Customer customer);

        public List<Customer> GetCustomers();

        public bool CheckCustomerId(Customer customer);
    }
}
