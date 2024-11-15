using E_commers_project.DTOs;
using E_commers_project.IRepo;
using E_commers_project.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace E_commers_project.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Iuserrepo _userrepo;
        private readonly IConfiguration _configure;
    
        public UserController(Iuserrepo userrepo, IConfiguration configuration)
        {
            _userrepo = userrepo;
            _configure = configuration;
        }

        [HttpGet]
        public IActionResult Getall()
        {
            var user= _userrepo.Getallusers();
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user= _userrepo.Getuserbyid(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public  IActionResult AddUser(userdto userdto)
        {
            if (userdto.UserName != "Ezz" || userdto.UserPassword != "Ezz123#"||userdto.UserPassword==userdto.User_comfarm_pass)
            {
                return Unauthorized();
            }

            _userrepo.Adduser(userdto);

            var token = GenerateJwtToken(userdto.UserName);
             return Ok(new { token });
        }

        private string GenerateJwtToken(string username)
        {
            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configure["Jwt:Key"])); 
            var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: _configure["Jwt:Issuer"],
                audience: _configure["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, username) },
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configure["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPut("{id}")]
        public IActionResult Updateuser(int id,userdto userdto)
        {
           _userrepo.Updateuser(userdto, id);
           return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteuser(int id)
        {
           _userrepo.Deletuser(id);
           return Ok();
        }

    }
}
