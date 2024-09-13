using Microsoft.AspNetCore.Mvc;
using ProEventos.Server.Data;
using ProEventos.Server.Models;

namespace ProEventos.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly DataContext _context;
        public EventosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Eventos> Get()
        {
            return _context.Tbeventos;
        }

        [HttpGet("{id}")]
        public Eventos GetById(int id)
        {
            return _context.Tbeventos.FirstOrDefault(
                                        evento => evento.EventoId == id
                );
        }
    }
}