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
    public class TarefasController : Controller
    {
        private readonly GereasyDbContext _context;

        public TarefasController(GereasyDbContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index()
        {
            var gereasyDbContext = _context.Tarefas.Include(t => t.Projeto);
            return View(await gereasyDbContext.ToListAsync());
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .Include(t => t.Projeto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            ViewData["ProjetoFK"] = new SelectList(_context.Projetos, "Id", "Nome");
            ViewData["ColaboradorFK"] = new SelectList(_context.Colaboradores, "Id", "Nome");
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,DataCriacao,DataLimite,Estado,Prioridade,TempoDedicadoTotal,ProjetoFK,ColaboradorFK")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                //Criar a informação na base de dados pode correr mal e gerar excepções.
                try {
                    _context.Add(tarefas);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateException) {
                    ModelState.AddModelError("", "Ocorreu um erro durante a criação da Tarefa.");
                    return View();
                }
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjetoFK"] = new SelectList(_context.Projetos, "Id", "Nome", tarefas.ProjetoFK);
            return View(tarefas);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas.FindAsync(id);
            if (tarefas == null)
            {
                return NotFound();
            }
            ViewData["ProjetoFK"] = new SelectList(_context.Projetos, "Id", "Nome", tarefas.ProjetoFK);
            ViewData["ColaboradorFK"] = new SelectList(_context.Colaboradores, "Id", "Nome", tarefas.ColaboradorFK);
            return View(tarefas);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,DataCriacao,DataLimite,Estado,Prioridade,TempoDedicadoTotal,ProjetoFK,ColaboradorFK")] Tarefas tarefas)
        {
            if (id != tarefas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefasExists(tarefas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ocorreu um erro");
                        return View();
                    }
                }
                // Redirecionar para a página "Details" do Colaborador que foi editado
                return RedirectToAction(nameof(Details), new { id = tarefas.Id });
            }
            ViewData["ProjetoFK"] = new SelectList(_context.Projetos, "Id", "Nome", tarefas.ProjetoFK);
            ViewData["ColaboradorFK"] = new SelectList(_context.Colaboradores, "Id", "Nome", tarefas.ColaboradorFK);
            return View(tarefas);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefas = await _context.Tarefas
                .Include(t => t.Projeto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarefas == null)
            {
                return NotFound();
            }

            return View(tarefas);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // É preciso os includes para, caso não seja possível apagar, reenviar a informação do criador e do cliente correspondentes
            // a este projeto
            var tarefas = await _context.Tarefas
                .Include(t => t.Projeto)
                .FirstOrDefaultAsync(t => t.Id == id);
            _context.Tarefas.Remove(tarefas);
            // Para poder apagar um colaborador, é necessário que os objetos que o referenciam sejam apagados primeiro
            // devido ao "OnDelete" estar com o valor de "Restrict", para não haver tarefas que não se sabe quem criou
            // Caso não seja possível, é disparada uma excepcão "DbUpdateException"
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateException e) {
                // Esta exceção, em principio, ocorre quando não podemos apagar a tarefa devido ao OnDelete estar em Restrict
                // Para ter a certeza se foi essa a razão, podemos verificar a source do erro.
                // Dizemos ao utilizador que a operação nao pode ser feita
                // TODO: Neste caso talvez faça sentido deixar apagar a tarefa, tendo de apagar todos os registos de atividade
                // (tabela TarefasColaboradores) primeiro.
                if (e.Source == "Microsoft.EntityFrameworkCore.Relational") ModelState.AddModelError("", "A Tarefa não pode ser eliminada.");
                else ModelState.AddModelError("", "Ocorreu um erro inesperado durante eliminação da Tarefa.");
                return View(tarefas);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TarefasExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
