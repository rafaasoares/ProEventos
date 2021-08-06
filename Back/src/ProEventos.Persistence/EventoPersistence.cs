using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence
{
    public class EventoPersistence : ProEventosPersistence, IEventoPersistence
    {
        public EventoPersistence(ProEventoContext proEventoContext) : base(proEventoContext) {}

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(x => x.Lotes)
                .Include(x=> x.RedeSociais);

            if(includePalestrantes)
                query = query
                    .Include(x=> x.PalestrantesEventos)
                    .ThenInclude(x=> x.Palestrante);

            query = query.OrderBy(x=> x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(x => x.Lotes)
                .Include(x=> x.RedeSociais);

            if(includePalestrantes)
                query = query
                    .Include(x=> x.PalestrantesEventos)
                    .ThenInclude(x=> x.Palestrante);

            query = query
                .Where(x=> x.Tema.ToLower().Contains(tema.ToLower()))
                .OrderBy(x=> x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventosByIdAsync(int id, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(x => x.Lotes)
                .Include(x=> x.RedeSociais);

            if(includePalestrantes)
                query = query
                    .Include(x=> x.PalestrantesEventos)
                    .ThenInclude(x=> x.Palestrante);

            query = query
                .Where(x=> x.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}