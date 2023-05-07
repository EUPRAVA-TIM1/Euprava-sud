﻿using eUprava.Court.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace euprava_sud.Model
{
    public class OdlukaSudije
    {
        [Key]
        public Guid OdlukaSudijeId { get; set; }
        public bool OduzimanjeVozacke { get; set; } = false;
        public int OduzimanjeBodova { get; set; } = 0;
        public double NovcanaKazna { get; set; } = 0.0;

        public string Resenje { get; set; }
       
        public Sudija Sudija { get; set; }
        
        [ForeignKey("Sudija")]
        public string SudijaJmbg { get; set; }
        public Rociste Rociste { get; set; }
        public Guid RocisteId { get; set; }
        public Predmet Predmet { get; set; }
        public Guid PredmetId { get; set; }
    }
}