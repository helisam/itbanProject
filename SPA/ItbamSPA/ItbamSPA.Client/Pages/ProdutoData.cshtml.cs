using ItbamSPA.Shared.Models;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ItbamSPA.Client.Pages
{
    public class ProdutoDataModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Parameter]
        protected string paramProdutoID { get; set; } = "0";
        [Parameter]
        protected string action { get; set; }

        protected List<Produto> produtos = new List<Produto>();
        protected Produto produto = new Produto();
        protected string title { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (action == "fetch")
            {
                await FetchProduto();
                this.StateHasChanged();
            }
            else if (action == "create")
            {
                title = "Adicionar Produto";
                produto = new Produto();
            }
            else if (paramProdutoID != "0")
            {
                if (action == "edit")
                {
                    title = "Editar Produto";
                }
                else if (action == "delete")
                {
                    title = "Remover Produto";
                }

                produto = await Http.GetJsonAsync<Produto>("/api/Produto/Info/" + Convert.ToInt32(paramProdutoID));
            }
        }

        protected async Task FetchProduto()
        {
            title = "Produto Info";
            produtos = await Http.GetJsonAsync<List<Produto>>("api/Produto/Index");
        }

        protected async Task Adicionar()
        {
            if (produto.Id != 0)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/Produto/Editar", produto);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Produto/Criar", produto);
            }
            UriHelper.NavigateTo("/produto/fetch");
        }

        protected async Task Remover()
        {
            await Http.DeleteAsync("api/Produto/Remover/" + Convert.ToInt32(paramProdutoID));
            UriHelper.NavigateTo("/produto/fetch");
        }

        protected void Cancelar()
        {
            title = "Produto Info";
            UriHelper.NavigateTo("/produto/fetch");
        }

    }
}