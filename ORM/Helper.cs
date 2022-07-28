using Microsoft.EntityFrameworkCore;
using ORM.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.EF
{
    public static class Helper
    {
        public static ApplicationDbContext GetDbContext(string name)
        {
            var dbOption = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(name).Options;
            var context = new ApplicationDbContext(dbOption);

            return context;
        }
    }
}
