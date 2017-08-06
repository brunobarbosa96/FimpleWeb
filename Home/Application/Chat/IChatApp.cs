using Home.Models.Entity;
using System.Net.Http;

namespace Home.Application.Chat
{
    public interface IChatApp
    {
        HttpResponseMessage Get(int idUsuarioEnvio, int idUsuarioDestino, int pagina);
        HttpResponseMessage GetConversas(int idUsuario);
        HttpResponseMessage Post(Mensagem mensagem);
        HttpResponseMessage Put(Mensagem mensagem);
    }
}