using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Models.Requests;
using TarefasAppBlazor.Services.Models.Responses;

namespace TarefasAppBlazor.UI.Pages
{
    public partial class RecuperarSenha
    {
        //Definindo o modelo de dados do componente
        private RecuperarSenhaRequestModel model = new RecuperarSenhaRequestModel();
        //mensagens
        private string? mensagemProcessamento;
        private string? mensagemSucesso;
        private string? mensagemErro;
        //Fun��o para capturar o SUBMIT do formul�rio
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";
            //limpar as mensagens
            mensagemSucesso = string.Empty;
            mensagemErro = string.Empty;
            try
            {
                //fazendo a requisi��o para o servi�o de recupera��o de senha da API
                var servicesHelper = new ServicesHelper();
                var result = await servicesHelper.Post<RecuperarSenhaRequestModel, RecuperarSenhaResponseModel>("recuperarsenha", model);
                mensagemSucesso = $"Ol� {result.Nome}, sua solicita��o de recupera��o de senha foi realizada com sucesso.Verifique a caixa de entrada do seu email.";
                model = new RecuperarSenhaRequestModel();
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