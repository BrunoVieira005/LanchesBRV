using LanchesBRV.Repositories.Interfaces;
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
            // Obtém os dados através do repository, com todos os lanches
            var lanches = _lancheRepository.Lanches;
            // Retorna a View padrão (List.cshtml) passando a lista de lanches como Model
            return View(lanches);
        }
    }
}