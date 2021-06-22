using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gereasy.Data;
using Gereasy.Models;

namespace Gereasy.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly GereasyDbContext _context;

        public ColaboradoresController(GereasyDbContext context)
        {
            _context = context;
        }

        // GET: Colaboradores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Colaboradores.ToListAsync());
        }

        // GET: Colaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradores = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradores == null)
            {
                return NotFound();
            }

            return View(colaboradores);
        }

        // GET: Colaboradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNasc,Cargo,Departamento,Email,Contacto,Foto")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colaboradores);
        }

        // GET: Colaboradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradores = await _context.Colaboradores.FindAsync(id);
            if (colaboradores == null)
            {
                return NotFound();
            }
            return View(colaboradores);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNasc,Cargo,Departamento,Email,Contacto,Foto")] Colaboradores colaboradores)
        {
            if (id != colaboradores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradoresExists(colaboradores.Id))
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
            return View(colaboradores);
        }

        // GET: Colaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradores = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradores == null)
            {
                return NotFound();
            }

            return View(colaboradores);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboradores = await _context.Colaboradores.FindAsync(id);
            _context.Colaboradores.Remove(colaboradores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradoresExists(int id)
        {
            return _context.Colaboradores.Any(e => e.Id == id);
        }
    }
}
