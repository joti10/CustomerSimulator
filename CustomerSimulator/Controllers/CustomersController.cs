using CustomerSimulator.Dtos;
using CustomerSimulator.Models;
using CustomerSimulator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CustomerSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        //TODO:Add Logging
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #region EndPoint to Get Customer Data
        // GET: CustomersController/
        [HttpGet]
        [Route("api/customers")]
        public ActionResult GetCustomers()
        {
            try
            {
                var customersList = _customerService.GetCustomers();

                return Ok(customersList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
        #region EndPoint to Post Customer Data Request
        // POST: CustomersController/CreateCustomers
        [HttpPost]
        [Route("api/customers")]
        public ActionResult CreateCustomers([FromBody] List<CustomerDto> customersDtoData)
        {
            //Check for bad request sent :
            if (customersDtoData == null)
            {
                return BadRequest();
            }

            try
            {
                var customers = processCustomerRequestData(customersDtoData);

                foreach (var customer in customers)
                {
                    //Check if Id already exists
                    if (!_customerService.CheckCustomerId(customer))
                        _customerService.AddCustomer(customer);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Created("", null);
        }
        #endregion
        #region Process Request Data and return bad requests responses
        private List<Customer> processCustomerRequestData(List<CustomerDto> customersDtoData)
        {
            var customers = new List<Customer>();
            var NumberOfCustomers = customersDtoData.Count;

            for (int index = 0; index < NumberOfCustomers; index++)
            {
                try
                {
                    var customerDto = customersDtoData[index];
                    customers.Add(customerDto.ToDomain());

                    return customers;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Invalid data found in request data at index {index + 1} , Details : {ex.Message}");
                }
            }

            return customers;
        }
        #endregion
    }
}
