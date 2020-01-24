using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.data.Db;
using App.data.Models;
using App.data.Services;

namespace webAppRestaurants.Controllers
{
    public class NotesController : Controller
    {
        private readonly RestaurantService _service;
        public NotesController(RestaurantService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var notes = this._service.getNotes();
            return View(notes);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = this._service.getThisNote(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        public IActionResult Create()
        {
            ViewData["restaurant"] = new SelectList(this._service.getContext().Restaurants, "ID", "nom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("resto_ID,date_dv,note,commentaire_dv")] Note note)
        {
            if (ModelState.IsValid)
            {
                _service.createNote(note);
                return RedirectToAction(nameof(Index));
            }
            ViewData["resto_ID"] = new SelectList(this._service.getContext().Restaurants, "ID", "nom", note.resto_ID);
            return View(note);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = this._service.getThisNote(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewData["resto_ID"] = new SelectList(this._service.getContext().Restaurants, "ID", "nom", note.resto_ID);
            return View(note);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,resto_ID,date_dv,note,commentaire_dv")] Note note)
        {
            if (id != note.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._service.editNote(id, note);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.ID))
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
            ViewData["resto_ID"] = new SelectList(this._service.getContext().Restaurants, "ID", "nom", note.resto_ID);
            return View(note);
        }

        // GET: Notes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note = this._service.getThisNote(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            this._service.deleteNote(id);
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return this._service.doesNoteExists(id);
        }
    }
}
