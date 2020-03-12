using System;
using Microsoft.EntityFrameworkCore;
using WorkScheduleAPI.Entities;

namespace WorkScheduleAPI.Database
{
    public class StudContext : DbContext
    {
        public StudContext(DbContextOptions<StudContext> options) : base(options)
        {
        }

        public DbSet<JobItem> JobItem { get; set; }
        public DbSet<JobSchedule>JobSchedule { get; set; }
        public DbSet<WorkScheduleItem>WorkScheduleItem { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<BuildingSystemCode> BuildingSystemCode { get; set; }
    }
}
