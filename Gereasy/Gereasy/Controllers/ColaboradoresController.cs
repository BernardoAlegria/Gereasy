using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gereasy.Data;
using Gereasy.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Gereasy.Controllers
{

    /// <summary>
    /// Controller para gerir os Colaboradores
    /// </summary>
    public class ColaboradoresController : Controller
    {

        /// <summary>
        /// Atributo que referencia a base de dados
        /// </summary>
        private readonly GereasyDbContext _context;

        /// <summary>
        /// Atributo que contém nele os dados do Servidor
        /// </summary>
        private readonly IWebHostEnvironment _dadosServidor;

        public ColaboradoresController(GereasyDbContext context, IWebHostEnvironment dadosServidor)
        {
            _context = context;
            _dadosServidor = dadosServidor;

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
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNasc,Cargo,Departamento,Email,Contacto,Foto")] Colaboradores colaborador, IFormFile fotoColaborador)
        {

            colaborador.Foto = "default.jpg";

            // Se existir ficheiro, mudamos o nome da fotografia, senão fica a pre-definida
            if (fotoColaborador != null) {
                // a foto está num formato correto?
                if (fotoColaborador.ContentType == "image/png" || fotoColaborador.ContentType == "image/jpeg") {
                    // definir o nome do ficheiro e guid para o caso de haver fotos com o mesmo nome
                    Guid g;
                    g = Guid.NewGuid();
                    string nomeFoto = g + "_" + fotoColaborador.FileName;
                    //adicionar o nome da foto ao colaborador
                    colaborador.Foto = nomeFoto;

                    // guardar o ficheiro enviado pelo utilizador
                    // determinar onde guardar o ficheiro
                    string caminhoAteAoFichFoto = _dadosServidor.WebRootPath;
                    caminhoAteAoFichFoto = Path.Combine(caminhoAteAoFichFoto, "fotos", colaborador.Foto);
                    // guardar o ficheiro no Disco Rígido
                    // TODO try
                    using var stream = new FileStream(caminhoAteAoFichFoto, FileMode.Create);
                    await fotoColaborador.CopyToAsync(stream);

                } else {
                    // ficheiro não válido, retornar à View
                    ModelState.AddModelError("", "Por favor escolha uma fotografia ou deixe em branco");
                    return View();
                }
            } 
            // associar o nome da fotografia ao Colaborador
            


            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            string why = ModelState.ValidationState.ToString();
            return View(colaborador);
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
