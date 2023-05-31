using eUprava.Court.Model.Enumerations;
using eUprava.Court.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace euprava_sud.Models.DTO
{
    public class RocisteDTO
    {
        public Guid RocisteId { get; set; }
        public DateTime DatumRocista { get; set; }
        public string? OptuzeniJmbg { get; set; }
        public string? AdvokatJmbg { get; set; }
        public Predmet? Predmet { get; set; }
        public Sudija? Sudija { get; set; }
        public Sud? Sud { get; set; }
        public IshodRocista IshodRocista { get; set; }
    }
}
