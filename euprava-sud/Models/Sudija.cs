namespace eUprava.Court.Model
{
    public class Sudija : Gradjanin
    {
        public Sud Sud { get; set; }
        public Guid SudId { get; set; }

        public List<PrekrsajnaPrijava> PrekrsajnePrijave { get; set; }
    }
}
