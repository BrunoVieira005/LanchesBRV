using LanchesBRV.Models;
using LanchesBRV.Repositories;
using LanchesBRV.Repositories.Interfaces;
using LanchesBRV.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
        /* public IActionResult List()
         {
             // Instancia a ViewModel que servirá os dados para a View
             // var lanchesListViewModel = new LancheListViewModel();
             // Preenche a propriedade Lanches da ViewModel com os dados vindos do repositório
             //lanchesListViewModel.Lanches = _lancheRepository.Lanches;
             lanchesListViewModel.CategoriaAtual = "Categoria Atual";

             // Retorna a View com as propriedades definidas na ViewModel
             return View(lanchesListViewModel);
         }*/
        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;


            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }

            else
            {
                lanches = _lancheRepository.Lanches
                            .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                            .OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {

            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);

        }
    }
}