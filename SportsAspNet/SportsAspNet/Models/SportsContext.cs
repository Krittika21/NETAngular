using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAspNet.Models
{
    public class SportsContext: DbContext
    {
        public SportsContext(DbContextOptions<SportsContext> options):base(options)
        {

        }
        public DbSet<Users> User { get; set; }
        public DbSet<TestDetailsList> TestDetails { get; set; }
        public DbSet<TestType> TestType { get; set; }
        public DbSet<UserTypeMap> UserTestMap { get; set; }
        public DbSet<TestTypeMap> TestTypeMap { get; set; }
    }
}
