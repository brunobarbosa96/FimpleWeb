using Home.Models.Entity;
using System.Net.Http;
using IRequest = Home.Infra.Request.IRequest;
using UriWebApi = Home.Infra.Config.UriWebApi;

namespace Home.Application.Chat
{
    public class ChatApp : IChatApp
    {
        private readonly IRequest _request;

        public ChatApp(IRequest request)
        {
            _request = request;
        }

        public HttpResponseMessage Get(int idUsuarioEnvio, int idUsuarioDestino, int pagina)
        {
            return _request.Get($"{UriWebApi.Chat}{idUsuarioEnvio}/?UsuarioDestino={idUsuarioDestino}&Pagina={pagina}");
        }

        public HttpResponseMessage GetConversas(int idUsuario)
        {
            return _request.Get($"{UriWebApi.Chat}conversa/{idUsuario}");
        }

        public HttpResponseMessage Post(Mensagem mensagem)
        {
            return _request.Post(UriWebApi.Chat, mensagem);
        }

        public HttpResponseMessage Put(Mensagem mensagem)
        {
            return _request.Put(UriWebApi.Chat, mensagem);
        }
    }
}