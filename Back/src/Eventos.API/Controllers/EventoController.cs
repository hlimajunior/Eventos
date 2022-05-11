using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using Eventos.API.Data;
using Eventos.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace Eventos.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento() {
                EventoId = 1,
                Tema = "Angular 11 e .Net 5",
                Local = "Osasco/SP",
                Lote = "1° lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "foto.png"
            },
            new Evento() {
                EventoId = 2,
                Tema = "Angular 11 e .Net 5",
                Local = "Osasco/SP",
                Lote = "2° lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy"),
                ImagemURL = "foto2.png"
            }
        };
        private readonly DataContext _context;

        public EventoController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }


        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }


        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}
