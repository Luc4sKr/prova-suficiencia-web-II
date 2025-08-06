namespace Domain.DTOs
{
    public class CreateUserRequest
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
