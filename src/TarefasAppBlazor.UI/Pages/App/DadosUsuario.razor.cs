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
using TarefasAppBlazor.Services.Models.Responses;
using TarefasAppBlazor.UI.Helpers;
using TarefasAppBlazor.Services.Models.Requests;
using TarefasAppBlazor.Services.Helpers;

namespace TarefasAppBlazor.UI.Pages.App
{
    public partial class DadosUsuario
    {
        //injeção de dependência
        [Inject]
        public AuthenticationHelper AuthenticationHelper { get; set; }

        //atributos
        private AutenticarResponseModel usuario = new AutenticarResponseModel();
        private AlterarSenhaRequestModel model = new AlterarSenhaRequestModel();

        private string? mensagemProcessamento;
        private string? mensagemSucesso;
        private string? mensagemErro;

        //método para execução ao abrir um componente
        protected override async Task OnInitializedAsync()
        {
            //capturar os dados do usuário autenticado
            usuario = await AuthenticationHelper.GetUser();
        }

        //método para capturar o Submit do formulário
        protected async Task OnSubmit()
        {
            mensagemProcessamento = "Processando, por favor aguarde...";
            mensagemSucesso = string.Empty;
            mensagemErro = string.Empty;

            try
            {
                var servicesHelper = new ServicesHelper(usuario.AccessToken);
                await servicesHelper.Post<AlterarSenhaRequestModel, AlterarSenhaResponseModel>("alterarsenha", model);

                mensagemSucesso = "Senha de acesso atualizada com sucesso.";
                model = new AlterarSenhaRequestModel();
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