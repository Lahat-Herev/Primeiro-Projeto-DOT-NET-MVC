using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }


        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public IActionResult Editar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound();
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoDb = _context.Contatos.Find(contato.Id);
            contatoDb.Nome = contato.Nome;
            contatoDb.Telefone = contato.Telefone;
            contatoDb.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound();
            return View(contato);
        }

        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound();
            return View(contato);
        }

        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoDb = _context.Contatos.Find(contato.Id);

            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}