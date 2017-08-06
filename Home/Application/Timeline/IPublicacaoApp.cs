using Home.Models.Entity;
using System.Net.Http;

namespace Home.Application.Timeline
{
    public interface IPublicacaoApp
    {
        HttpResponseMessage GetAll(int idUsuario, int pagina);
        HttpResponseMessage Get(int id);
        HttpResponseMessage Post(Publicacao publicacao);
        HttpResponseMessage Put(Publicacao publicacao);
        HttpResponseMessage Delete(int id);
    }
}