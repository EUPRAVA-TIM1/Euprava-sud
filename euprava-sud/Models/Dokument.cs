using System.ComponentModel.DataAnnotations;

namespace eUprava.Court.Model
{
    public class Dokument
    {
        [Key]
        public Guid DokumentId { get; set; }
        public string URLDokumenta { get; set; }
    }
}
