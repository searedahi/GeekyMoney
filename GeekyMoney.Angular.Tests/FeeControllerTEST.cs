using GeekyMoney.Angular.Controllers;
using GeekyMoney.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AutoMapper;

namespace GeekyMoney.Angular.Tests
{
    [TestClass]
    public class FeeControllerTEST
    {
        private GeekyMoneyContext _testContext;
        private IMapper _autoMapper;

        [TestMethod]
        public void DeleteIsAvailable()
        {
            _testContext = GeekyTestFixtures.GetMockContext();
            _autoMapper = new Mock<IMapper>().Object;
            var feeController = new FeeController(_testContext, _autoMapper);

            feeController.Delete(1);
        }
    }
}
