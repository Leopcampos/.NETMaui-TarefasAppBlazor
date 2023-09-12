using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Models.Requests;
using TarefasAppBlazor.Services.Models.Responses;

namespace TarefasAppBlazor.UI.Pages
{
    public partial class CriarConta
    {
        //Definindo o modelo de dados do componente
        private CriarContaRequestModel model = new CriarContaRequestModel();
        //mensagens
        private string? mensagemProcessamento;
        private string? mensagemSucesso;
        private string? mensagemErro;
        //Função para capturar o SUBMIT do formulário
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";
            //Limpar as mensagens
            mensagemSucesso = string.Empty;
            mensagemErro = string.Empty;
            try
            {
                //Fazer a requisição para o serviço de cadastro da API
                var servicesHelper = new ServicesHelper();
                var result = await servicesHelper.Post<CriarContaRequestModel, CriarContaResponseModel>("criarconta", model);
                mensagemSucesso = $"Parabéns {result.Nome}, sua conta de usuário foi cadastrada com sucesso!";
                model = new CriarContaRequestModel();
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