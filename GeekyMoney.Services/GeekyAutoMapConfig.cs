using AutoMapper;
using GeekyMoney.Model;


namespace GeekyMoney.Services
{
    public class GeekyAutoMapConfig : Profile
    {
        public GeekyAutoMapConfig()
        {
            CreateMap<Data.Model.Fee, Fee>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Data.Model.RentalRate, RentalRate>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Data.Model.RealEstateProperty, RealEstateProperty>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            
            CreateMap<Data.Model.Mortgage, Mortgage>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Data.Model.Scenario, Scenario>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
