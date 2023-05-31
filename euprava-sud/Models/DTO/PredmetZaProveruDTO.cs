using eUprava.Court.Model.Enumerations;
using eUprava.Court.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace euprava_sud.Models.DTO
{
    public class PredmetZaProveruDTO
    {
        public Guid PredmetId { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now;
        public string Naslov { get; set; }
        public string Opis { get; set; }
        public string? OptuzeniJmbg { get; set; }
        public StatusPredmeta Status { get; set; }

    }
}
