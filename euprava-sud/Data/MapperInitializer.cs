using AutoMapper;
using eUprava.Court.Model;
using euprava_sud.Model;

namespace euprava_sud.Data
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Dokument, Dokument>().ReverseMap();
            CreateMap<Gradjanin, Gradjanin>().ReverseMap();
            CreateMap<OdlukaSudije, OdlukaSudije>().ReverseMap();
            CreateMap<Opstina, Opstina>().ReverseMap();
            CreateMap<Predmet, Predmet>().ReverseMap();
            CreateMap<PrekrsajnaPrijava, PrekrsajnaPrijava>().ReverseMap();
            CreateMap<Rociste, Rociste>().ReverseMap();
            CreateMap<Sud, Sud>().ReverseMap();
            CreateMap<Sudija, Sudija>().ReverseMap();
        }
    }
}
