using NovoProjeto_PWIII_carrinho_de_compras.Models;

namespace NovoProjeto_PWIII_carrinho_de_compras.repository.contract
{
    public interface IEmprestimoRepository
    {
        //CRUD
        IEnumerable<Emprestimo> ObterTodosEmprestimos();
        void Cadastrar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        Emprestimo ObterEmprestimos(int Id);
        void buscaIdEmp(Emprestimo emprestimo);
        void Excluir(int id);
    }
}
