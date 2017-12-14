using GeekyMoney.Data;
using GeekyMoney.Model;
using System.Collections.Generic;
using AutoMapper;
using GeekyMoney.Data.Services;
using GeekyMoney.Tools;

namespace GeekyMoney.Services
{
    public class MortgageService : IMortgageService
    {
        private GeekyMoneyContext _context;
        private readonly IMapper _mapper;
        private MortgageDataService _dataService;

        public MortgageService(GeekyMoneyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dataService = new MortgageDataService(_context, _mapper);
        }

        public IMortgage Get(int id)
        {
            return _dataService.Get(id);
        }

        public IEnumerable<IMortgage> GetAll()
        {
            return _dataService.GetAll();
        }

        public IMortgage Create(IMortgage newMortgage)
        {
            return _dataService.Create(newMortgage);
        }

        public IMortgage Update(IMortgage updatedRealEstateProperty)
        {
            return _dataService.Update(updatedRealEstateProperty);
        }

        public bool Delete(int id)
        {
            return _dataService.Delete(id);
        }


        public IEnumerable<PercentOfOption> PercentOfOptions(int id)
        {
            var result = new List<PercentOfOption>();
            Mortgage mortgage;

            if (id > 0)
            {
                mortgage = (Mortgage)_dataService.Get(id);
            }
            else
            {
                mortgage = new Mortgage();
            }

            var opts = new PercentOfOptionBuilder<Mortgage>();

            result = opts.GetPercentOfOptions(mortgage) as List<PercentOfOption>;

            return result;
        }

    }
}
