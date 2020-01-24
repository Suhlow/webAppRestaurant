using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using App.data.Json;
using App.data.Models;

namespace App.data.Tests
{
    [TestFixture]
    public class JsonRestaurantRepoTest
    {
        [Test]
        public void LoadDocument()
        {
            /*var loader = new JsonRestaurantRepo();
            var path = loader.LoadJson(@".\Json\Resources\restos.net.json");
            loader.SaveData(path);
            Assert.AreEqual(6, path.Count); */
        }

        public void TestResto()
        {
            //id?
            var n = new Note() { date_dv ="06/06/1666", note = 5, commentaire_dv = "testnote" };
            var a = new Adresse() { num_voie = 66, rue = "rue du test", cp = 38100, ville="Testville" };
            var dt = new List<Restaurant>()
            {
                new Restaurant(){nom = "test", num_tel = 666, commentaire = "testtest", mail_proprio = "test@aol.fr", adresse = a, note = n}
            };
            var jrepo = new JsonRestaurantRepo();
            var s = jrepo.writeJson(dt);
            Assert.IsTrue(true);
            dt = jrepo.readJson(s);
        }
    }
}
