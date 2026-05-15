using MySql.Data.MySqlClient;
using NovoProjeto_PWIII_carrinho_de_compras.Models;
using NovoProjeto_PWIII_carrinho_de_compras.repository.contract;
using System.Data;

namespace NovoProjeto_PWIII_carrinho_de_compras.repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _conexaoMySQL;

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
        List<Categoria> catList = new List<Categoria>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Categoria", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    catList.Add(
                        new Categoria
                        {
                            Id = Convert.ToInt32(dr["idLivro"]),
                            Nome = (string)(dr["Nome"]),
                        });
                }
                return catList;
            }
        }
    }
}
