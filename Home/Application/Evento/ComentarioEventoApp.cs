using Home.Models.Entity;
using System.Net.Http;
using IRequest = Home.Infra.Request.IRequest;
using UriWebApi = Home.Infra.Config.UriWebApi;

namespace Home.Application.Timeline
{
    public class ComentarioEventoApp : IComentarioEventoApp
    {
        private readonly IRequest _request;

        public ComentarioEventoApp(IRequest request)
        {
            _request = request;
        }

        public HttpResponseMessage Post(Comentario comentario)
        {
            return _request.Post($"{UriWebApi.Evento}comentario/", comentario);
        }

        public HttpResponseMessage Put(Comentario comentario)
        {
            return _request.Put($"{UriWebApi.Evento}comentario/", comentario);
        }

        public HttpResponseMessage Delete(int id)
        {
            return _request.Delete($"{UriWebApi.Evento}comentario/", id.ToString());
        }
    }
}