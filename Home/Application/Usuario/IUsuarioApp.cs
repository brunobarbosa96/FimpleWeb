using System.Net.Http;

namespace Home.Application.Usuario
{
    public interface IUsuarioApp
    {
        HttpResponseMessage GetAll();
        HttpResponseMessage Get(int id);
        HttpResponseMessage GetUsuarioBloqueado(int id);
        HttpResponseMessage Post(Models.Entity.Usuario usuario);
        HttpResponseMessage Put(Models.Entity.Usuario usuario);
        HttpResponseMessage PutSenha(Models.Entity.Usuario usuario);
        HttpResponseMessage Delete(int id);
    }
}