using System;
using GeekyMoney.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace GeekyMoney.Angular.Tests
{
    public static class GeekyTestFixtures
    {
        public static GeekyMoneyContext GetMockContext()
        {

            var options = new DbContextOptionsBuilder<GeekyMoneyContext>()
                     .UseInMemoryDatabase(Guid.NewGuid().ToString())
                     .Options;
            var context = new GeekyMoneyContext(options);

            context.Fee.Add(new Data.Model.Fee { Name = "Seed Fee 1", FeeTypeID = 1, IsTemplate = true, Amount = 1, ScheduleTypeID = 1, Description = "Huge description here" });
            context.Fee.Add(new Data.Model.Fee { Name = "Seed Fee 2", FeeTypeID = 1, IsTemplate = false, Amount = 1, ScheduleTypeID = 8, Description = "Huge description here" });

            return context;
        }
    }
}
