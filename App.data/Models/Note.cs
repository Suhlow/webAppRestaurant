using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.data.Models
{
    public class Note
    {
        public int ID { get; set; }
       
        public string date_dv { get; set; }
        public int note { get; set; }
        public string commentaire_dv { get; set; }

        [ForeignKey("Restaurant")]
        public int resto_ID { get; set; }
        public Restaurant resto { get; set; }

    }
}
