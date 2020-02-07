using System;
using Microsoft.EntityFrameworkCore;
using WorkScheduleAPI.Entities;

namespace WorkScheduleAPI.Database
{
    public class WorkScheduleContext : DbContext
    {
        public WorkScheduleContext(DbContextOptions<WorkScheduleContext> options) : base(options)
        {
        }

        public DbSet<JobItem> JobItem { get; set; }
        public DbSet<JobSchedule>JobSchedule { get; set; }
        public DbSet<WorkScheduleItem>WorkScheduleItem { get; set; }
    }
}
