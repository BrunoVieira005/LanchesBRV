using LanchesBRV.Context;
using LanchesBRV.Models;
using LanchesBRV.Repositories.Interfaces;

namespace LanchesBRV.Repositories
{
    // Classe CategoriaRepository que implementa a interface ICategoriaRepository com as propriedades definidas
    public class CategoriaRepository : ICategoriaRepository
    {
        // Construtor que injeta a instância do contexto para servir os dados
        // private readonly para proteger a classe e definir visibilidade (somente leitura) restrita à classe
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        // Retorna todas as categorias
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}