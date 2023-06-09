﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUprava.Court.Model
{
    public class Gradjanin
    {
        [Key]
        public string Jmbg { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mail { get; set; }
        public string Broj { get; set; }
        public string Adresa { get; set; }
        [ForeignKey("Opstina")]
        public Guid OpstinaId { get; set; }

        public Opstina Opstina { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
