using Microsoft.AspNetCore.Mvc;
using NovoProjeto_PWIII_carrinho_de_compras.GerenciaArquivos;
using NovoProjeto_PWIII_carrinho_de_compras.repository.contract;
using NovoProjeto_PWIII_carrinho_de_compras.Models;

namespace NovoProjeto_PWIII_carrinho_de_compras.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepository _livrorepository;

        public LivroController(ILivroRepository livrorepository)
        {
            _livrorepository = livrorepository;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Livro livro, IFormFile file)
        {
            var Caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            livro.imagemLivro = Caminho;

            _livrorepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro Realizado";
            return View();  
        }
    }
}
