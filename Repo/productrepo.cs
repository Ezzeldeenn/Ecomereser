using E_commers_project.Data;
using E_commers_project.DTOs;
using E_commers_project.IRepo;
using Microsoft.EntityFrameworkCore;

namespace E_commers_project.Repo
{
    public class productrepo : Iporductrepo
    {
        private readonly AppDbContext _context;
        public productrepo(AppDbContext context)
        {
            _context = context;
        }
        public void Addproduct(productdto productdto)
        {
            var uid = _context.Sellers.Any(s => s.SellerId == productdto.SellerId);
            var product = new Products
            {
                ProductName = productdto.ProductName,
                ProductType = productdto.ProductType,
                Product_price = productdto.Product_price,
                Description = productdto.Description,
                SellerId = productdto.SellerId,
            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Deletproduct(int id)
        {
            var product= _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
               _context.SaveChanges();
            }
        }   

        public  IEnumerable<Products> Getallproduct()
        {
            var user=_context.Products.ToList();
            return user;
        }

        public Products Getproductbyid(int id)
        {
            var product= _context.Products.Find(id);
            if(product != null)
            {
                return product;
            }
            return null;
        }

        public void Updataproduct(productdto productdto, int id)
        {
            var product=_context.Products.Find(id);
            if (product != null)
            {
                product.Product_price = productdto.Product_price;
                product.ProductName= productdto.ProductName;
                product.Description= productdto.Description;
                product.ProductType= productdto.ProductType;
                product.SellerId= productdto.SellerId;
            }
        }
    }
}
