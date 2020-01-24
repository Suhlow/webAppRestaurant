using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.data.Models
{
    public class Adresse
    {
        public int ID { get; set; }
       
        public int num_voie { get; set; }
        public string rue { get; set; }
        public int cp { get; set; }
        public string ville { get; set; }

        [ForeignKey("Restaurant")]
        public int resto_ID { get; set; }
        public Restaurant resto { get; set; }

    }
}
