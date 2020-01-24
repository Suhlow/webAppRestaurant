using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.data.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string nom { get; set; }
        public int num_tel { get; set; }
        public string commentaire { get; set; }
        public string mail_proprio { get; set; }
        public virtual Adresse adresse { get; set; }
        public virtual Note note { get; set; }
    }
}
