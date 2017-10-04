﻿using GeekyMoney.Data;
using GeekyMoney.Model;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

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


        public IRealEstateProperty Get(string id)
        {
            var dbRealProp = _context.RealEstateProperty.FirstOrDefault(p => p.ID.ToString().Equals(id));
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

        public IRealEstateProperty Save(IRealEstateProperty newRealEstateProperty)
        {
            var dbRealEstateProperty = _mapper.Map<RealEstateProperty, Data.Model.RealEstateProperty>(newRealEstateProperty as RealEstateProperty);

            _context.RealEstateProperty.Add(dbRealEstateProperty);
            var recordCount = _context.SaveChanges();
            
            return _mapper.Map<Data.Model.RealEstateProperty, RealEstateProperty>(dbRealEstateProperty);
        }

        public IRealEstateProperty Update(IRealEstateProperty updatedRealEstateProperty)
        {
            var dbRealEstateProperty = _mapper.Map<RealEstateProperty, Data.Model.RealEstateProperty>(updatedRealEstateProperty as RealEstateProperty);

            _context.RealEstateProperty.Attach(dbRealEstateProperty);
            _context.Entry(dbRealEstateProperty).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
