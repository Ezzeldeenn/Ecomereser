using System.ComponentModel.DataAnnotations;

namespace E_commers_project.Data
{
    public class Sellers
    {
        [Key]
        public int SellerId { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Seller name should between 3 to 30 chars"), RegularExpression(@"^(?=.*[a-z])(?=.@[A-Z])(?=.*[\d])(?=.*[A-Za-z\d]){8,}$")]
        public string SellerName { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\d])(?=.*[!@#$%^&*+-]){8,}$")] //regex password
        //[a-z] small char , [A-Z] Capital char ,[\d] digets , {8,} have 8 field
        public string SellerPassword { get; set; }
        [Compare("SellerPassword", ErrorMessage = "Seller comfirm password not mathing with password")]
        public string Seller_comfarm_pass { get; set; }
        [CreditCard]
        public string Seller_creadcard { get; set; }
        [EmailAddress(ErrorMessage = "The email not valid")]
        public string SellerEmail { get; set; }
        [Phone(ErrorMessage = "Your phone number less than 11")]
        public string Sellerphone { get; set; }

        public string Seller_type { get; set; }


        //Relation
        public List<Products> Products { get; set; }    
       // public List<Users> Users { get; set; }
        public List<Users_Sellers> User_sellers { get; set; }
    }
}
