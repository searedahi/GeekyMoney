﻿using GeekyMoney.Data.DTO;
using Microsoft.EntityFrameworkCore;


namespace GeekyMoney.Data
{
    public class GeekyMoneyContext : DbContext
    {
        public DbSet<RealEstateProperty> RealEstateProperty { get; set; }
        
        public GeekyMoneyContext(DbContextOptions<GeekyMoneyContext> options) 
            : base(options) {

        }
    }
}