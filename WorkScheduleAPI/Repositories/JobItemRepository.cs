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
    public class JobItemRepository : IJobItemRepository<JobItemEntity>
    {
        readonly StudContext _studContext;

        public JobItemRepository(StudContext context)
        {
            _studContext = context;
        }

        public bool AddJobItemAsync(JobItemEntity entity)
        {
            try
            {
                _studContext.JobItem.Add(entity);
                _studContext.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return false;
            }

            
        }
        public List<JobItemEntity> GetJobItems(string jobType)
        {
            try
            {
                var jobs = _studContext.JobItem.Where(ji => ji.SelectedJobType == jobType).ToList();
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
