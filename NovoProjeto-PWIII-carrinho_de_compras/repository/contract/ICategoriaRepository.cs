using NovoProjeto_PWIII_carrinho_de_compras.Models;

namespace NovoProjeto_PWIII_carrinho_de_compras.repository.contract
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> ObterTodasCategorias();
    }
}
