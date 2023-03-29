using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly Contexto _context;

        public PersonaController(Contexto conte)
        {
            _context = conte;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Persona> lista = await _context.Usuarios.OrderByDescending(c => c.IdPersona).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Persona request)
        {
            await _context.Usuarios.AddAsync(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Completed");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Persona request)
        {
            _context.Usuarios.Update(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Completed");
        }

        [HttpPut]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Persona persona = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(persona);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "Completed");
        }
    }
}
