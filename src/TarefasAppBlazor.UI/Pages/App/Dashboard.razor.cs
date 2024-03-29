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
using TarefasAppBlazor.UI.Helpers;
using TarefasAppBlazor.Services.Models.Responses;
using TarefasAppBlazor.Services.Helpers;

namespace TarefasAppBlazor.UI.Pages.App
{
    public partial class Dashboard
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public AuthenticationHelper AuthenticationHelper { get; set; }

        //atributos
        private List<DashboardResponseModel> dadosGrafico = new List<DashboardResponseModel>();
        private string mensagemProcessamento;
        private string mensagemErro;

        //fun��o para ser executada ao abrir o componente
        protected override async Task OnInitializedAsync()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";

            //capturando os dados do usu�rio autenticado
            var usuario = await AuthenticationHelper.GetUser();

            try
            {
                //acessando a API para obter os dados do gr�fico
                var servicesHelper = new ServicesHelper(usuario.AccessToken);
                dadosGrafico = await servicesHelper.Get<List<DashboardResponseModel>>("dashboard");

                //executar a fun��o javascript para gerar o conteudo do gr�fico
                await JSRuntime.InvokeAsync<object>
                    ("createChart", dadosGrafico, "Quantidade de tarefas por categoria", "grafico");

                mensagemErro = string.Empty;
            }
            catch(Exception e)
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