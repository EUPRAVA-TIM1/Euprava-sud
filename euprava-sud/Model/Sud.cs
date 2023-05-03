using System.Collections;

namespace eUprava.Court.Model
{
    public class Sud
    {
        public Guid ID { get; set; }
        public List<Sudija> Sudije { get; set; } = new List<Sudija>();
        public Opstina Opstina { get; set; }
        public List<Rociste> Rocista { get; set; } = new List<Rociste>();
    }
}
