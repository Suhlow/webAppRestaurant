using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using App.data.Models;
using App.data.Services;

namespace App.data.Json
{
    public class JsonRestaurantRepo
    {
        private RestaurantService _service;

        public List<Restaurant> LoadJson(string Path)
        {
            var data = File.ReadAllText(path: Path);
            return JsonSerializer.Deserialize<List<Restaurant>>(data);
        }

        public void SaveData(List<Restaurant> data)
        {
            _service.createData(data);
        }

        public string writeJson(List<Restaurant> data) 
        {
            return JsonSerializer.Serialize(data);
        }

        public List<Restaurant> readJson(string data)
        {
            return JsonSerializer.Deserialize<List<Restaurant>>(data);
        }
    }
}
