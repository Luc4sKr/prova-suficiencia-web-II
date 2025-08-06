namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
