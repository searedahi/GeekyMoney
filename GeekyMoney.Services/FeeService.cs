using System.Collections.Generic;
using AutoMapper;
using GeekyMoney.Data;
using GeekyMoney.Model;
using GeekyMoney.Data.Services;

namespace GeekyMoney.Services
{
    public class FeeService : IFeeService
    {
        private GeekyMoneyContext _context;
        private IMapper _mapper;
        private FeeDataService _dataService;

        public FeeService(GeekyMoneyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dataService = new FeeDataService(_context, _mapper);
        }

        public IFee Create(IFee domainModel)
        {
            return _dataService.Create(domainModel);
        }

        public bool Delete(int id)
        {
            return _dataService.Delete(id);
        }

        public IFee Get(int id)
        {
            return _dataService.Get(id);
        }

        public IEnumerable<IFee> GetAll()
        {
            return _dataService.GetAll();
        }

        public IEnumerable<IFee> GetAllByType(int feeTypeId)
        {
            return _dataService.GetAllByFeeType(feeTypeId, false);
        }

        public IEnumerable<IFee> GetTemplates()
        {
            return _dataService.GetTemplates();
        }

        public IEnumerable<IFee> GetTemplatesByType(int feeTypeId)
        {
            return _dataService.GetAllByFeeType(feeTypeId, true);
        }

        public IFee CloneTemplate(int templateId, int parentObjectId)
        {
            return _dataService.CloneTemplate(templateId, parentObjectId);
        }

        public IFee Update(IFee domainModel)
        {
            return _dataService.Update(domainModel);
        }
    }
}