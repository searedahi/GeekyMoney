using AutoMapper;
using GeekyMoney.Model;


namespace GeekyMoney.Services
{
    public class GeekyAutoMapConfig : Profile
    {
        public GeekyAutoMapConfig()
        {
            CreateMap<Data.Model.RealEstateProperty, Model.RealEstateProperty>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Data.Model.Fee, Model.Fee>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Data.Model.RentalRate, Model.RentalRate>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));



        }
    }
}
