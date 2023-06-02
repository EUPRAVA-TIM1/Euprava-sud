using eUprava.Court.Model;
using euprava_sud.Model.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace euprava_sud.Models.DTO
{
    public class OdlukaSudijeDTO
    {
        public Guid OdlukaSudijeId { get; set; }
        public bool OduzimanjeVozacke { get; set; } = false;
        public int OduzimanjeBodova { get; set; } = 0;
        public double NovcanaKazna { get; set; } = 0.0;
        public string Resenje { get; set; }
        public Sudija? Sudija { get; set; }
        public string? OptuzeniJmbg { get; set; }
        public string? AdvokatJmbg { get; set; }
        public Rociste? Rociste { get; set; }
        public Predmet? Predmet { get; set; }
        public StatusPrekrsajnePrijave Status { get; set; }
        public DateTime Datum { get; set; }
    }
}
