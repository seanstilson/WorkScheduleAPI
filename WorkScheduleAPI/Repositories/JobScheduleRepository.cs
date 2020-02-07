using System;
using System.Diagnostics;
using WorkScheduleAPI.Database;
using WorkScheduleAPI.Entities;

namespace WorkScheduleAPI.Repositories
{
    public class JobScheduleRepository : IJobScheduleRepository<JobSchedule>
    {
        private WorkScheduleContext _workScheduleContext;

        public JobScheduleRepository(WorkScheduleContext context)
        {
            _workScheduleContext = context;
        }

        public bool InsertJobSchedule(JobSchedule schedule)
        {
            try
            {
                _workScheduleContext.JobSchedules.Add(schedule);
                _workScheduleContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
