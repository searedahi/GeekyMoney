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

        public IScenario Create(IScenario domainModel)
        {
            return _dataService.Create(domainModel);
        }

        public bool Delete(int id)
        {
            return _dataService.Delete(id);
        }

        public IScenario Get(int id)
        {
            return _dataService.Get(id);
        }

        public IEnumerable<IScenario> GetAll()
        {
            return _dataService.GetAll();
        }

        public IScenario Update(IScenario domainModel)
        {
            return _dataService.Update(domainModel);
        }
    }
}