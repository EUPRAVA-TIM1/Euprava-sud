using Microsoft.VisualBasic;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace eUprava.Court.Model
{
    public class Sud
    {
        [Key]
        public Guid SudId { get; set; }
        public string Naziv { get; set; }
        public List<Sudija>? Sudije { get; set; } = new List<Sudija>();
        public Opstina Opstina { get; set; }
        public Guid OpstinaId { get; set; }
        public List<Rociste>? Rocista { get; set; } = new List<Rociste>();
    }
}
