using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace Home.Infra.Request
{
    public class Request : IRequest
    {
        private readonly HttpClient _httpClient;

        public Request()
        {
            _httpClient = new HttpClient();
        }

        public HttpResponseMessage Get(string uri, string parameters = "")
        {
            try
            {
                return _httpClient.GetAsync($"{uri}{parameters}").Result;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new ObjectContent(ex.GetType(), ex, JsonMediaTypeFormatter)
                };
            }
        }

        public HttpResponseMessage Post<T>(string uri, T form, string parameters = "")
        {
            try
            {
                return _httpClient.PostAsync($"{uri}{parameters}", form, JsonMediaTypeFormatter).Result;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new ObjectContent(ex.GetType(), ex, JsonMediaTypeFormatter)
                };
            }
        }

        public HttpResponseMessage Put<T>(string uri, T form, string parameters = "")
        {
            try
            {
                return _httpClient.PutAsync($"{uri}{parameters}", form, JsonMediaTypeFormatter).Result;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new ObjectContent(ex.GetType(), ex, JsonMediaTypeFormatter)
                };
            }
        }

        public HttpResponseMessage Delete(string uri, string parameters = "")
        {
            try
            {
                return _httpClient.DeleteAsync($"{uri}{parameters}").Result;

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
                {
                    Content = new ObjectContent(ex.GetType(), ex, JsonMediaTypeFormatter)
                };
            }
        }

        private static readonly JsonMediaTypeFormatter JsonMediaTypeFormatter = new JsonMediaTypeFormatter
        {
            SerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            }
        };
    }
}
