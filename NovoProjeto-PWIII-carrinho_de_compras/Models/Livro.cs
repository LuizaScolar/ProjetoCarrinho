using System.ComponentModel;

namespace NovoProjeto_PWIII_carrinho_de_compras.Models
{
    public class Livro
    {
        public int codLivro { get; set; }
        [DisplayName("XYZ")]
        public string nomeLivro { get; set; }
        public string imagemLivro { get; set; }
        public int quantidade { get; set; }
    }
}
