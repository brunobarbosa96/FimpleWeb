using System;
using System.Collections.Generic;

namespace Home.Models.Entity
{
    public class Conversa
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }
        public Usuario Remetente { get; set; }
        public Usuario Destino { get; set; }
        public IEnumerable<Mensagem> Mensagens { get; set; }
    }
}