using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;

namespace ProEventos.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly ProEventosContext _context;
        public EventosController(ProEventosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.tbeventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.tbeventos.FirstOrDefault(
                                        evento => evento.Id == id
                );
        }
    }
}