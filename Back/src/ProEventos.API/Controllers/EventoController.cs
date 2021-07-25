using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return new Evento[] {
                new Evento {
                    EventoId = 1,
                    Local = "Curitiba",
                    DataEvento  = "2021-07-25",
                    Tema  = "Tema",
                    QtdPessoas  = 10,
                    Lote  = "Lote",
                    ImagemURL  = ""
                },
                new Evento {
                    EventoId = 2,
                    Local = "São Paulo  ",
                    DataEvento  = "2021-07-25",
                    Tema  = "Tema",
                    QtdPessoas  = 10,
                    Lote  = "Lote",
                    ImagemURL  = ""
                }
            };
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetBydId(int id)
        {
            return (new Evento[] {
                new Evento {
                    EventoId = 1,
                    Local = "Curitiba",
                    DataEvento  = "2021-07-25",
                    Tema  = "Tema",
                    QtdPessoas  = 10,
                    Lote  = "Lote",
                    ImagemURL  = ""
                },
                new Evento {
                    EventoId = 2,
                    Local = "São Paulo  ",
                    DataEvento  = "2021-07-25",
                    Tema  = "Tema",
                    QtdPessoas  = 10,
                    Lote  = "Lote",
                    ImagemURL  = ""
                }
            }).Where(x=> x.EventoId == id);
        }

        [HttpPost]
        public Evento Post()
        {
            return new Evento {
                EventoId = 1,
                Local = "Local",
                DataEvento  = "2021-07-25",
                Tema  = "Tema",
                QtdPessoas  = 10,
                Lote  = "Lote",
                ImagemURL  = ""
            };
        }

        [HttpPut("{id}")]
        public Evento Put(int id)
        {
            return new Evento {
                EventoId = 1,
                Local = "Local",
                DataEvento  = "2021-07-25",
                Tema  = "Tema",
                QtdPessoas  = 10,
                Lote  = "Lote",
                ImagemURL  = ""
            };
        }

        [HttpDelete("{id}")]
        public Evento Delete(int id)
        {
            return new Evento {
                EventoId = 1,
                Local = "Local",
                DataEvento  = "2021-07-25",
                Tema  = "Tema",
                QtdPessoas  = 10,
                Lote  = "Lote",
                ImagemURL  = ""
            };
        }
    }
}