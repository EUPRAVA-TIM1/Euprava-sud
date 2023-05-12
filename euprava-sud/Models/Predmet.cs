using eUprava.Court.Model.Enumerations;
using euprava_sud.Model.Enumerations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUprava.Court.Model
{
    public class Predmet
    {
        [Key]
        public Guid PredmetId { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now;
        public string Naslov { get; set; }
        public string Opis { get; set; }

        public Sudija? Sudija { get; set; }

        [ForeignKey("Sudija")]
        public string? SudijaJmbg { get; set; }
        public string? OptuzeniJmbg { get; set; }

        public Gradjanin? Advokat { get; set; }
        [ForeignKey("Advokat")]
        public string? AdvokatJmbg { get; set; }
        [DefaultValue(StatusPredmeta.OTVOREN)]
        public StatusPredmeta Status { get; set; }

        public PrekrsajnaPrijava? PrekrsajnaPrijava { get; set; }
        public Guid PrekrsajnaPrijavaId { get; set; }
    }
}
