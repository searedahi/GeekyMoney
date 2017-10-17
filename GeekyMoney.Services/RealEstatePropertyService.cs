using GeekyMoney.Data;
using GeekyMoney.Model;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace GeekyMoney.Services
{
    public class RealEstatePropertyService : IRealEstatePropertyService
    {
        private GeekyMoneyContext _context;
        private readonly IMapper _mapper;


        public RealEstatePropertyService(GeekyMoneyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IRealEstateProperty Get(int id)
        {
            var dbRealProp = _context.RealEstateProperty
                .Include(p=>p.PropertyFees)
                .FirstOrDefault(p => p.ID.Equals(id));
            var domModel = _mapper.Map<Data.Model.RealEstateProperty, RealEstateProperty>(dbRealProp);
            return domModel;
        }

        public IEnumerable<IRealEstateProperty> GetAll()
        {
            var realProperties = new List<IRealEstateProperty>();

            foreach (var realProp in _context.RealEstateProperty.ToList())
            {
                var domainRealProp = _mapper.Map<Data.Model.RealEstateProperty, RealEstateProperty>(realProp);
                realProperties.Add(domainRealProp);
            }

            return realProperties;
        }

        public IRealEstateProperty Create(IRealEstateProperty domainModel)
        {
            var dbRealEstateProperty = _mapper.Map<RealEstateProperty, Data.Model.RealEstateProperty>(domainModel as RealEstateProperty);

            _context.RealEstateProperty.Add(dbRealEstateProperty);
            var recordCount = _context.SaveChanges();
            
            return _mapper.Map<Data.Model.RealEstateProperty, RealEstateProperty>(dbRealEstateProperty);
        }

        public IRealEstateProperty Update(IRealEstateProperty domainModel)
        {
            var dbRealEstateProperty = _mapper.Map<RealEstateProperty, Data.Model.RealEstateProperty>(domainModel as RealEstateProperty);

            _context.RealEstateProperty.Attach(dbRealEstateProperty);
            _context.Entry(dbRealEstateProperty).State = EntityState.Modified;
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.RealEstateProperty, RealEstateProperty>(dbRealEstateProperty);
        }

        public bool Delete(int id)
        {
            var dbRecordToRemove = _context.RealEstateProperty.FirstOrDefault(p => p.ID.Equals(id));
            _context.Remove(dbRecordToRemove);
            var recordCount = _context.SaveChanges();
            return recordCount > 0;
        }
    }
}
