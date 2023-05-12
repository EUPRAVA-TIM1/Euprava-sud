using eUprava.Court.Model.Enumerations;
using euprava_sud.Model.Enumerations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUprava.Court.Model
{
    public class Rociste
    {
        [Key]
        public Guid RocisteId { get; set; }
        public DateTime DatumRocista { get; set; }
        public string? OptuzeniJmbg { get; set; }
        public string? AdvokatJmbg { get; set; }
        public Predmet? Predmet { get; set; }
        public Guid PredmetId { get; set; }
        public Sudija? Sudija { get; set; }
        [ForeignKey("Sudija")]
        public string? SudijaJmbg { get; set; }
        public Sud? Sud { get; set; }
        [ForeignKey("Sud")]
        public Guid SudId { get; set; }
        [DefaultValue(IshodRocista.ZAKAZANO)]
        public IshodRocista IshodRocista { get; set; }
    }
}
