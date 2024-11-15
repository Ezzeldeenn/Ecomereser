namespace E_commers_project.Jwt
{
    public class Jwt
    {
        public string  Audience { get; set; }
        public string ExpiresInMinutes { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
    }
}
