using System;

namespace Home.Models.Entity
{
    public class Notificacao
    {
        public int Id { get; set; }
        public DateTime? DataVisualizacao { get; set; }
        public Usuario Usuario { get; set; }
        public Evento Evento { get; set; }
        public Publicacao Publicacao { get; set; }
        public Curso Curso { get; set; }
        public Entidade Entidade { get; set; }
        public Categoria Categoria { get; set; }
    }
}