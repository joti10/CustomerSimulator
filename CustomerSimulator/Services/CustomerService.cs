using CustomerSimulator.Models;
using Newtonsoft.Json;
using System.Text;

namespace CustomerSimulator.Services
{
    public class CustomerService : ICustomerService
    {
        private static List<Customer> _customerData = new List<Customer>();
        private static string fileName = "customerData.json";
        private string filePath = "";
        public CustomerService()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;

            // Specify the file path (combine directory with file name)
            filePath = Path.Combine(directory, fileName);
            if (File.Exists(filePath))
            {
                var customerDataString = File.ReadAllText(filePath);

                if (!string.IsNullOrEmpty(customerDataString))
                    _customerData = JsonConvert.DeserializeObject<List<Customer>>(customerDataString);
            }
        }
        public void AddCustomer(Customer customer)
        {
            _customerData.Add(customer);

            byte[] jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_customerData));

            // Write the bytes to the file
            //File.SetAttributes(filePath, FileAttributes.Normal);
            File.WriteAllBytes(filePath, jsonBytes);
        }

        public List<Customer> GetCustomers()
        {
            return _customerData;
        }

        public bool CheckCustomerId(Customer customer)
        {
            return _customerData.Exists(x => x.Id == customer.Id);
        }
    }
}
