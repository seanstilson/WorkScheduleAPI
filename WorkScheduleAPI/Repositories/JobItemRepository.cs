using System;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using WorkScheduleAPI.Database;
using WorkScheduleAPI.Entities;

namespace WorkScheduleAPI.Repositories
{
    public class JobItemRepository : IJobItemRepository<JobItem>
    {
        readonly WorkScheduleContext _workContext;

        public JobItemRepository(WorkScheduleContext context)
        {
            _workContext = context;
        }

        public bool AddJobItemAsync(JobItem jobItem)
        {
            try
            {
                _workContext.JobItems.Add(jobItem);
                _workContext.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return false;
            }

            
        }
    }
}
