using eUprava.Court.Model.Enumerations;

namespace eUprava.Court.Model
{
    public class Predmet
    {
        public Guid ID { get; set; }
        public DateTime Datum { get; set; }
        public string Naslov { get; set; }
        public string Opis { get; set; }

        public Gradjanin Advokat { get; set; }
        public StatusPredmeta Status { get; set; } = StatusPredmeta.OTVOREN;

        public PrekrsajnaPrijava PrekrsajnaPrijava { get; set; }
    }
}
