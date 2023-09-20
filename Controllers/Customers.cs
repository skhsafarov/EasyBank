using EasyBank.Models;
using EasyBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyBank.Controllers
{
    [Route("[controller]"), ApiController]
    public class Customers : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ActionLogger _actionLogger;
        public Customers(DataContext db, ActionLogger actionLogger, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _actionLogger=actionLogger;
            var path = httpContextAccessor.HttpContext?.Request.Path.Value?.Split('/');
            _actionLogger.Controller = path[1];
            _actionLogger.Action = path[2];
            _actionLogger.Id = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type=="id")?.Value??"";
        }
        [HttpPost("Create"), Authorize(Roles = "Administrator, Employee")]
        public async Task<ActionResult<Customer>> Carete(Customer customer)
        {
            if (_db.Customers == null)
            {
                await _actionLogger.LogAsync("Entity set 'DataContext.Customer'  is null.");
                return Problem("Entity set 'DataContext.Customer'  is null.");
            }
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            await _actionLogger.LogAsync("Created");
            return CreatedAtAction("GetCustomers", new { id = customer.Id }, customer);
        }
        [HttpGet("ReadAll"), Authorize(Roles = "Administrator, Employee")]
        public async Task<ActionResult<IEnumerable<Customer>>> ReadAll()
        {
            if (_db.Customers == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            await _actionLogger.LogAsync("Ok");
            return await _db.Customers.ToListAsync();
        }
        [HttpGet("Read"), Authorize(Roles = "Administrator, Employee")]
        public async Task<ActionResult<Customer>> Read(int id)
        {
            if (_db.Customers == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            var customer = await _db.Customers.FindAsync(id);
            if (customer == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            return customer;
        }
        [HttpPut("Update"), Authorize(Roles = "Administrator, Employee")]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                await _actionLogger.LogAsync("BadRequest");
                return BadRequest();
            }
            _db.Entry(customer).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_db.Customers?.Any(e => e.Id == id)).GetValueOrDefault())
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await _actionLogger.LogAsync("Ok");
            return NoContent();
        }
        [HttpDelete("Delete"), Authorize(Roles = "Administrator, Employee")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_db.Customers == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            var customer = await _db.Customers.FindAsync(id);
            if (customer == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            await _actionLogger.LogAsync("Ok");
            return NoContent();
        }
    }
}
