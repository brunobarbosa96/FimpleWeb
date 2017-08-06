using System.Net.Http;
using IRequest = Home.Infra.Request.IRequest;
using UriWebApi = Home.Infra.Config.UriWebApi;

namespace Home.Application.Evento
{
    public class EventoApp : IEventoApp
    {
        private readonly IRequest _request;

        public EventoApp(IRequest request)
        {
            _request = request;
        }

        public HttpResponseMessage GetAll(int idUsuario, int pagina)
        {
            return _request.Get($"{UriWebApi.Evento}{idUsuario}?Pagina={pagina}");
        }

        public HttpResponseMessage Get(int id)
        {
            return _request.Get(UriWebApi.Evento, id.ToString());
        }

        public HttpResponseMessage Post(Models.Entity.Evento evento)
        {
            return _request.Post(UriWebApi.Evento, evento);
        }

        public HttpResponseMessage Put(Models.Entity.Evento evento)
        {
            return _request.Put(UriWebApi.Evento, evento);
        }

        public HttpResponseMessage Delete(int id)
        {
            return _request.Delete(UriWebApi.Evento, id.ToString());
        }
    }
}