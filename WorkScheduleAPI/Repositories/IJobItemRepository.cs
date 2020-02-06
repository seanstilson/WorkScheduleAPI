using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkScheduleAPI.Entities;

namespace WorkScheduleAPI.Repositories
{
    public interface IJobItemRepository<T>
    {
        bool AddJobItemAsync(T jobItem);

        List<T> GetJobItems(string jobType);
    }
}
