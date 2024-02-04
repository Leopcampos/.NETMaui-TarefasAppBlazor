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

namespace TarefasAppBlazor.UI.Pages.App
{
    public partial class ContaUsuario
    {
        [Inject]
        public AuthenticationHelper AuthenticationHelper { get; set; }

        private string nomeUsuario = string.Empty;
        private string emailUsuario = string.Empty;
        private bool isAuthenticated = false;

        protected override async Task OnInitializedAsync()
        {
            if(await AuthenticationHelper.IsSigningIn())
            {
                var usuario = await AuthenticationHelper.GetUser();
                nomeUsuario = usuario.Nome;
                emailUsuario = usuario.Email;
                isAuthenticated = true;
            }
            else
            {
                isAuthenticated = false;
            }
        }
    }
}