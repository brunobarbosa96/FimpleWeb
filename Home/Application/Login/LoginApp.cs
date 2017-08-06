using System.Net.Http;
using IRequest = Home.Infra.Request.IRequest;
using UriWebApi = Home.Infra.Config.UriWebApi;

namespace Home.Application.Login
{
    public class LoginApp : ILoginApp
    {
        private readonly IRequest _request;

        public LoginApp(IRequest request)
        {
            _request = request;
        }

        public HttpResponseMessage Post(Models.Entity.Usuario usuario)
        {
            return _request.Post(UriWebApi.Login, usuario);
        }
    }
}