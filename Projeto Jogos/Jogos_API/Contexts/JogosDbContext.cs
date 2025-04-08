using Jogos_API.Domains;
using Microsoft.EntityFrameworkCore;

namespace Jogos_API.Context
{
    public class JogosDbContext : DbContext
    {
        public JogosDbContext()
        {

        }
        public JogosDbContext(DbContextOptions<JogosDbContext> options) : base(options) 
        { 
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet <Jogo> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2H1U5TH\\SQLEXPRESS; Database=Jogos_API; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
            }
        }
    }
}
