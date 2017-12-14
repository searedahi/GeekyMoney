using GeekyMoney.Data;
using GeekyMoney.Model;
using System.Collections.Generic;
using AutoMapper;
using GeekyMoney.Data.Services;
using System;
using System.Reflection;
using GeekyMoney.Tools;

namespace GeekyMoney.Services
{
    public class RealEstatePropertyService : IRealEstatePropertyService
    {
        private GeekyMoneyContext _context;
        private readonly IMapper _mapper;
        private RealEstatePropertyDataService _dataService;


        public RealEstatePropertyService(GeekyMoneyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dataService = new RealEstatePropertyDataService(_context, _mapper);
        }

        public IRealEstateProperty Create(IRealEstateProperty domainModel)
        {
            return _dataService.Create(domainModel);
        }

        public bool Delete(int id)
        {
            return _dataService.Delete(id);
        }

        public IRealEstateProperty Get(int id)
        {
            return _dataService.Get(id);
        }

        public IEnumerable<IRealEstateProperty> GetAll()
        {
            return _dataService.GetAll();
        }

        public IRealEstateProperty Update(IRealEstateProperty domainModel)
        {
            return _dataService.Update(domainModel);
        }

        public IEnumerable<PercentOfOption> PercentOfOptions(int id)
        {
            var result = new List<PercentOfOption>();
            RealEstateProperty targetRealProp;

            if (id > 0)
            {
                targetRealProp = (RealEstateProperty) _dataService.Get(id);
            }
            else
            {
                targetRealProp = new RealEstateProperty();
            }

            var opts = new PercentOfOptionBuilder<RealEstateProperty>();

            result = opts.GetPercentOfOptions(targetRealProp) as List<PercentOfOption>;

            return result;
        }
    }
}
