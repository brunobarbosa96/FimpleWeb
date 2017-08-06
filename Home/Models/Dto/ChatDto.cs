using Home.Models.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Home.Models.Dto
{
    public class ChatDto
    {
        public ChatDto()
        {
            
        }

        public ChatDto(Usuario usuario, IEnumerable<Mensagem> conversas)
        {
            Usuario = usuario;
            Usuarios = conversas.Select(x => new Mensagem
            {
                UsuarioDestino = x.UsuarioDestino.Id != usuario.Id ? x.UsuarioDestino : x.UsuarioEnvio
            });
        }

        public Usuario Usuario { get; set; }
        public IEnumerable<Mensagem> Conversas { get; set; }
        public IEnumerable<Mensagem> Usuarios { get; set; }

        public int TotalNaoLidas => Conversas.Count(x => !x.DataVisualizacao.HasValue);
    }
}