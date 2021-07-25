using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        public DataContext DataContext { get; }

        public EventoController(DataContext dataContext)
        {
            this.DataContext = dataContext;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return DataContext.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetBydId(int id)
        {
            return DataContext.Eventos.FirstOrDefault(x => x.EventoId == id);
        }

        [HttpPost]
        public Evento Post()
        {
            return new Evento
            {
                EventoId = 1,
                Local = "Local",
                DataEvento = "2021-07-25",
                Tema = "Tema",
                QtdPessoas = 10,
                Lote = "Lote",
                ImagemURL = ""
            };
        }

        [HttpPut("{id}")]
        public Evento Put(int id)
        {
            return new Evento
            {
                EventoId = 1,
                Local = "Local",
                DataEvento = "2021-07-25",
                Tema = "Tema",
                QtdPessoas = 10,
                Lote = "Lote",
                ImagemURL = ""
            };
        }

        [HttpDelete("{id}")]
        public Evento Delete(int id)
        {
            return new Evento
            {
                EventoId = 1,
                Local = "Local",
                DataEvento = "2021-07-25",
                Tema = "Tema",
                QtdPessoas = 10,
                Lote = "Lote",
                ImagemURL = ""
            };
        }
    }
}