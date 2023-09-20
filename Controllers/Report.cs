using EasyBank.Models;
using EasyBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyBank.Controllers
{
    [Route("[controller]"), ApiController, Authorize(Roles = "Administrator, Director")]
    public class Report : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ActionLogger _actionLogger;

        public Report(DataContext db, ActionLogger actionLogger, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _actionLogger = actionLogger;
            var path = httpContextAccessor.HttpContext?.Request.Path.Value?.Split('/');
            _actionLogger.Controller = path[1];
            _actionLogger.Action = path[2];
            _actionLogger.Id = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? "";
        }

        [HttpGet("ReadAll")]
        public async Task<ActionResult<IEnumerable<EmployeeAction>>> ReadAll()
        {
            if (_db.EmployeeActions == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }

            await _actionLogger.LogAsync("Ok");
            return await _db.EmployeeActions.ToListAsync();
        }

        [HttpGet("Read")]
        public async Task<ActionResult<EmployeeAction>> Read(int id)
        {
            if (_db.EmployeeActions == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            var employeeAction = await _db.EmployeeActions.FindAsync(id);

            if (employeeAction == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }

            await _actionLogger.LogAsync("Ok");
            return employeeAction;
        }
    }
}
