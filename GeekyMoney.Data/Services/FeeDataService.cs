using System.Collections.Generic;
using AutoMapper;
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
            var dbFee = _mapper.Map<Fee, Model.Fee>(domainModel as Fee);

            _context.Fee.Add(dbFee);
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Model.Fee, Fee>(dbFee);
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
            var domModel = _mapper.Map<Model.Fee, Fee>(dbFee);
            return domModel;
        }

        public IEnumerable<IFee> GetAll()
        {
            var fees = new List<IFee>();
            var feesFromDb= _context.Fee.Where(f=>f.IsTemplate == false).ToList();

            foreach (var fee in feesFromDb)
            {
                var domainFee = _mapper.Map<Model.Fee, Fee>(fee);
                fees.Add(domainFee);
            }

            return fees;
        }

        public IEnumerable<IFee> GetTemplates()
        {
            var fees = new List<IFee>();
            var feesFromDb = _context.Fee.Where(f => f.IsTemplate == true).ToList();

            foreach (var fee in feesFromDb)
            {
                var domainFee = _mapper.Map<Model.Fee, Fee>(fee);
                fees.Add(domainFee);
            }

            return fees;
        }

        public IEnumerable<IFee> GetAllByFeeType(int feeTypeId, bool isTemplate = false)
        {
            var fees = new List<IFee>();
            var feesByType = _context.Fee.Where(f => f.FeeTypeID == feeTypeId && f.IsTemplate == isTemplate).ToList();

            foreach (var fee in feesByType)
            {
                var domainFee = _mapper.Map<Model.Fee, Fee>(fee);
                fees.Add(domainFee);
            }

            return fees;
        }

        /// <summary>
        /// Takes in a template and creates a non template copy.
        /// </summary>
        /// <param name="feeTypeId"></param>
        /// <param name="isTemplate"></param>
        /// <returns></returns>
        public IFee CloneTemplate(int templateId, int parentObjectId)
        {
            var feeTemplate = _context.Fee.FirstOrDefault(f => f.ID == templateId);

            var clonedFee = feeTemplate;
            clonedFee.IsTemplate = false;

            switch (clonedFee.FeeTypeID)
            {
                case 1:
                    clonedFee.RealEstatePropertyID = parentObjectId;
                    break;
                case 2:
                    clonedFee.MortgageID = parentObjectId;
                    break;
                default:
                    break;
            }

            _context.Add(clonedFee);
            var recordCount = _context.SaveChanges();
            var domainFee = _mapper.Map<Model.Fee, Fee>(clonedFee);
            return domainFee;
        }


        public IFee Update(IFee domainModel)
        {
            var dbFee = _mapper.Map<Fee, Model.Fee>(domainModel as Fee);

            _context.Fee.Attach(dbFee);
            _context.Entry(dbFee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var recordCount = _context.SaveChanges();

            return _mapper.Map<Model.Fee, Fee>(dbFee);
        }
    }
}
