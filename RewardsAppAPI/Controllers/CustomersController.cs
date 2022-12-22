using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RewardsAppAPI.Data;
using RewardsAppAPI.Models;

namespace RewardsAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly RewardsDbContext _rewardsDbContext;
        public CustomersController(RewardsDbContext rewardsDbContext) 
        {
            _rewardsDbContext = rewardsDbContext;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _rewardsDbContext.Customers.ToListAsync();

            return Ok(customers);
            
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody]Customer customerRequest)
        {
            customerRequest.Id = Guid.NewGuid();
            await _rewardsDbContext.Customers.AddAsync(customerRequest);
            await _rewardsDbContext.SaveChangesAsync();

            return Ok(customerRequest);


        }
    }
}
