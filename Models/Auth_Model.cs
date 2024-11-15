namespace E_commers_project.Models
{
    public class Auth_Model
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public DateTime Expiretime  { get; set; }
        public string Message{ get; set; }
        public bool isauthonticated { get; set; }
         public string tooken { get; set; }

    }
}
