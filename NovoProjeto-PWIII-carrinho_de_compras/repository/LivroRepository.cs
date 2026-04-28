using MySql.Data.MySqlClient;
using NovoProjeto_PWIII_carrinho_de_compras.Controllers;
using NovoProjeto_PWIII_carrinho_de_compras.Models;
using NovoProjeto_PWIII_carrinho_de_compras.repository.contract;
using System.Data;

namespace NovoProjeto_PWIII_carrinho_de_compras.repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly string _conexaoMySQL;

        public LivroRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Livro livro)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Livro livro)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                MySqlCommand cmd = new MySqlCommand("insert into tbLivro values(default, @nomeLivro, @imagemLivro)", conexao);
                cmd.Parameters.Add("@nomeLivro", MySqlDbType.VarChar).Value = livro.nomeLivro;
                cmd.Parameters.Add("@imagemLivro", MySqlDbType.VarChar).Value = livro.imagemLivro;
                conexao.Close();
            }
        }

        public void Cadastrar(LivroController livro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Livro ObterLivros(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("select * from tbLivro where codLivro=@cod", conexao);
                cmd.Parameters.Add("@cod", MySqlDbType.VarChar).Value = id;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Livro livro = new Livro();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    livro.codLivro = Convert.ToInt32(dr["codLivro"]);
                    livro.nomeLivro = (String)(dr["nomeLivro"]);
                    livro.imagemLivro = (String)(dr["imagemLivro"]);
                }
                return livro;
            }
        }
        public IEnumerable<Livro> ObterTodosLivros()
        {
            List<Livro> LivroList = new List<Livro>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("select * from tbLivro", conexao);
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sd.Fill(dt);
                conexao.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    LivroList.Add(
                        new Livro
                        {
                            codLivro = Convert.ToInt32(dr["codLivro"]),
                            nomeLivro = (String)(dr["nomeLivro"]),
                            imagemLivro = (String)(dr["imagemLivro"])
                        });
                }
                return LivroList;
            }
        }
    }
}
