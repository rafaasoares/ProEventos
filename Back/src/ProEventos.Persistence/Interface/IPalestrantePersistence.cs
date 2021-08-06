using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interface
{
    public interface IPalestrantePersistence : IProEventosPersistence
    {
         Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
         Task<Palestrante> GetPalestrantesByIdAsync(int id, bool includeEventos);
    }
}