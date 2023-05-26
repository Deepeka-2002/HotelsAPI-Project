using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsAPI.Models;
using HotelsAPI.Repository.Customers;
using HotelsAPI.Repository.Hotel;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authorization;

namespace HotelsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo customerRepo;

        public CustomersController(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        // GET: api/Customers
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Getcustomers()
        {
            var customers = await customerRepo.GetCustomers();
            return Ok(customers);
        }


        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            try
            {
                var customer = await customerRepo.GetCustomerById(id);
                return Ok(customer);
            }

            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(int id, Customer cust)
        {

            try
            {
                var customer = await customerRepo.UpdateCustomer(id, cust);
                return Ok(customer);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer cust)
        {
            var customer = await customerRepo.AddCustomer(cust);
            return Ok(customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomerById(int id)
        {
            try
            {
                var customer = await customerRepo.DeleteCustomerById(id);
                return Ok(customer);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("LocationFilter")]
        public IEnumerable<Hotels> SearchHotelLocation(string location)
        {
            return customerRepo.SearchHotelLocation(location);
        }

        [HttpGet("RoomPriceFilter")]
        public IEnumerable<Rooms> RoomPriceLimit(int price)
        {
            return customerRepo.RoomPriceLimit(price);
        }

        [HttpGet("RoomTypeFilter")]
       
        public IEnumerable<Rooms> FilterRoomType(string type)
        {
            return customerRepo.FilterRoomType(type);
        }
    
    }

}
