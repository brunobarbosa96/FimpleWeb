using System.Net.Http;

namespace Home.Application.Notificacao
{
    public interface INotificacaoApp
    {
        HttpResponseMessage Get(int idUsuario);
        HttpResponseMessage Post(Models.Entity.Notificacao notificacao);
        HttpResponseMessage Put(Models.Entity.Notificacao notificacao);
        HttpResponseMessage Delete(int id);
    }
}