using LanchesBRV.Context;
using LanchesBRV.Models;
using LanchesBRV.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesBRV.Repositories
{
    // Classe LancheRepository que implementa a interface ILancheRepository com as propriedades definidas
    public class LancheRepository : ILancheRepository
    {
        // Construtor que injeta a instância do contexto para servir os dados
        // private readonly para proteger a classe e definir visibilidade (somente leitura) restrita à classe
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext contexto )
        {
            _context = contexto;
        }
        // Retorna todos os lanches, junto à categoria com "Include"
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        // Retorna os lanches preferidos junto à categoria com "Where" e "Include", respectivamente
        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
                                                        Where(l => l.IsLanchePreferido).
                                                        Include(c => c.Categoria);

        // Retorna o lanche de acordo com o Id
        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
