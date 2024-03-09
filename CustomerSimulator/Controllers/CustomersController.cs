using CustomerSimulator.Dtos;
using CustomerSimulator.Models;
using CustomerSimulator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CustomerSimulator.Controllers
{
    public class CustomersController : ControllerBase
    {

        // GET: CustomersController/
        [HttpGet]
        //[Route("api/customers")]
        public ActionResult GetCustomers()
        {
            return Ok();
        }

        // POST: CustomersController/CreateCustomers
        [HttpPost]
        [Route("api/customers")]
        public ActionResult CreateCustomers([FromBody] List<CustomerDto> customerRequestList)
        {
            if (customerRequestList == null)
                return BadRequest("request data not provided");

            var errors = processCustomerRequestData(customerRequestList);

            if (errors.Any())
                return BadRequest(errors.ToString());

            return Ok();
        }

        private List<string> processCustomerRequestData(List<CustomerDto> customerDataSet)
        {
            List<Customer> customerList = new List<Customer>();
            List<string> Errors = new List<string>();
            foreach (var customer in customerDataSet)
            {
                try
                {
                    customerList.Add(new Customer(customer.Id, customer.FirstName, customer.LastName, customer.Age));
                }
                catch (Exception ex)
                {
                    Errors.Add(ex.Message);
                    continue;
                }
            }
            return Errors;
        }
    }
}
