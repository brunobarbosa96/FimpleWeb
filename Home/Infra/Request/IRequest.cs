using System.Net.Http;

namespace Home.Infra.Request
{
    public interface IRequest
    {
        HttpResponseMessage Get(string uri, string parameters = "");
        HttpResponseMessage Post<T>(string uri, T form, string parameters = "");
        HttpResponseMessage Put<T>(string uri, T form, string parameters = "");
        HttpResponseMessage Delete(string uri, string parameters = "");
    }
}