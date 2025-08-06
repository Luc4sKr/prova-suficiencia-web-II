namespace Domain.Models
{
    public class Comanda
    {
        public int Id { get; set; }

        public virtual User User { get; set; }
        public virtual ComandaProduto ComandaProduto { get; set; }
    }
}
