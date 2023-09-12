using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TarefasAppBlazor.Services.Settings;

namespace TarefasAppBlazor.Services.Helpers
{
    /// <summary>
    /// Classe para implementarmos os tipos de requisições HTTP
    /// que poderão ser feitas para a API (POST, PUT, DELETE, GET etc)
    /// </summary>
    public class ServicesHelper
    {
        private AuthenticationHeaderValue? _authenticationHeaderValue;

        public ServicesHelper()
        { }

        public ServicesHelper(string accessToken)
        {
            _authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        /// <summary>
        /// Método genérico para requisições do tipo POST
        /// </summary>
        public async Task<TResponse> Post<TRequest, TResponse>(string endpoint, TRequest request)
        {
            //Serializar os dados da requisição em JSON
            var content = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                if (_authenticationHeaderValue != null)
                    httpClient.DefaultRequestHeaders.Authorization = _authenticationHeaderValue;

                //Fazendo a requisição para a API
                var result = await httpClient.PostAsync($"{AppSettings.BaseUrl}{endpoint}", content);
                var response = GetResponse(result);

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<TResponse>(response);
                else
                {
                    var error = JsonConvert.DeserializeObject<ErrorResult>(response);
                    throw new Exception(error.Message);
                }
            }
        }

        /// <summary>
        /// Método genérico para requisições do tipo GET
        /// </summary>
        public async Task<TResponse> Get<TResponse>(string endpoint)
        {
            using (var httpClient = new HttpClient())
            {
                if (_authenticationHeaderValue != null)
                    httpClient.DefaultRequestHeaders.Authorization = _authenticationHeaderValue;

                //Fazendo a requisição para a API
                var result = await httpClient.GetAsync($"{AppSettings.BaseUrl}{endpoint}");
                var response = GetResponse(result);

                return JsonConvert.DeserializeObject<TResponse>(response);
            }
        }

        private string GetResponse(HttpResponseMessage result)
        {
            //Lendo a resposta obtida da API
            var builder = new StringBuilder();
            using (var r = result.Content)
            {
                Task<string> task = r.ReadAsStringAsync();
                builder.Append(task.Result);
            }
            return builder.ToString();
        }
    }

    /// <summary>
    /// Classe para deserializar resposta de erro
    /// </summary>
    public class ErrorResult
    {
        public string? Message { get; set; }
    }
}