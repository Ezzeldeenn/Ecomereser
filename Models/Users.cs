using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_commers_project.Data
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "User name should between 3 to 30 chars"),RegularExpression(@"^(?=.*[a-z])(?=.@[A-Z])(?=.*[\d])(?=.*[A-Za-z\d]){8,}$")]
        public string UserName { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\d])(?=.*[!@#$%^&*]){8,}$")] //regex password
        //[a-z] small char , [A-Z] Capital char ,[\d] digets , {8,} have 8 field
        public string UserPassword { get; set; }
        [Compare("UserPassword",ErrorMessage ="User comfirm password not mathing with password")]
        public string User_comfarm_pass {  get; set; }
        [CreditCard]
        public string User_creadcard {  get; set; }
        [EmailAddress(ErrorMessage ="The email not valid")]
        public string UserEmail { get; set; }
        [Phone(ErrorMessage ="Your phone number less than 11")]
        public int Userphone { get; set; }

        public List<User_products> User_products { get; set; }
        public List<Users_Sellers> User_sellers { get; set;}

    //    public List<Products> Products { get; set; }
    //    public List<Sellers> Sellers { get; set; }

    }
}
