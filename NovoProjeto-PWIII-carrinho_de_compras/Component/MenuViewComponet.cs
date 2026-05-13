using Microsoft.AspNetCore.Mvc;
using NovoProjeto_PWIII_carrinho_de_compras.repository.contract;


namespace NovoProjeto_PWIII_carrinho_de_compras.Component
{
    public class MenuViewComponet : ViewComponent
    {
        private ICategoriaRepository _categoriaRepository;

        public MenuViewComponet(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ListaCategoria = _categoriaRepository.ObterTodasCategorias().ToList();
            return View(ListaCategoria);
        }
    }
}
