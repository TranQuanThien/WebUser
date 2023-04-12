using AutoMapper;
using BusinessLogic.ViewModels;
using WebSerino.Data;

namespace BusinessLogic.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ActivationViewModel, Activation>().ReverseMap();
            CreateMap<Activation, ActivationViewModel>().ReverseMap();

            CreateMap<SerinoViewModel, Activation>().ReverseMap();
            CreateMap<Activation, SerinoViewModel>().ReverseMap();
        }
    }
}
