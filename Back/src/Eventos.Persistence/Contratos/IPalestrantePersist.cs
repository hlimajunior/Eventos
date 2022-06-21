using System.Threading.Tasks;
using Eventos.Domain;

namespace Eventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        // PALESTRANTES
         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);

         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);

         Task<Palestrante> GetPalestrantesByIdAsync(int palestranteId, bool includeEventos);
    }
}