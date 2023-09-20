using EasyBank.Models;
using EasyBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyBank.Controllers
{

    [Route("[controller]"), ApiController]
    public class Auth : ControllerBase
    {
        private readonly JwtManager _jwtManager;
        private readonly DataContext _db;

        public Auth(DataContext db, JwtManager jwtManager)
        {
            _db = db;
            _jwtManager = jwtManager;
        }

        [HttpGet("SendCode"), AllowAnonymous]
        public async Task<ActionResult<string>> SendCode(string phone)
        {
            var code = new Random().Next(100000, 1000000);
            var found = _db.Employees.FirstOrDefault(v => v.Phone == phone);
            if (found == null)
            {
                return BadRequest("Phone not found");
            }
            else if (found.Attempts > 0)
            {
                found.Code = code;
                found.Expires = DateTime.UtcNow.AddMinutes(3);
                found.Attempts -= 1;
            }
            else if (found.Attempts == 0 && (DateTime.UtcNow - found.Expires).Days >= 1)
            {
                found.Code = code;
                found.Expires = DateTime.UtcNow.AddMinutes(3);
                found.Attempts = 9;
            }
            else
            {
                return BadRequest("Too many attempts");
            }
            await _db.SaveChangesAsync();
            return Ok("Your confirmation code: " + code);
        }

        [HttpGet("Сonfirm"), AllowAnonymous]
        public async Task<ActionResult<string>> Сonfirm(string phone, int code)
        {
            var found = _db.Employees.FirstOrDefault(x => x.Phone == phone);
            if (found == null)
            {
                return BadRequest("Phone not found");
            }
            else if (found.Attempts <= 0)
            {
                return BadRequest("Too many attempts! Try again tomorrow");
            }
            else if (found.Code != code)
            {
                found.Attempts -= 1;
                await _db.SaveChangesAsync();
                return BadRequest("Code is not correct");
            }
            else
            {
                found.Attempts = 10;
                await _db.SaveChangesAsync();
                return Ok(_jwtManager.CreateAccessToken(found));
            }
        }
    }
}