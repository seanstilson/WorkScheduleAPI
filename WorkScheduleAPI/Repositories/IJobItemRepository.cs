using System;
using System.Collections.Generic;

namespace WorkScheduleAPI.Repositories
{
    public interface IJobItemRepository<T>
    {
        bool AddJobItemAsync(T jobItem);

        List<Models.JobItem> GetJobItems(string jobType);
    }
}
