using AutoMapper;
using System.Collections.Generic;
using GeekyMoney.Data;
using GeekyMoney.Model;
using GeekyMoney.Data.Services;

namespace GeekyMoney.Services
{
    public class RealEstateScenarioService: IRealEstateScenarioService
    {
        private GeekyMoneyContext _context;
        private readonly IMapper _mapper;
        private RealEstateScenarioDataService _dataService;

        public RealEstateScenarioService(GeekyMoneyContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _dataService = new RealEstateScenarioDataService(_context, _mapper);
        }

        public IRealEstateScenario Create(IRealEstateScenario domainModel)
        {
            return _dataService.Create(domainModel);
        }

        public bool Delete(int id)
        {
            return _dataService.Delete(id);
        }

        public IRealEstateScenario Get(int id)
        {
            return _dataService.Get(id);
        }

        public IEnumerable<IRealEstateScenario> GetAll()
        {
            return _dataService.GetAll();
        }

        public IRealEstateScenario Update(IRealEstateScenario domainModel)
        {
            return _dataService.Update(domainModel);
        }
    }
}