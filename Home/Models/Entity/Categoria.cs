namespace Home.Models.Entity
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Entidade Entidade { get; set; }
    }
}