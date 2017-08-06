using System.Net.Http;
using IRequest = Home.Infra.Request.IRequest;
using UriWebApi = Home.Infra.Config.UriWebApi;

namespace Home.Application.Curso
{
    public class CursoApp : ICursoApp
    {
        private readonly IRequest _request;

        public CursoApp(IRequest request)
        {
            _request = request;
        }

        public HttpResponseMessage GetAll()
        {
            return _request.Get(UriWebApi.Curso);
        }
    }
}