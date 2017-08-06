using System.Net.Http;

namespace Home.Application.Evento
{
    public interface IEventoApp
    {
        HttpResponseMessage GetAll(int idUsuario, int pagina);
        HttpResponseMessage Get(int id);
        HttpResponseMessage Post(Models.Entity.Evento evento);
        HttpResponseMessage Put(Models.Entity.Evento evento);
        HttpResponseMessage Delete(int id);
    }
}