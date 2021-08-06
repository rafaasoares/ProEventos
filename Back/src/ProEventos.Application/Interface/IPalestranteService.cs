using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interface
{
    public interface IPalestranteService
    {
         Task<Palestrante> Add(Palestrante entity);
         Task<Palestrante> Update(Palestrante entity);
         Task<Palestrante> Delete(Palestrante entity);
         Task<Palestrante> DeleteRange(Palestrante[] entity);

         Task<bool> SaveChangesAsync();

         Task<Palestrante[]> GetAllPalestrantesByTemaAsync(string tema, bool includePalestrantes);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includePalestrantes);
         Task<Palestrante> GetPalestrantesByIdAsync(int id, bool includePalestrantes);
    }
}