using LanchesBRV.Models;
using LanchesBRV.Repositories.Interfaces;
using LanchesBRV.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesBRV.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        // Action principal: Monta a página do carrinho
        public IActionResult Index()
        {
            // 1. Busca os itens que já estão salvos no banco para este carrinho
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            // 2. Atribui a lista recuperada à propriedade do objeto carrinho
            _carrinhoCompra.CarrinhoCompraItens = itens;

            // 3. Instancia a ViewModel que transportará os dados para a View
            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            // 4. Retorna a View 'Index.cshtml' passando a ViewModel preenchida
            return View(carrinhoCompraVM);
        }

        // Método para adicionar que recebe o ID do lanche
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            // Busca o lanche no banco de dados através do Repositório
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

            // Se o lanche existir, envia o objeto para a lógica de negócio do carrinho
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);

            }
            // Após adicionar, redireciona o usuário para a página do carrinho (Index)
            return RedirectToAction("Index");
        }


        // Método para remover
        public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            // Busca o lanche no banco de dados através do repositório
            var lancheSelecionado = _lancheRepository.Lanches
                                    .FirstOrDefault(p => p.LancheId == lancheId);

            // Se lanche existir no banco, remove do carrinho
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }
            // Após removido, retorna para a view Index (página do carrinho)
            return RedirectToAction("Index");
        }
    }
}
