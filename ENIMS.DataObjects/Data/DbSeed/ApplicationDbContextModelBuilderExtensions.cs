using ENIMS.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.DataObjects
{
    public static class ApplicationDbContextModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Currency Format
            //modelBuilder.Entity<CurrencyFormat>().HasData(
            //        new CurrencyFormat { Id = 1, Name = "comma", Format = ",", RecordStatus = RecordStatus.Active, StartDate = DateTime.Now, EndDate = DateTime.MaxValue, UpdatedBy = "Default" },
            //   new CurrencyFormat { Id = 2, Name = "dot", Format = ".", RecordStatus = RecordStatus.Active, StartDate = DateTime.Now, EndDate = DateTime.MaxValue, UpdatedBy = "Default" },
            //   new CurrencyFormat { Id = 3, Name = "space", Format = " ", RecordStatus = RecordStatus.Active, StartDate = DateTime.Now, EndDate = DateTime.MaxValue, UpdatedBy = "Default" }
            //    );


        }
    }
}
