using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.data.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webAppRestaurants.Controllers
{
    public class JsonController : Controller
    {

        public JsonController(JsonRestaurantRepo jrepo, string path)
        {
        }
        public void importFromLocal()
        {
            var jrepo = new JsonRestaurantRepo();
            var path = jrepo.LoadJson(@"C:\Users\utilisateur\Desktop\livrables\App.Data.Tests\Json\Resources\restos.net.json");
        }
        public void import()
        {
            var jrepo = new JsonRestaurantRepo();
            var dt = Console.ReadLine();
            jrepo.readJson(dt);
        }
        // GET: Json
        public ActionResult Index()
        {
            return View();
        }

    }
}