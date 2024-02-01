using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Models.Responses;
using TarefasAppBlazor.UI.Helpers;

namespace TarefasAppBlazor.UI.Pages.App
{
    public partial class ConsultarTarefas
    {
        [Inject]
        AuthenticationHelper AuthenticationHelper { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private List<TarefasConsultaResponseModel> model = new List<TarefasConsultaResponseModel>();

        //mensagens
        private string? mensagemProcessamento;
        private string? mensagemSucesso;
        private string? mensagemErro;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                mensagemProcessamento = "Processando, por favor aguarde...";

                var user = await AuthenticationHelper.GetUser();

                var servicesHelper = new ServicesHelper(user.AccessToken);
                model = await servicesHelper.Get<List<TarefasConsultaResponseModel>>("tarefas");
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

        protected async Task OnDelete(Guid id)
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", "Deseja realmente excluir esta tarefa?");

            if (confirmed)
            {
                try
                {
                    mensagemProcessamento = "Processando requisição, por favor aguarde...";

                    var user = await AuthenticationHelper.GetUser();

                    var servicesHelper = new ServicesHelper(user.AccessToken);
                    await servicesHelper.Delete<TarefasConsultaResponseModel>("tarefas", id);

                    mensagemSucesso = "Tarefa excluída com sucesso.";
                    await OnInitializedAsync();
                }
                catch (Exception e)
                {
                    mensagemErro = e.Message;
                }
            }
        }

        private string OnEdit(string id)
        {
            return $"/app/editar-tarefas/{id}";
        }
    }
}