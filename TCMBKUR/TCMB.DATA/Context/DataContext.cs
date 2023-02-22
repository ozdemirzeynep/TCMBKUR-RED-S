using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCMB.DATA.Configurations;
using TCMB.DATA.Models;

namespace TCMB.DATA.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<RequestData> RequestData { get; set; }
        public DbSet<ResponseData> ResponseData { get; set; }
        public DbSet<ResponseDataKur> ResponseDataKur { get; set; }
        public DbSet<Kurlar> Kurlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<AppUser>(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration<RequestData>(new RequestDataConfiguration());
        }
    }
}
