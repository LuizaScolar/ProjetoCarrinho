using NovoProjeto_PWIII_carrinho_de_compras.Models;

namespace NovoProjeto_PWIII_carrinho_de_compras.repository.contract
{
    public interface IItemRepository
    {
        //CRUD 
        IEnumerable<Item> ObterTodosItens();

        void Cadastrar(Item item);
        void Atualizar(Item item);
        Item ObterItens(int id);
        void Excluir(int id);
    }
}
