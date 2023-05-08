using eUprava.Court.Model;
using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;

namespace euprava_sud.Repository
{
    public class GradjaninRepository : GenericRepository<Gradjanin>, IGradjaninRepository
    {
        private readonly DataContext _context;

        public GradjaninRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
