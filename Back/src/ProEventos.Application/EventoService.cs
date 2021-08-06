using System;
using System.Threading.Tasks;
using ProEventos.Application.Interface;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersistence _eventoPersistence;

        public EventoService(IEventoPersistence eventoPersistence)
        {
            _eventoPersistence = eventoPersistence;
        }

        public async Task<Evento> Add(Evento entity)
        {
            try
            {
                _eventoPersistence.Add<Evento>(entity);
                if(await _eventoPersistence.SaveChangesAsync())
                    return await _eventoPersistence.GetEventosByIdAsync(entity.Id, true);
                else 
                    return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventosByIdAsync(id, false);
                if(evento == null)
                    return false;
                    
                _eventoPersistence.Delete<Evento>(evento);
                return await _eventoPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteRange(Evento[] eventos)
        {
            try
            {
                _eventoPersistence.DeleteRange<Evento>(eventos);
                return await _eventoPersistence.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Evento> Update(int id, Evento entity)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventosByIdAsync(id, false);
                if(evento == null)
                    return null;

                _eventoPersistence.Update<Evento>(entity);
                if(await _eventoPersistence.SaveChangesAsync())
                    return await _eventoPersistence.GetEventosByIdAsync(entity.Id, true);
                else 
                    return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes)
        {
            try
            {
                return await _eventoPersistence.GetAllEventosAsync(includePalestrantes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            try
            {
                return await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Evento> GetEventosByIdAsync(int id, bool includePalestrantes)
        {
            try
            {
                return await _eventoPersistence.GetEventosByIdAsync(id, includePalestrantes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}