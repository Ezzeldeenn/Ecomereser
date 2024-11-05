using System.ComponentModel.DataAnnotations;

namespace E_commers_project.Data
{
    public class Users_Sellers
    {
        [Key]
        public int UserId { get; set; }
        public Users users { get; set; }

        [Key]
        public int Sellerid { get; set; }
        public Sellers sellers { get; set; }
    }
}
