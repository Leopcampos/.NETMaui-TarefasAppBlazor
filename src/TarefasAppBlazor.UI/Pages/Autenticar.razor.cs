using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Models.Requests;
using TarefasAppBlazor.Services.Models.Responses;

namespace TarefasAppBlazor.UI.Pages
{
    public partial class Autenticar
    {
        //Definindo o modelo de dados do componente
        private AutenticarRequestModel model = new AutenticarRequestModel();

        //mensagens
        private string? mensagemProcessamento;
        private string? mensagemSucesso;
        private string? mensagemErro;

        //Função para capturar o SUBMIT do formulário
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";

            //limpar as mensagens
            mensagemSucesso = string.Empty;
            mensagemErro = string.Empty;

            try
            {
                //fazendo a requisição para o serviço de cadastro da API
                var servicesHelper = new ServicesHelper();
                var result = await servicesHelper.Post<AutenticarRequestModel, AutenticarResponseModel>("autenticar", model);

                mensagemSucesso = $"Parabéns {result.Nome}, autenticação realizada com sucesso!";
                model = new AutenticarRequestModel();
            }
            catch (Exception e)
            {
                mensagemErro = e.Message;
            }
            finally
            {
                mensagemProcessamento = string.Empty;
            }
        }
    }
}