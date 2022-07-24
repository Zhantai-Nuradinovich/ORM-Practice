using Microsoft.EntityFrameworkCore;
using ORM.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.EF
{
    public static class DbContextCreator
    {
        private static string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ORM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static ApplicationDbContext _dbContext;

        public static ApplicationDbContext GetDbContext()
        {
            if(_dbContext == null)
            {
                var dbOption = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(_connectionString).Options;
                _dbContext = new ApplicationDbContext(dbOption);
            }

            return _dbContext;
        }
    }
}
