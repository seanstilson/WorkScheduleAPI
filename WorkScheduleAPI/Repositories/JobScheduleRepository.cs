using System;
using System.Diagnostics;
using WorkScheduleAPI.Database;
using WorkScheduleAPI.Entities;

namespace WorkScheduleAPI.Repositories
{
    public class JobScheduleRepository : IJobScheduleRepository<JobSchedule>
    {
        private StudContext _workScheduleContext;

        public JobScheduleRepository(StudContext context)
        {
            _workScheduleContext = context;
        }

        public bool InsertJobSchedule(JobSchedule schedule)
        {
            try
            {
                _workScheduleContext.JobSchedule.Add(schedule);
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
