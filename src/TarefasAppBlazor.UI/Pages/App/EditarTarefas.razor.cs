using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using TarefasAppBlazor.UI;
using TarefasAppBlazor.UI.Shared;
using TarefasAppBlazor.Services.Models.Requests;
using TarefasAppBlazor.UI.Helpers;
using TarefasAppBlazor.Services.Helpers;
using TarefasAppBlazor.Services.Models.Responses;

namespace TarefasAppBlazor.UI.Pages.App
{
    public partial class EditarTarefas
    {
        [Inject]
        AuthenticationHelper AuthenticationHelper { get; set; }

        [Parameter]
        public string? Id { get; set; }

        //Definindo a classe de modelo de dados do componente
        private TarefasEdicaoRequestModel model = new TarefasEdicaoRequestModel();

        //lista de opções para o campo de seleção de categoria
        private List<string> Categorias = new List<string>();

        //mensagens
        private string? mensagemProcessamento;
        private string? mensagemSucesso;
        private string? mensagemErro;

        //função para capturar o  SUBMIT do formulário
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";

            try
            {
                //capturando os dados do usuário autenticado
                var user = await AuthenticationHelper.GetUser();

                var servicesHelper = new ServicesHelper(user.AccessToken);
                await servicesHelper.Put<TarefasEdicaoRequestModel, TarefasConsultaResponseModel>("tarefas", model);

                this.mensagemSucesso = "Tarefa atualizada com sucesso";
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

        //função executada quando a página for aberta
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Categorias.Add("Trabalho");
                Categorias.Add("Estudo");
                Categorias.Add("Família");
                Categorias.Add("Lazer");
                Categorias.Add("Outros");

                mensagemProcessamento = "Processando, por favor aguarde...";

                var user = await AuthenticationHelper.GetUser();

                var servicesHelper = new ServicesHelper(user.AccessToken);
                model = await servicesHelper.Get<TarefasEdicaoRequestModel>("tarefas", Guid.Parse(Id));
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