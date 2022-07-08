using Microsoft.AspNetCore.Mvc;

namespace MinimalAPITeloenseno.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PersonasController : Controller
    {
        private readonly DataContext _context;

        public PersonasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            return _context.Persona != null ?
                        View(await _context.Persona.ToListAsync()) :
                        Problem("Las personas no existen");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona
                .FirstOrDefaultAsync(m => m.PersonaID == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([Bind("Nombre,Apellido,DNI,Correo,Password")] Persona persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Obtener));

        }



        [HttpPost("{id}")]
        public async Task<IActionResult> Modificar(int id, [Bind("Nombre,Apellido,DNI,Correo,Password,PersonaCursos")] Persona persona)
        {
            if (id != persona.PersonaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExistePersona(persona.PersonaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Obtener));
            }
            return View(persona);
        }

        private bool ExistePersona(int id)
        {
            return (_context.Persona?.Any(e => e.PersonaID == id)).GetValueOrDefault();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Borrar(int id)
        {
            if (_context.Persona == null)
            {
                return Problem("La persona no existe");
            }
            var persona = await _context.Persona.FindAsync(id);
            if (persona != null)
            {
                _context.Persona.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Obtener));
        }
    }
}
