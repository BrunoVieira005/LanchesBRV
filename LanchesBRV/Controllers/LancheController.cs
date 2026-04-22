using LanchesBRV.Repositories;
using LanchesBRV.Repositories.Interfaces;
using LanchesBRV.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesBRV.Controllers
{
    // Controller responsável por gerenciar as ações (requests) relacionadas aos lanches
    public class LancheController : Controller
    {
        // Armazena a instância do repositório de maneira protegida e imutável (readonly)
        private readonly ILancheRepository _lancheRepository;

        // Define o construtor que recebe a instância do Repository para Lanche
        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        // Action que será chamada pela rota (/Lanche/List)
        public IActionResult List()
        {
            // Instancia a ViewModel que servirá os dados para a View
            var lanchesListViewModel = new LancheListViewModel();
            // Preenche a propriedade Lanches da ViewModel com os dados vindos do repositório
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            // Retorna a View com as propriedades definidas na ViewModel
            return View(lanchesListViewModel);
        }
    }
}