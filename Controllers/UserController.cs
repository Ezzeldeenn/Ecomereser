using E_commers_project.DTOs;
using E_commers_project.IRepo;
using E_commers_project.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace E_commers_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Iuserrepo _userrepo;

        public UserController(Iuserrepo userrepo)
        {
            _userrepo = userrepo;
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
            _userrepo.Adduser(userdto);
             return Ok();
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
