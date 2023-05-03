using eUprava.Court.Model.Enumerations;
using euprava_sud.Model.Enumerations;

namespace eUprava.Court.Model
{
    public class PrekrsajnaPrijava
    {
        public Guid ID { get; set; }
        public DateTime Datum { get; set; }
        public string Komentar { get; set; }
        public Gradjanin Optuzeni { get; set; }
        public Gradjanin PrijavljenoOd { get; set; }
        public List<Gradjanin> Svedoci { get; set; } = new List<Gradjanin>();
        public Sudija Sudija { get; set; }

        public Opstina Opstina { get; set; }
        public List<Prekrsaj> Prekrsaji { get; set; } = new List<Prekrsaj>();
        public List<Dokument> Dokumenti { get; set; } = new List<Dokument>();

        public StatusPrekrsajnePrijave StatusPrekrsajnePrijave { get; set; } = StatusPrekrsajnePrijave.AKTIVAN
    }
}
