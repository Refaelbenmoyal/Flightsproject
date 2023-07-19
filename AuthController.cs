using FlightsProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlightsProjectWeb.Controllers
{
    [FlightsProject.Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public object SecurityAlgorithms { get; private set; }

        [FlightsProject.HttpPost("token")]
        public ActionResult GetToken([FlightsProject.FromBody] UserDetailsDTO userDetails)
        {

            string securityKey =
       "this_is_our_supper_long_security_key_for_token_validation_project_2018_09_07$smesk.in";


            var symmetricSecurityKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));


            var signingCredentials = new
                  SigningCredentials(symmetricSecurityKey,
                  SecurityAlgorithms.HmacSha256Signature);


            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            claims.Add(new Claim("userid", "1"));
            claims.Add(new Claim("username", "admin1"));


            var token = new JwtSecurityToken(
            issuer: "smesk.in",
            audience: "readers",
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials,
            claims: claims);


            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        private Task<ActionResult> Ok(object v)
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            throw new NotImplementedException();
        }
    }
}