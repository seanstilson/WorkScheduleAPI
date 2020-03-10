using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Data.SqlClient;
using WorkScheduleAPI.Database;
using WorkScheduleAPI.Extensions;

namespace WorkScheduleAPI.Repositories
{
    public class JobItemRepository : IJobItemRepository<Entities.JobItem>
    {
        readonly StudContext _studContext;

        public JobItemRepository(StudContext context)
        {
            _studContext = context;
        }

        public bool AddJobItemAsync(Entities.JobItem  entity)
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

        public List<Models.JobItem> GetJobItems(string selectedJobType)
        {
            try
            {
                List<Entities.JobItem> jobItems = _studContext.JobItem.Where(w => w.SelectedJobType == selectedJobType).ToList();
                return jobItems.ToModels();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }

    }
}
