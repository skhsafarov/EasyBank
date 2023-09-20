using EasyBank.Models;
using EasyBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyBank.Controllers
{
    [Route("[controller]"), ApiController]
    public class Cards : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ActionLogger _actionLogger;
        public Cards(DataContext db, ActionLogger actionLogger, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _actionLogger=actionLogger;
            var path = httpContextAccessor.HttpContext?.Request.Path.Value?.Split('/');
            _actionLogger.Controller = path[1];
            _actionLogger.Action = path[2];
            _actionLogger.Id = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? "";
        }

        [HttpPost("Create"), Authorize(Roles = "Administrator, Employee")]
        public async Task<ActionResult<Card>> Create(Card card)
        {
            if (_db.Cards == null)
            {
                await _actionLogger.LogAsync("Entity set 'DataContext.Card'  is null.");
                return Problem("Entity set 'DataContext.Card'  is null.");
            }
            _db.Cards.Add(card);
            await _db.SaveChangesAsync();
            await _actionLogger.LogAsync("Created");
            return CreatedAtAction("GetCard", new { id = card.Id }, card);
        }

        [HttpGet("ReadAll"), Authorize(Roles = "Administrator, Employee")]
        public async Task<ActionResult<IEnumerable<Card>>> ReadAll()
        {
            if (_db.Cards == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            await _actionLogger.LogAsync("Ok");
            return await _db.Cards.ToListAsync();
        }

        [HttpGet("Read"), Authorize(Roles = "Administrator, Employee")]
        public async Task<ActionResult<Card>> Read(int id)
        {
            if (_db.Cards == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            var card = await _db.Cards.FindAsync(id);

            if (card == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            await _actionLogger.LogAsync("Ok");
            return card;
        }

        [HttpPut("Update"), Authorize(Roles = "Administrator, Employee")]
        public async Task<IActionResult> Update(int id, Card card)
        {
            if (id != card.Id)
            {
                await _actionLogger.LogAsync("BadRequest");
                return BadRequest();
            }

            _db.Entry(card).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_db.Cards?.Any(e => e.Id == id)).GetValueOrDefault())
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

        [HttpDelete("Delete"), Authorize(Roles = "Administrator, Employee")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_db.Cards == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            var card = await _db.Cards.FindAsync(id);
            if (card == null)
            {
                await _actionLogger.LogAsync("NotFound");
                return NotFound();
            }
            _db.Cards.Remove(card);
            await _db.SaveChangesAsync();
            await _actionLogger.LogAsync("Removed");
            return NoContent();
        }
    }
}
