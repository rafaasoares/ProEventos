using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interface
{
    public interface IEventoService
    {
         Task<Evento> Add(Evento entity);
         Task<Evento> Update(int id, Evento entity);
         Task<bool> Delete(int id);
         Task<bool> DeleteRange(Evento[] entity);

         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
         Task<Evento> GetEventosByIdAsync(int id, bool includePalestrantes);
    }
}