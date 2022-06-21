using Eventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Persistence.Contextos
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions<EventosContext> options) : base(options) {}

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            // Explicação: 
            // ô modelbuilder, eu sei que você tem uma entidade (Entity) do tipo EVENTO...
            modelBuilder.Entity<Evento>()
                // vamos fazer o seguinte: eu sei que o EVENTO (e) TEM MUITAS (HasMany) RedesSociais.
                .HasMany(e => e.RedesSociais)
                // eu sei que uma Rede Social pertence a um evento só (WithOne)
                .WithOne(rs => rs.Evento)
                // então, quando eu mandar deletar (OnDelete) um EVENTO, 
                // adote o comportamento de delete (DeleteBehaviour) de cascata (Cascade) para apagar todas 
                // as Redes Sociais, pq não vou mais precisar delas sem o Evento. 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(p => p.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);                
        }
    }
}