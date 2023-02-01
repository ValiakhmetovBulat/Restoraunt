using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace Restoraunt.Models.Bases
{
    public abstract class BaseHttpService
    {
        private readonly HttpClient _httpClient;

        protected BaseHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromMinutes(2);
        }

        protected abstract string BasePath { get; }

        private static HttpContent CreateContent(object model)
        {
            if (model is HttpContent cont)
                return cont;

            var content = new ByteArrayContent(model == null
                ? Array.Empty<byte>()
                : Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            content.Headers.ContentEncoding.Add("UTF-8");
            return content;
        }

        private static HttpRequestMessage CreateMessage(string uri, HttpMethod method, object model)
        {
            var message = new HttpRequestMessage(method, uri);
            if (method != HttpMethod.Post && method != HttpMethod.Put)
                return message;

            message.Content = CreateContent(model);
            return message;
        }

        protected async Task<BaseResponce<T>> SendAsync<T>(string action, HttpMethod method, object model = null) where T : class, new()
        {
            try
            {
                var uri = $"{BasePath}/{action}";
                var message = CreateMessage(uri, method, model);
                var responce = await _httpClient.SendAsync(message);
                if (responce.StatusCode == HttpStatusCode.NoContent)
                    return new BaseResponce<T>();

                var content = await responce.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<BaseResponce<T>>(content);

                if (res == null)
                    return new BaseResponce<T>(new T()) { Error = $"Can't convert responce from URI = '{uri}', content returned = '{content}' to type = {typeof(T)} " };

                return res;
            }
            catch (Exception ex)
            {
                return new BaseResponce<T>() { Error = _baseError(ex) };
            }
        }

        private string _baseError(Exception ex)
        {
            return $"Message: {ex.Message}, Inner exception: {ex.InnerException?.Message}";
        }
    }
}
