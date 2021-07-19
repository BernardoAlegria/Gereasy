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
    public class ProjetosController : Controller
    {
        private readonly GereasyDbContext _context;

        public ProjetosController(GereasyDbContext context)
        {
            _context = context;
        }

        // GET: Projetos
        public async Task<IActionResult> Index()
        {
            var gereasyDbContext = _context.Projetos.Include(p => p.Cliente).Include(p => p.Criador);
            return View(await gereasyDbContext.ToListAsync());
        }

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Projetos
                .Include(p => p.Cliente)
                .Include(p => p.Criador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projetos == null)
            {
                return NotFound();
            }

            return View(projetos);
        }

        // GET: Projetos/Create
        public IActionResult Create()
        {
            ViewData["ClienteFK"] = new SelectList(_context.Clientes, "Id", "Nome");
            ViewData["CriadorFK"] = new SelectList(_context.Colaboradores, "Id", "Nome");
            return View();
        }

        // POST: Projetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,DataCriacao,DataPrevista,DataInicio,DataFim,ClienteFK,CriadorFK")] Projetos projetos)
        {
            if (ModelState.IsValid)
            {
                // O SaveChanges pode lançar exceções de houver problemas em guardar a informação na base de dados
                try {
                    _context.Add(projetos);
                    await _context.SaveChangesAsync();

                } catch(Exception) {
                    ModelState.AddModelError("", "Ocorreu um erro durante a criação do Projeto.");
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteFK"] = new SelectList(_context.Clientes, "Id", "Email", projetos.ClienteFK);
            ViewData["CriadorFK"] = new SelectList(_context.Colaboradores, "Id", "Cargo", projetos.CriadorFK);
            return View(projetos);
        }

        // GET: Projetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Projetos.FindAsync(id);
            if (projetos == null)
            {
                return NotFound();
            }
            ViewData["ClienteFK"] = new SelectList(_context.Clientes, "Id", "Nome", projetos.ClienteFK);
            ViewData["CriadorFK"] = new SelectList(_context.Colaboradores, "Id", "Nome", projetos.CriadorFK);
            return View(projetos);
        }

        // POST: Projetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,DataCriacao,DataPrevista,DataInicio,DataFim,ClienteFK,CriadorFK")] Projetos projetos)
        {
            if (id != projetos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                try
                {
                    _context.Update(projetos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetosExists(projetos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ocorreu um erro");
                        return View();
                    }
                // Pode haver outros problemas não relacionados com a concorrência. Por ex, perda de ligação à BD
                } catch (DbUpdateException) {
                    ModelState.AddModelError("", "Ocorreu um erro durante a criação do Projeto.");
                    return View();
                }
                // Redirecionar para a página "Details" do Projeto que foi editado
                return RedirectToAction(nameof(Details), new { id = projetos.Id });
            }
            ViewData["ClienteFK"] = new SelectList(_context.Clientes, "Id", "Email", projetos.ClienteFK);
            ViewData["CriadorFK"] = new SelectList(_context.Colaboradores, "Id", "Cargo", projetos.CriadorFK);
            return View(projetos);
        }

        // GET: Projetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Projetos
                .Include(p => p.Cliente)
                .Include(p => p.Criador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projetos == null)
            {
                return NotFound();
            }

            return View(projetos);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projetos = await _context.Projetos
                // É preciso os includes para, caso não seja possível apagar, reenviar a informação do criador e do cliente correspondentes
                // a este projeto
                .Include(p => p.Cliente)
                .Include(p => p.Criador)
                .FirstOrDefaultAsync(p => p.Id == id);
            _context.Projetos.Remove(projetos);
            // Para poder apagar um Projeto, é necessário que os objetos que o referenciam sejam apagados primeiro
            // devido ao "OnDelete" estar com o valor de "Restrict", para não haver tarefas que não se sabe quem criou
            // Caso não seja possível, é disparada uma excepcão "DbUpdateException"
            try {
                await _context.SaveChangesAsync();
               
            } catch(DbUpdateException e) {
                // Esta exceção, em principio, ocorre quando não podemos apagar o colaborador devido ao OnDelete estar em Restrict
                // Para ter a certeza se foi essa a razão, podemos verificar a source do erro.
                // Dizemos ao utilizador que a operação nao pode ser feita
                if (e.Source == "Microsoft.EntityFrameworkCore.Relational") ModelState.AddModelError("", "O Projeto não pode ser eliminado.");
                else ModelState.AddModelError("", "Ocorreu um erro inesperado durante eliminação do Projeto.");
                return View(projetos);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetosExists(int id)
        {
            return _context.Projetos.Any(e => e.Id == id);
        }
    }
}
