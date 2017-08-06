using System.Net.Http;
using IRequest = Home.Infra.Request.IRequest;
using UriWebApi = Home.Infra.Config.UriWebApi;

namespace Home.Application.Notificacao
{
    public class NotificacaoApp : INotificacaoApp
    {
        private readonly IRequest _request;

        public NotificacaoApp(IRequest request)
        {
            _request = request;
        }

        public HttpResponseMessage Get(int idUsuario)
        {
            return _request.Get($"{UriWebApi.Notificacao}{idUsuario}");
        }

        public HttpResponseMessage Post(Models.Entity.Notificacao notificacao)
        {
            return _request.Post(UriWebApi.Notificacao, notificacao);
        }

        public HttpResponseMessage Put(Models.Entity.Notificacao notificacao)
        {
            return _request.Put(UriWebApi.Notificacao, notificacao);
        }

        public HttpResponseMessage Delete(int id)
        {
            return _request.Delete(UriWebApi.Notificacao, id.ToString());
        }
    }
}