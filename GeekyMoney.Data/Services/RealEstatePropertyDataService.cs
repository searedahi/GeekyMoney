using AutoMapper;
using System.Collections.Generic;
using GeekyMoney.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GeekyMoney.Data.Services
{
    public class RealEstatePropertyDataService: IRealEstatePropertyDataService
    {
        private GeekyMoneyContext _context;
        private readonly IMapper _mapper;

        public RealEstatePropertyDataService(GeekyMoneyContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IRealEstateProperty Create(IRealEstateProperty domainModel)
        {
            var dbProperty = _mapper.Map<RealEstateProperty, Data.Model.RealEstateProperty>(domainModel as RealEstateProperty);

            _context.RealEstateProperty.Add(dbProperty);
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.RealEstateProperty, RealEstateProperty>(dbProperty);
        }

        public bool Delete(int id)
        {
            var dbRecordToRemove = _context.RealEstateProperty.FirstOrDefault(p => p.ID.Equals(id));
            _context.Remove(dbRecordToRemove);
            var recordCount = _context.SaveChanges();
            return recordCount > 0;
        }

        public IRealEstateProperty Get(int id)
        {
            var dbProperty = _context.RealEstateProperty
                .Include(s=>s.PropertyFees)                
                .FirstOrDefault(p => p.ID.Equals(id));
            var domModel = _mapper.Map<Data.Model.RealEstateProperty, RealEstateProperty>(dbProperty);
            return domModel;
        }

        public IEnumerable<IRealEstateProperty> GetAll()
        {
            var scenarios = new List<IRealEstateProperty>();

            foreach (var scen in _context.RealEstateProperty.ToList())
            {
                var domainProperty = _mapper.Map<Data.Model.RealEstateProperty, RealEstateProperty>(scen);
                scenarios.Add(domainProperty);
            }

            return scenarios;
        }

        public IRealEstateProperty Update(IRealEstateProperty domainModel)
        {
            var dbProperty = _mapper.Map<RealEstateProperty, Data.Model.RealEstateProperty>(domainModel as RealEstateProperty);

            _context.RealEstateProperty.Attach(dbProperty);
            _context.Entry(dbProperty).State = EntityState.Modified;
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.RealEstateProperty, RealEstateProperty>(dbProperty);
        }
    }
}
