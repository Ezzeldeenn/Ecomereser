using E_commers_project.DTOs;
using E_commers_project.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commers_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly Isellerrepo _sellerrepo; // Use interface for dependency injection

        public SellerController(Isellerrepo sellerrepo)
        {
            _sellerrepo = sellerrepo;
        }

        [HttpGet]
        public IActionResult Getall()
        {
            var sellers =  _sellerrepo.GetAllSellers();
            return Ok(sellers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var seller = _sellerrepo.GetSellersbyid(id);
            if (seller == null)
            {
                return NotFound();
            }
            return Ok(seller);
        }

        [HttpPost]
        public IActionResult Addseller(sellerdto sellerdto)
        {
            _sellerrepo.Addseller(sellerdto);
            return Ok(); // Return appropriate response
        }
        //  [AllowAnonymous] that make the pepole to access on this funcition with out any authontication

        /*
         if (!ModelState.IsValid)
            {
                return BadRequest();
            } 
         */

        [HttpPut("{id}")]
        public IActionResult Updateseller(int id, sellerdto sellerdto)
        {
             _sellerrepo.Updateserller(sellerdto, id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(); // Return appropriate response
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteseller(int id)
        {
             _sellerrepo.Deleteserller(id);
            return Ok(); // Return appropriate response
        }
    }
}
