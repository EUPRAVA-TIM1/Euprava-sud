using System.ComponentModel.DataAnnotations;

namespace eUprava.Court.Model
{
    public class Opstina
    {
        [Key]
        public Guid OpstinaId { get; set; }
        public int PTT { get; set; }
        public string Naziv { get; set; }
    }
}
