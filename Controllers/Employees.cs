using EasyBank.Models;
using EasyBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyBank.Controllers
{
    [Route("[controller]"), ApiController]
    public class Employees : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ActionLogger _actionLogger;
        public Employees(DataContext db, ActionLogger actionLogger, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _actionLogger=actionLogger;
            var path = httpContextAccessor.HttpContext?.Request.Path.Value?.Split('/');
            _actionLogger.Controller = path[1];
            _actionLogger.Action = path[2];
            _actionLogger.Id = httpContextAccessor.HttpContext?.User.Claims?.FirstOrDefault(c => c.Type == "id")?.Value ?? "";
        }

        [HttpPost("Create"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            if (_db.Employees == null)
            {
                await _actionLogger.LogAsync("Entity set is null");
                return Problem("Entity set is null");
            }
            _db.Employees.Add(employee);

            await _actionLogger.LogAsync("Created");
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }
        [HttpGet("ReadAll"), Authorize(Roles = "Administrator, Director")]
        public async Task<ActionResult<IEnumerable<Employee>>> ReadAll()
        {
            if (_db.Employees == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            await _actionLogger.LogAsync("Ok");
            return await _db.Employees.ToListAsync();
        }
        [HttpGet("Read"), Authorize(Roles = "Administrator, Director")]
        public async Task<ActionResult<Employee>> Read(int id)
        {
            if (_db.Employees == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            var employee = await _db.Employees.FindAsync(id);

            if (employee == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }

            await _actionLogger.LogAsync("Ok");
            return employee;
        }
        [HttpPut("Update"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                await _actionLogger.LogAsync("BadRequest");
                return BadRequest("_id is not equal to employee._id");
            }

            _db.Entry(employee).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_db.Employees?.Any(e => e.Id == id)).GetValueOrDefault())
                {
                    await _actionLogger.LogAsync("NotFound");
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
        [HttpDelete("Delete"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_db.Employees == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }

            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();

            await _actionLogger.LogAsync("NoContent");
            return NoContent();
        }
    }
}
