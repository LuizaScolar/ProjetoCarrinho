using MySql.Data.MySqlClient;
using NovoProjeto_PWIII_carrinho_de_compras.Models;
using NovoProjeto_PWIII_carrinho_de_compras.repository.contract;

namespace NovoProjeto_PWIII_carrinho_de_compras.repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _conexaoMySQL;

        public ItemRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Item item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Item item)
        {
            using(var conexao = new MySqlConnection("ConexaoMySQL"))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into itensEmp values(default, @codEmp, @codLivro)", conexao);

                cmd.Parameters.Add("@codEmp", MySqlDbType.VarChar).Value = item.codEmp;
                cmd.Parameters.Add("@codLivro", MySqlDbType.VarChar).Value = item.codLivro;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Item ObterItens(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> ObterTodosItens()
        {
            throw new NotImplementedException();
        }
    }
}
