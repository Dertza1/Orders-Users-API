using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShoppingCenter.Database;
using ShoppingCenter.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static ShoppingCenter.Program;

namespace ShoppingCenter.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ShopContext _context;
        public UserController(ShopContext context) => _context = context;
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsers([FromQuery] string? filter)
        {
            var usersQuery = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(filter)) usersQuery = usersQuery.Where(w => w.Fio.ToLower() == filter.ToLower());
            var users = await usersQuery.Select(t => new UserDto() { Fio = t.Fio, Login = t.Login, Password = t.Password }).ToListAsync();
            return Ok(users);
        }


        #region HttpPost
        [HttpPost]
        [Authorize]

        public async Task<IActionResult> PostUsers([FromBody] UserDto userDto)
        {
            if (userDto == null) BadRequest();
            var user = new User() { Fio = userDto.Fio, Login = userDto.Login, Password = userDto.Password };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
        #endregion


        #region HttpLogin
        [HttpGet("{login}")]
        public async Task<IActionResult> LoginUser(string? login, [FromQuery] string? password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) return BadRequest();
            var userinfo = _context.Users.Where(w => w.Login == login && w.Password == password).SingleOrDefault();

            if (userinfo == null) return BadRequest();

            var claims = new List<Claim>
            { 
                new Claim(ClaimTypes.Name, userinfo.Fio), 
                new Claim("Id", userinfo.Id.ToString())
            };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(120)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return Ok($"Bearer {new JwtSecurityTokenHandler().WriteToken(jwt)}");
        }
        #endregion
    }
}
