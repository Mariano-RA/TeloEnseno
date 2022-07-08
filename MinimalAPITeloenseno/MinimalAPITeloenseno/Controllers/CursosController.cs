using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinimalAPITeloenseno.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CursosController : Controller
    {
        private readonly DataContext _context;

        public CursosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            return _context.Curso != null ?
                        View(await _context.Curso.ToListAsync()) :
                        Problem("El curso no existe");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([Bind("Titulo,Categoria,Duracion,Descripcion,Contenido,Precio,Profesor")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        

        [HttpPost("{id}")]
        public async Task<IActionResult> Modificar(int id, [Bind("Titulo,Categoria,Duracion,Descripcion,Contenido,Precio,Profesor")] Curso curso)
        {
            if (id != curso.CursoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExisteCurso(curso.CursoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        private bool ExisteCurso(int id)
        {
            return (_context.Curso?.Any(e => e.CursoId == id)).GetValueOrDefault();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> BorradoConfirmado(int id)
        {
            if (_context.Curso == null)
            {
                return Problem("El curso es nulo");
            }
            var curso = await _context.Curso.FindAsync(id);
            if (curso != null)
            {
                _context.Curso.Remove(curso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
