using GeekyMoney.Data;
using GeekyMoney.Model;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace GeekyMoney.Data.Services
{
    public class MortgageDataService : IMortgageDataService
    {
        private GeekyMoneyContext _context;
        private readonly IMapper _mapper;


        public MortgageDataService(GeekyMoneyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IMortgage Get(int id)
        {
            var dbRealProp = _context.Mortgage.FirstOrDefault(p => p.ID.Equals(id));
            var domModel = _mapper.Map<Data.Model.Mortgage, Mortgage>(dbRealProp);
            return domModel;
        }

        public IEnumerable<IMortgage> GetAll()
        {
            var mortgages = new List<IMortgage>();

            foreach (var mortgage in _context.Mortgage.ToList())
            {
                var domainMortgage = _mapper.Map<Data.Model.Mortgage, Mortgage>(mortgage);
                mortgages.Add(domainMortgage);
            }

            return mortgages;
        }

        public IMortgage Create(IMortgage newMortgage)
        {
            var dbMortgage = _mapper.Map<Mortgage, Data.Model.Mortgage>(newMortgage as Mortgage);

            _context.Mortgage.Add(dbMortgage);
            var recordCount = _context.SaveChanges();
            
            return _mapper.Map<Data.Model.Mortgage, Mortgage>(dbMortgage);
        }

        public IMortgage Update(IMortgage updatedRealEstateProperty)
        {
            var dbMortgage = _mapper.Map<Mortgage, Data.Model.Mortgage>(updatedRealEstateProperty as Mortgage);

            _context.Mortgage.Attach(dbMortgage);
            _context.Entry(dbMortgage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.Mortgage, Mortgage>(dbMortgage);
        }

        public bool Delete(int id)
        {
            var dbRecordToRemove = _context.Mortgage.FirstOrDefault(p => p.ID.Equals(id));
            _context.Remove(dbRecordToRemove);
            var recordCount = _context.SaveChanges();
            return recordCount > 0;
        }
    }
}
