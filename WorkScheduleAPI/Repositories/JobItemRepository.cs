using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
                _workContext.JobItem.Add(jobItem);
                _workContext.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return false;
            }

            
        }
        public List<JobItem> GetJobItems(string jobType)
        {
            try
            {
                var jobs = _workContext.JobItem.Where(ji => ji.SelectedJobType == jobType).ToList();
                return jobs;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return null;
            }


        }
    }
}
