using App.data.Db;
using App.data.Json;
using App.data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.data.Services
{
    public class RestaurantService
    {
        private RestaurantContext _context;

        public RestaurantService(RestaurantContext ctxt)
        {
            this._context = ctxt;
        }

        /// <summary>
        /// Import JSON to DB from local file 
        /// </summary>
        public void importJson()
        {

            var loader = new JsonRestaurantRepo();
            var path = loader.LoadJson(@".\Resources\restos.net.json");
            createData(path);
        }

        /// <summary>
        /// Export data to JSON, not implemented
        /// </summary>
        public void exportRestoToJSON()
        {
            var restos = this.getAll();
            var writer = new JsonRestaurantRepo();
            writer.writeJson(restos);

        }
        /// <summary>
        /// Gets Context
        /// </summary>
        /// <returns></returns>
        public RestaurantContext getContext()
        {
            return this._context;
        }
        /// <summary>
        /// Gets all restaurants
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> getAll()
        {
            return this._context.Restaurants.Include(r => r.adresse).Include(r => r.note).ToList();
        }

        /// <summary>
        /// gets the five best restaurants
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> getBest()
         {
            var bestResto = this._context.Restaurants.OrderByDescending(r => r.note.note).Take(5).Include(r => r.note).ToList();
            return bestResto;
        }

        /// <summary>
        /// gets all grades
        /// </summary>
        /// <returns></returns>
        public List<Note> getNotes(){
            var notes = this._context.Notes.Include(r => r.resto).ToList();
            return notes;
        }
       
        /// <summary>
        /// create function (used in Json import)
        /// </summary>
        /// <param name="restaurant"></param>
        public void createData(List<Restaurant> restaurant)
        {
            _context.Restaurants.AddRange(restaurant);
            _context.SaveChanges();
        }

        /// <summary>
        /// gets a precise restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Restaurant getThisResto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var restaurant = _context.Restaurants.Include(a=>a.adresse).FirstOrDefault(m => m.ID == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;

        }

        /// <summary>
        /// get a precise grade
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Note getThisNote(int? id)
        {
            var notes = this._context.Notes.Include(r => r.resto).FirstOrDefault(m => m.ID == id);
            return notes;
        }

        /// <summary>
        /// create a restaurant
        /// </summary>
        /// <param name="restaurant"></param>
        public void create(Restaurant restaurant)
        {
                _context.Add(restaurant);
                _context.SaveChanges();
        }

        /// <summary>
        /// create a grade
        /// </summary>
        /// <param name="note"></param>
        public void createNote(Note note)
        {
            this._context.Add(note);
            this._context.SaveChanges();
        }

        /// <summary>
        /// updates a restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="restaurant"></param>
        public void update(int id, Restaurant restaurant)
        {
            var thisRestaurant = this._context.Restaurants.Include(a => a.adresse).Where(a => a.ID == id).First();

            thisRestaurant.nom = restaurant.nom;
            thisRestaurant.num_tel = restaurant.num_tel;
            thisRestaurant.mail_proprio = restaurant.mail_proprio;
            thisRestaurant.adresse.num_voie = restaurant.adresse.num_voie;
            thisRestaurant.adresse.rue = restaurant.adresse.rue;
            thisRestaurant.adresse.cp = restaurant.adresse.cp;
            thisRestaurant.adresse.ville = restaurant.adresse.ville;

            this._context.SaveChanges();
        }
        /// <summary>
        /// updates a grade
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        public void editNote(int id, Note note)
        {
            this._context.Update(note);
            this._context.SaveChanges();
        }

        /// <summary>
        /// delete a restaurant
        /// </summary>
        /// <param name="id"></param>
        public void delete(int? id)
          {
            var resto = this._context.Restaurants.Find(id);
            this._context.Remove(resto);
            this._context.SaveChanges();
          }

        /// <summary>
        /// delete a grade
        /// </summary>
        /// <param name="id"></param>
        public void deleteNote(int id)
        {
            var note = this._context.Notes.Find(id);
            this._context.Remove(note);
            this._context.SaveChanges();
        }

        private  Restaurant NotFound()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// do they tho?
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool doesRestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.ID == id);
        }
        public bool doesNoteExists(int id)
        {
            return _context.Notes.Any(e => e.ID == id);
        }
    }
}
