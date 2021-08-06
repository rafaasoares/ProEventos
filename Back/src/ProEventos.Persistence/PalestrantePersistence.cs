using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : ProEventosPersistence, IPalestrantePersistence
    {
        public PalestrantePersistence(ProEventoContext proEventoContext) : base(proEventoContext) {}

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(x=> x.RedeSociais);

            if(includeEventos)
                query = query
                    .Include(x=> x.PalestrantesEventos)
                    .ThenInclude(x=> x.Evento);

            query = query.OrderBy(x=> x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(x=> x.RedeSociais);

            if(includeEventos)
                query = query
                    .Include(x=> x.PalestrantesEventos)
                    .ThenInclude(x=> x.Evento);

            query = query
                .Where(x=> x.Nome.ToLower().Contains(nome.ToLower()))
                .OrderBy(x=> x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestrantesByIdAsync(int id, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(x=> x.RedeSociais);

            if(includeEventos)
                query = query
                    .Include(x=> x.PalestrantesEventos)
                    .ThenInclude(x=> x.Evento);

            query = query.Where(x=> x.Id == id);

            return await query.FirstOrDefaultAsync();
        }

    }
}