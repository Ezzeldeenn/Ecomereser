using E_commers_project.DTOs;
using E_commers_project.IRepo;
using E_commers_project.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commers_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Iporductrepo _productrepo;

        public ProductController(Iporductrepo productrepo)
        {
            _productrepo = productrepo;
        }

        [HttpGet]
        public IActionResult Getall()
        {
            var products =  _productrepo.Getallproduct();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user =_productrepo.Getproductbyid(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Addproduct(productdto productdto)
        {
             _productrepo.Addproduct(productdto);
           return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Updateproduct(int id, productdto productdto)
        {
            _productrepo.Updataproduct(productdto, id);
           return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deleteuser(int id)
        {
            _productrepo.Deletproduct(id);
           return Ok();
        }

    }
}
