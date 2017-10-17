using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using GeekyMoney.Data;
using GeekyMoney.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GeekyMoney.Services
{
    public class RealEstateScenarioService: IRealEstateScenarioService
    {
        private GeekyMoneyContext _context;
        private readonly IMapper _mapper;

        public RealEstateScenarioService(GeekyMoneyContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public IRealEstateScenario Create(IRealEstateScenario domainModel)
        {
            var dbScenario = _mapper.Map<RealEstateScenario, Data.Model.Scenario>(domainModel as RealEstateScenario);

            _context.Scenario.Add(dbScenario);
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.Scenario, RealEstateScenario>(dbScenario);
        }

        public bool Delete(int id)
        {
            var dbRecordToRemove = _context.Scenario.FirstOrDefault(p => p.ID.Equals(id));
            _context.Remove(dbRecordToRemove);
            var recordCount = _context.SaveChanges();
            return recordCount > 0;
        }

        public IRealEstateScenario Get(int id)
        {
            var dbScenario = _context.Scenario
                .Include(s=>s.RealEstateProperty)                
                .FirstOrDefault(p => p.ID.Equals(id));
            var domModel = _mapper.Map<Data.Model.Scenario, RealEstateScenario>(dbScenario);
            return domModel;
        }

        public IEnumerable<IRealEstateScenario> GetAll()
        {
            var scenarios = new List<IRealEstateScenario>();

            foreach (var scen in _context.Scenario.ToList())
            {
                var domainScenario = _mapper.Map<Data.Model.Scenario, RealEstateScenario>(scen);
                scenarios.Add(domainScenario);
            }

            return scenarios;
        }

        public IRealEstateScenario Update(IRealEstateScenario domainModel)
        {
            var dbScenario = _mapper.Map<RealEstateScenario, Data.Model.Scenario>(domainModel as RealEstateScenario);

            _context.Scenario.Attach(dbScenario);
            _context.Entry(dbScenario).State = EntityState.Modified;
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.Scenario, RealEstateScenario>(dbScenario);
        }
    }
}
