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

        public DbSet<JobItem> JobItems { get; set; }
        public DbSet<JobSchedule>JobSchedules { get; set; }
        public DbSet<WorkScheduleItem>WorkScheduleItems { get; set; }
    }
}
