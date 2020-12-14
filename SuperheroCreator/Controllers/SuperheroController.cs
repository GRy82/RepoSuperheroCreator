using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperheroCreator.Models;
using SuperheroCreator.Data;

namespace SuperheroCreator.Controllers
{
    public class SuperheroController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperheroController
        public ActionResult Index()
        {
            var superhero = _context.Superheroes;
            return View(superhero);

        }

        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            Superhero superhero = _context.Superheroes.FirstOrDefault(i => i.SuperheroId == id);
            return View(superhero);
        }

        // GET: SuperheroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = _context.Superheroes.Single(i => i.SuperheroId == id);
            return View(superhero);
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                Superhero hero = _context.Superheroes.Single(s => s.SuperheroId == id);
                _context.Superheroes.Remove(hero);
                superhero.SuperheroId = id;
                _context.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = _context.Superheroes.Single(i => i.SuperheroId == id);
            return View(superhero);
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                _context.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
