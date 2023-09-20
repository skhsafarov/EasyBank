using EasyBank.Models;
using EasyBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyBank.Controllers
{
    [Route("[controller]"), ApiController]
    public class History : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ActionLogger _actionLogger;
        public History(DataContext context, ActionLogger actionLogger, IHttpContextAccessor httpContextAccessor)
        {
            _db = context;
            _actionLogger=actionLogger;
            var path = httpContextAccessor.HttpContext?.Request.Path.Value?.Split('/');
            _actionLogger.Controller = path[1];
            _actionLogger.Action = path[2];
            _actionLogger.Id = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? "";
        }

        [HttpGet("ReadAll"), Authorize(Roles = "Administrator, Employee")]
        public async Task<ActionResult<IEnumerable<Transaction>>> ReadAll()
        {
            if (_db.Transactions == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            await _actionLogger.LogAsync("Ok");
            return await _db.Transactions.ToListAsync();
        }

        [HttpGet("Read"), Authorize(Roles = "Administrator, Employee")]
        public async Task<ActionResult<Transaction>> Read(int id)
        {
            if (_db.Transactions == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            var transaction = await _db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            await _actionLogger.LogAsync("Ok");
            return transaction;
        }
    }
}
