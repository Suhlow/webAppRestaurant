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
using App.data.Json;

namespace webAppRestaurants.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestaurantContext _context;
        private RestaurantService _service;

        public RestaurantsController(RestaurantContext context, RestaurantService service)
        {
            this._service = service;
            _context = context;
        }

        //Import JSON
        public IActionResult import()
        {
            _service.importJson();
            return RedirectToAction(nameof(Index));
        }

        //Export JSON
        public IActionResult export()
        {
            _service.exportRestoToJSON();
            return RedirectToAction(nameof(Index));
        }

        // GET: Restaurants
        public IActionResult Index(){ var restaurants = _service.getAll();  return View(restaurants);}

        // GET: Restaurants/Details/5
        public IActionResult Details(int? id){return View( _service.getThisResto(id));}

        // GET: Restaurants/Create
        public IActionResult Create(){return View();}

        // POST: Restaurants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,nom,num_tel,commentaire,mail_proprio, note, adresse")] Restaurant restaurant){
            _service.create(restaurant);
            return RedirectToAction(nameof(Index));
        }

        // GET: Restaurants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var restaurant = _service.getThisResto(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,nom,num_tel,commentaire,mail_proprio,note, adresse")] Restaurant restaurant){
            _service.update(id, restaurant);
            return RedirectToAction(nameof(Index));
        }

        // GET: Restaurants/Delete/5
        public IActionResult Delete(int? id){return View();}

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _service.doesRestaurantExists(id);
        }
    }
}
