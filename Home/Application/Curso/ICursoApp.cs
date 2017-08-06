using System.Net.Http;

namespace Home.Application.Curso
{
    public interface ICursoApp
    {
        HttpResponseMessage GetAll();
    }
}