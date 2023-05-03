using eUprava.Court.Model;

namespace euprava_sud.Model
{
    public class OdlukaSudije
    {
        public Guid ID { get; set; }
        public Boolean OduzimanjeVozacke { get; set; } = false;
        public Int16 OduzimanjeBodova { get; set; } = 0;
        public Double NovcanaKazna { get; set; } = 0.0;

        public string Resenje { get; set; }

        public Sudija Sudija { get; set; }
        public Rociste Rociste { get; set; }
        public Predmet Predmet { get; set; }
    }
}
