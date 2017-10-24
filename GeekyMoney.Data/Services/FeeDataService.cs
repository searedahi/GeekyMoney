using System.Collections.Generic;
using AutoMapper;
using GeekyMoney.Data;
using GeekyMoney.Model;
using System.Linq;

namespace GeekyMoney.Data.Services
{
    public class FeeDataService : IFeeDataService
    {
        private GeekyMoneyContext _context;
        private IMapper _mapper;

        public FeeDataService(GeekyMoneyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IFee Create(IFee domainModel)
        {
            var dbFee = _mapper.Map<Fee, Data.Model.Fee>(domainModel as Fee);

            _context.Fee.Add(dbFee);
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.Fee, Fee>(dbFee);
        }

        public bool Delete(int id)
        {
            var dbRecordToRemove = _context.Fee.FirstOrDefault(p => p.ID.Equals(id));
            _context.Remove(dbRecordToRemove);
            var recordCount = _context.SaveChanges();
            return recordCount > 0;
        }

        public IFee Get(int id)
        {
            var dbFee = _context.Fee.FirstOrDefault(p => p.ID.Equals(id));
            var domModel = _mapper.Map<Data.Model.Fee, Fee>(dbFee);
            return domModel;
        }

        public IEnumerable<IFee> GetAll()
        {
            var fees = new List<IFee>();

            foreach (var fee in _context.Fee.ToList())
            {
                var domainFee = _mapper.Map<Data.Model.Fee, Fee>(fee);
                fees.Add(domainFee);
            }

            return fees;
        }

        public IFee Update(IFee domainModel)
        {
            var dbFee = _mapper.Map<Fee, Data.Model.Fee>(domainModel as Fee);

            _context.Fee.Attach(dbFee);
            _context.Entry(dbFee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Data.Model.Fee, Fee>(dbFee);
        }
    }
}
