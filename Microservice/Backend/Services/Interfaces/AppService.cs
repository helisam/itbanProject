using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IAppService
    {
        void ConsultarSimples(ref Dictionary<string, decimal> tempo, int iteracoes);
        void Adicionar(ref Dictionary<string, decimal> tempo, int iteracoes);
        void Alterar(ref Dictionary<string, decimal> tempo, int iteracoes);
        void Excluir(ref Dictionary<string, decimal> tempo, int iteracoes);
        void ConsultaCompostaProdutoEProductModelPorNome(ref Dictionary<string, decimal> tempo, int iteracoes);
        void ConsultaCompostaProdutoEProductModelESubCategoryPorNome(ref Dictionary<string, decimal> tempo, int iteracoes);
    }
}
