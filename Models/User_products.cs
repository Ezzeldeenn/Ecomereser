using System.ComponentModel.DataAnnotations;

namespace E_commers_project.Data
{
    public class User_products
    {
        [Key]
        public int Userid {  get; set; }
        public Users users { get; set; }

        [Key]
        public int Productid { get; set; }
        public Products products { get; set; }

    }
}
