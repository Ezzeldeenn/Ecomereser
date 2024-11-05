using E_commers_project.Data;
using E_commers_project.DTOs;
using E_commers_project.IRepo;
using Microsoft.EntityFrameworkCore;

namespace E_commers_project.Repo
{
    public class SellerRepo : Isellerrepo
    {
        private readonly AppDbContext _context;

        public SellerRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Addseller(sellerdto sellerdto)
        {
            var seller = new Sellers
            {
                SellerName = sellerdto.SellerName,
                Seller_type = sellerdto.Seller_type,
                Sellerphone = sellerdto.Sellerphone,
                SellerEmail = sellerdto.SellerEmail,
                Seller_creadcard = sellerdto.Seller_creadcard,
                SellerPassword = sellerdto.SellerPassword,
                Seller_comfarm_pass=sellerdto.Seller_comfarm_pass,
            };
            _context.Sellers.Add(seller);
             _context.SaveChanges();
        }

        public void Deleteserller(int id)
        {
            var seller =  _context.Sellers.Find(id);
            if (seller != null)
            {
                _context.Sellers.Remove(seller);
                _context.SaveChanges();
            }
        }

        public  IEnumerable<Sellers> GetAllSellers()
        {
            return  _context.Sellers.ToList();
        }

        public Sellers GetSellersbyid(int id)
        {
            var user=  _context.Sellers.FirstOrDefault(x=>x.SellerId==id);
            return user;
        }

        public void Updateserller(sellerdto sellerdto, int id)
        {
            var seller =  _context.Sellers.Find(id);
            if (seller != null)
            {
                seller.SellerEmail = sellerdto.SellerEmail;
                seller.Sellerphone = sellerdto.Sellerphone;
                seller.Seller_type = sellerdto.Seller_type;
                seller.SellerName = sellerdto.SellerName;
                seller.SellerPassword = sellerdto.SellerPassword;
                seller.Seller_comfarm_pass=sellerdto.Seller_comfarm_pass;
                 _context.SaveChanges(); // Save changes after update
            }
        }
    }
}
