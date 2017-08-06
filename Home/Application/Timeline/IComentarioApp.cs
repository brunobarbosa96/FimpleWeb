using Home.Models.Entity;
using System.Net.Http;

namespace Home.Application.Timeline
{
    public interface IComentarioApp
    {
        HttpResponseMessage Post(Comentario comentario);
        HttpResponseMessage Put(Comentario comentario);
        HttpResponseMessage Delete(int id);
    }
}