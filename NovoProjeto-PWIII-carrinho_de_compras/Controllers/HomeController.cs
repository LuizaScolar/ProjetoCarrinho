using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NovoProjeto_PWIII_carrinho_de_compras.Carrinho;
using NovoProjeto_PWIII_carrinho_de_compras.Models;
using NovoProjeto_PWIII_carrinho_de_compras.repository.contract;

namespace NovoProjeto_PWIII_carrinho_de_compras.Controllers;

public class HomeController : Controller
{
    private ILivroRepository _livroRepository;
    private CookieCarrinhoCompra _cookieCarrinhoCompra;

    private IEmprestimoRepository _emprestimoRepository;
    private IItemRepository _itemRepository;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IEmprestimoRepository emprestimoRepository, IItemRepository itemRepository, CookieCarrinhoCompra cookieCarrinhoCompra, ILivroRepository livroRepository)
    {
        _logger = logger;
        _emprestimoRepository = emprestimoRepository;
        _itemRepository = itemRepository;
        _cookieCarrinhoCompra = cookieCarrinhoCompra;
        _livroRepository = livroRepository;

    }



    public IActionResult Index()
    {
        return View(_livroRepository.ObterTodosLivros());
    }

    public IActionResult AdicionarItem(int id)
    {
        Livro produto = _livroRepository.ObterLivros(id);
        if(produto == null)
        {
            return View("NaoExisteItem");
        }
        else
        {
            var item = new Livro()
            {
                codLivro = id,
                quantidade = 1,
                imagemLivro = produto.imagemLivro,
                nomeLivro = produto.nomeLivro
            };
            _cookieCarrinhoCompra.Cadastrar(item);

            return RedirectToAction(nameof(Carrinho));
        }
    }

    public IActionResult Carrinho() 
    {
        return View(_cookieCarrinhoCompra.Consultar());
    }

    public IActionResult RemoverItem(int id)
    {
        _cookieCarrinhoCompra.Remover(new Livro() { codLivro = id });
        return RedirectToAction(nameof(Carrinho));
    }


    DateTime data;
    public IActionResult SalvarCarrinho(Emprestimo emprestimo)
    {
        List<Livro> carrinho = _cookieCarrinhoCompra.Consultar();

    Emprestimo mdE = new Emprestimo();
    Item mdI = new Item();

        data = DateTime.Now.ToLocalTime();

        mdE.dtEmp = data.ToString("dd/MM/yyyy");
        mdE.dtDev = data.AddDays(7).ToString();
        mdE.codUsu = "1";
        _emprestimoRepository.Cadastrar(mdE);

        _emprestimoRepository.buscaIdEmp(emprestimo);

    for (int i = 0; i < carrinho.Count; i++)
    {
        mdI.codEmp = Convert.ToInt32(emprestimo.codEmp);
        mdI.codLivro = Convert.ToString(carrinho[i].codLivro);

        _itemRepository.Cadastrar(mdI);
    }

    _cookieCarrinhoCompra.RemoverTodos();
    return RedirectToAction("confEmp");
    }


    public IActionResult confEmp()
    { 
         return View(); 
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
