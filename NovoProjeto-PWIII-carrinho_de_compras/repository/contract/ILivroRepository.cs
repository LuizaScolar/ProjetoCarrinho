using NovoProjeto_PWIII_carrinho_de_compras.Controllers;
using NovoProjeto_PWIII_carrinho_de_compras.Models;

namespace NovoProjeto_PWIII_carrinho_de_compras.repository.contract
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> ObterTodosLivros();
        void Cadastrar(Livro livro);
        void Atualizar(Livro livro);
        Livro ObterLivros(int id);
        void Excluir(int id);
        void Cadastrar(LivroController livro);
    }
}
