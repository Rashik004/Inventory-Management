using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPool.DAL
{
    using System.Data.Entity;

    using PcPool.DAL.Models;

    public class PcPoolEntities:DbContext
    {
        public PcPoolEntities()
            : base("name=pcPoolConnectionString")
        {

        }

        public DbSet<PcPoolModels.DeviceInstance> DeviceInstances { get; set; }

        public DbSet<PcPoolModels.DeviceStatus> DeviceStatus { get; set; }

        public DbSet<PcPoolModels.User> Users { get; set; }

        public DbSet<PcPoolModels.UserType> UserTypes { get; set; }

        public DbSet<PcPoolModels.DeviceStatusHistory> DeviceStatusHistories { get; set; }

        public DbSet<PcPoolModels.DeviceType> DeviceTypes { get; set; }

        public DbSet<PcPoolModels.ReservationList> ReservationLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // PostgreSQL uses the public schema by default - not dbo.
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
