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
        //Fun��o para capturar o SUBMIT do formul�rio
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";
            //Limpar as mensagens
            mensagemSucesso = string.Empty;
            mensagemErro = string.Empty;
            try
            {
                //Fazer a requisi��o para o servi�o de cadastro da API
                var servicesHelper = new ServicesHelper();
                var result = await servicesHelper.Post<CriarContaRequestModel, CriarContaResponseModel>("criarconta", model);
                mensagemSucesso = $"Parab�ns {result.Nome}, sua conta de usu�rio foi cadastrada com sucesso!";
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