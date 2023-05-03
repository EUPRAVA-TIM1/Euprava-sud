using eUprava.Court.Model.Enumerations;

namespace eUprava.Court.Model
{
    public class Rociste
    {
        public Guid ID { get; set; }
        public string OdlukaSudije { get; set; }
        public DateTime DatumRocista { get; set; }

        public Predmet Predmet { get; set; }

        public Sudija Sudija { get; set; }

        public Sud Sud { get; set; }
        public IshodRocista IshodRocista { get; set; } = IshodRocista.ZAKAZANO;
    }
}
