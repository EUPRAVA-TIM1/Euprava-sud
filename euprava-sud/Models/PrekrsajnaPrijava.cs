using eUprava.Court.Model.Enumerations;
using euprava_sud.Model.Enumerations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUprava.Court.Model
{
    public class PrekrsajnaPrijava
    {
        [Key]
        public Guid PrekrsajnaPrijavaId { get; set; }
        public DateTime Datum { get; set; }
        public string Komentar { get; set; }
        /*public Gradjanin Optuzeni { get; set; }
        [ForeignKey("Optuzeni")]*/
        public string OptuzeniJmbg { get; set; }
        /*public Gradjanin PrijavljenoOd { get; set; }
        [ForeignKey("PrijavljenoOd")]*/
        public string PrijavljenoOdJmbg { get; set; }
        /*public List<Gradjanin> Svedoci { get; set; } = new List<Gradjanin>();*/
        public Sudija Sudija { get; set; }
        
        [ForeignKey("Sudija")]
        public string SudijaJmbg { get; set; }

        public Opstina Opstina { get; set; }
        public Guid OpstinaId { get; set; }
        public Prekrsaj Prekrsaj { get; set; }
        public Guid PrekrsajId { get; set; }
        public List<Dokument> Dokumenti { get; set; } = new List<Dokument>();
        [DefaultValue(StatusPrekrsajnePrijave.AKTIVAN)]
        public StatusPrekrsajnePrijave StatusPrekrsajnePrijave { get; set; }
    }
}
