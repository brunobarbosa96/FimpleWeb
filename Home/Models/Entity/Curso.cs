namespace Home.Models.Entity
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
    }
}