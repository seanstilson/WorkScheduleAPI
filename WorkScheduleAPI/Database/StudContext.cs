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

        public DbSet<JobItemEntity> JobItem { get; set; }
        public DbSet<JobSchedule>JobSchedule { get; set; }
        public DbSet<WorkScheduleItem>WorkScheduleItem { get; set; }
    }
}
