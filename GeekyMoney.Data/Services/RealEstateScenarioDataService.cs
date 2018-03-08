using AutoMapper;
using System.Collections.Generic;
using GeekyMoney.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GeekyMoney.Data.Services
{
    public class RealEstateScenarioDataService: IScenarioDataService
    {
        private GeekyMoneyContext _context;
        private readonly IMapper _mapper;

        public RealEstateScenarioDataService(GeekyMoneyContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IScenario Create(IScenario domainModel)
        {
            var dbScenario = _mapper.Map<Scenario, Data.Model.Scenario>(domainModel as Scenario);

            _context.Scenario.Add(dbScenario);
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.Scenario,Scenario>(dbScenario);
        }

        public bool Delete(int id)
        {
            var dbRecordToRemove = _context.Scenario.FirstOrDefault(p => p.ID.Equals(id));
            _context.Remove(dbRecordToRemove);
            var recordCount = _context.SaveChanges();
            return recordCount > 0;
        }

        public IScenario Get(int id)
        {
            var dbScenario = _context.Scenario
                .Include(s=>s.RealEstateProperties)                
                .FirstOrDefault(p => p.ID.Equals(id));
            var domModel = _mapper.Map<Data.Model.Scenario, Scenario>(dbScenario);
            return domModel;
        }

        public IEnumerable<IScenario> GetAll()
        {
            var scenarios = new List<IScenario>();

            foreach (var scen in _context.Scenario.ToList())
            {
                var domainScenario = _mapper.Map<Data.Model.Scenario,Scenario>(scen);
                scenarios.Add(domainScenario);
            }

            return scenarios;
        }

        public IScenario Update(IScenario domainModel)
        {
            var dbScenario = _mapper.Map<Scenario, Data.Model.Scenario>(domainModel as Scenario);

            _context.Scenario.Attach(dbScenario);
            _context.Entry(dbScenario).State = EntityState.Modified;
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.Scenario, Scenario>(dbScenario);
        }
    }
}
