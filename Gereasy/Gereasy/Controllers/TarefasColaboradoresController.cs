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
    public class TarefasColaboradoresController : Controller
    {
        private readonly GereasyDbContext _context;

        public TarefasColaboradoresController(GereasyDbContext context)
        {
            _context = context;
        }

        // GET: TarefasColaboradores
        public async Task<IActionResult> Index()
        {
            var gereasyDbContext = _context.TarefasColaboradores.Include(t => t.Colaborador).Include(t => t.Tarefa);
            return View(await gereasyDbContext.ToListAsync());
        }

        // GET: TarefasColaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefasColaboradores = await _context.TarefasColaboradores
                .Include(t => t.Colaborador)
                .Include(t => t.Tarefa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefasColaboradores == null)
            {
                return NotFound();
            }

            return View(tarefasColaboradores);
        }

        // GET: TarefasColaboradores/Create
        public IActionResult Create()
        {
            ViewData["ColaboradorFK"] = new SelectList(_context.Colaboradores, "Id", "Cargo");
            ViewData["TarefaFK"] = new SelectList(_context.Tarefas, "Id", "Prioridade");
            return View();
        }

        // POST: TarefasColaboradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Funcao,TempoDedicado,ColaboradorFK,TarefaFK")] TarefasColaboradores tarefasColaboradores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefasColaboradores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColaboradorFK"] = new SelectList(_context.Colaboradores, "Id", "Cargo", tarefasColaboradores.ColaboradorFK);
            ViewData["TarefaFK"] = new SelectList(_context.Tarefas, "Id", "Prioridade", tarefasColaboradores.TarefaFK);
            return View(tarefasColaboradores);
        }

        // GET: TarefasColaboradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefasColaboradores = await _context.TarefasColaboradores.FindAsync(id);
            if (tarefasColaboradores == null)
            {
                return NotFound();
            }
            ViewData["ColaboradorFK"] = new SelectList(_context.Colaboradores, "Id", "Cargo", tarefasColaboradores.ColaboradorFK);
            ViewData["TarefaFK"] = new SelectList(_context.Tarefas, "Id", "Prioridade", tarefasColaboradores.TarefaFK);
            return View(tarefasColaboradores);
        }

        // POST: TarefasColaboradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Funcao,TempoDedicado,ColaboradorFK,TarefaFK")] TarefasColaboradores tarefasColaboradores)
        {
            if (id != tarefasColaboradores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefasColaboradores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefasColaboradoresExists(tarefasColaboradores.Id))
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
            ViewData["ColaboradorFK"] = new SelectList(_context.Colaboradores, "Id", "Cargo", tarefasColaboradores.ColaboradorFK);
            ViewData["TarefaFK"] = new SelectList(_context.Tarefas, "Id", "Prioridade", tarefasColaboradores.TarefaFK);
            return View(tarefasColaboradores);
        }

        // GET: TarefasColaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefasColaboradores = await _context.TarefasColaboradores
                .Include(t => t.Colaborador)
                .Include(t => t.Tarefa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefasColaboradores == null)
            {
                return NotFound();
            }

            return View(tarefasColaboradores);
        }

        // POST: TarefasColaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefasColaboradores = await _context.TarefasColaboradores.FindAsync(id);
            _context.TarefasColaboradores.Remove(tarefasColaboradores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefasColaboradoresExists(int id)
        {
            return _context.TarefasColaboradores.Any(e => e.Id == id);
        }
    }
}
