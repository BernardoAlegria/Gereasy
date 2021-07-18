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
    public class ClientesController : Controller
    {
        // Referência à Base de dados
        private readonly GereasyDbContext _db;

        public ClientesController(GereasyDbContext context)
        {
            _db = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _db.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _db.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Email,Contacto")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _db.Add(clientes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _db.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Email,Contacto")] Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(clientes);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.Id))
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
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _db.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientes == null)
            {
                return NotFound();
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _db.Clientes.FindAsync(id);
            _db.Clientes.Remove(clientes);

            // Para poder apagar um Cliente, é necessário que os objetos que o referenciam sejam apagados primeiro
            // devido ao "OnDelete" estar com o valor de "Restrict"
            // Caso não seja possível, é disparada uma excepcão "DbUpdateException"
            try {
                await _db.SaveChangesAsync();

            } catch (DbUpdateException e) {
                // Esta exceção, em principio, ocorre quando não podemos apagar o cliente devido ao OnDelete estar em Restrict
                // Para ter a certeza se foi essa a razão, podemos verificar a source do erro.
                // Dizemos ao utilizador que a operação nao pode ser feita
                if (e.Source == "Microsoft.EntityFrameworkCore.Relational") ModelState.AddModelError("", "O Cliente não pode ser eliminado.");
                else ModelState.AddModelError("", "Ocorreu um erro inesperado durante eliminação do Cliente.");
                return View(clientes);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return _db.Clientes.Any(e => e.Id == id);
        }
    }
}
