using LanchesBRV.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesBRV.Context
{
    public class AppDbContext : DbContext
    {
        // O construtor recebe as configurações (banco, string de conexão, etc.) 
        // e as envia para a classe base (DbContext) através do ': base(options)'
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        // DbSets representam as tabelas que serão criadas/mapeadas no SQL Server
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
    }
}
