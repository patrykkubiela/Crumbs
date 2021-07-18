using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Crumbs.Api.Controllers
{
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            //TODO: Authenticate user with database
            //if not authenticate return 401 unauthorized
            //else continue with flow below

            //TODO: get claims from db?
            var claims = new List<Claim>
            {
                new Claim("type", "User")
            };

            //TODO: where to store symetric key seed?
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3B*%VbXZ%PWz!4#16q&U?rews$32o623"));

            var token = new JwtSecurityToken("http://localhost:5000", "http://localhost:5000", claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}