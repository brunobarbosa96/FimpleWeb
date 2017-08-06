using System;

namespace Home.Models.Entity
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public Usuario Usuario { get; set; }
        public Publicacao Publicacao { get; set; }
        public Evento Evento { get; set; }

        public DateTime updatedAt { get; set; }
    }
}