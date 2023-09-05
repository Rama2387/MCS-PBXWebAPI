using AuthenticationApi.Dtos;
using MCSBusinessLayer;
using MCSDataLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MCSWeb.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserBO userBO;


        IConfiguration configuration;

        public UserController(IAuthenticationService authenticationService,  IConfiguration configuration)
        {
            _authenticationService = authenticationService;
           
            this.configuration = configuration;
            userBO = new UserBO();

        }

        [AllowAnonymous]
        [HttpPost("login")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login([FromBody] LoginRequest user)
        {
            IActionResult response = Unauthorized();
              var lstUsers = userBO.GetAllUsers(SqlQueries.GET_ALL_USERS);

            if (user != null)
            {
                //if (user.Username.Equals("test@gmail.com") && user.Password.Equals("Rama@123"))
                if (user.Username.Equals(lstUsers.Rows[0]["Username"]) && user.Password.Equals(lstUsers.Rows[0]["Password"]))
                {
                    var issuer = configuration["JWT:Issuer"];
                    var audience = configuration["JWT:Audience"];
                    var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
                    var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);
                    var subject = new ClaimsIdentity(new[]
                    { new Claim(JwtRegisteredClaimNames.Sub,user.Username),
                      new Claim(JwtRegisteredClaimNames.Email,user.Username)});

                    var expires = DateTime.UtcNow.AddDays(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);

                }
                else { return Ok("fail"); };

            }
            return response;
        }
    }
}
