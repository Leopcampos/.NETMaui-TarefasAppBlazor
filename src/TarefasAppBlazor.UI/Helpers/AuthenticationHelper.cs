using Blazored.LocalStorage;
using TarefasAppBlazor.Services.Models.Responses;

namespace TarefasAppBlazor.UI.Helpers
{
    /// <summary>
    /// Classe auxiliar para operações relacionadas a autenticação de usuários
    /// </summary>
    public class AuthenticationHelper
    {
        //Atributos
        private readonly ILocalStorageService? _localStorageService;
        private const string _key = "tarefas-app";

        //construtor para injeção de dependência dos atributos
        public AuthenticationHelper(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        //Método para salvar as informações do usuário autenticado em local storage
        public async Task SignIn(AutenticarResponseModel model)
        {
            await _localStorageService.SetItemAsync(_key, model);
        }

        //método para verificar se o usuário está autenticado
        public async Task<bool> IsSigningIn()
        {
            var model = await _localStorageService.GetItemAsync
            <AutenticarResponseModel>(_key);
            return model != null && model.Expiration >= DateTime.Now;
        }

        //método para retornar os dados do usuário autenticado
        public async Task<AutenticarResponseModel> GetUser()
        {
            return await _localStorageService.GetItemAsync<AutenticarResponseModel>(_key);
        }

        //método para realizar o logout do usuário
        public async Task SignOut()
        {
            await _localStorageService.RemoveItemAsync(_key);
        }
    }
}