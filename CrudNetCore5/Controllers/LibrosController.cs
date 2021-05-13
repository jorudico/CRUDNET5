using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore5.Controllers
{
    public class LibrosController : Controller
    {



        private readonly ApplicationDbContext _context;


        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // HTTP get Index
        public IActionResult Index()
        {
            IEnumerable<Libro> listasLibros = _context.Libro;

            
            return View(listasLibros);
        }

        // HTTP get Create
        public IActionResult Create()
        {    
            return View();
        }

        // HTTP Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha creado correctamente";
                return RedirectToAction("Index");
            }
            
            return View();
        }



        // HTTP get Edit
        public IActionResult Edit(int? id)
        {

            if (id ==null || id == 0)
            {
                return NotFound();
            }

            // obtener el libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }


        // HTTP Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha Actualizado correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }



        // HTTP get Delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            // obtener el libro
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }


        // HTTP Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {

            //Obtener el libro por id

            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }
                _context.Libro.Remove(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha Eliminado correctamente";
                return RedirectToAction("Index");
           

        }



    }
}
