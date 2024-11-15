using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commers_project.Data
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Product_price { get; set; }
        public string ProductType { get; set; }

        public List<User_products>user_Products { get; set; }
        //   public List<Users>Users { get; set; }

        [ForeignKey(nameof(Sellers))]
        public int SellerId { get; set; }
        public Sellers Sellers { get; set; }
    }
}
