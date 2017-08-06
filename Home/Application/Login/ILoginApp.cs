using System.Net.Http;

namespace Home.Application.Login
{
    public interface ILoginApp
    {
        HttpResponseMessage Post(Models.Entity.Usuario usuario);
    }
}