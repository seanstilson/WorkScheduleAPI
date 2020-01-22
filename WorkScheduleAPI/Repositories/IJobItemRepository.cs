using System;
using System.Threading.Tasks;

namespace WorkScheduleAPI.Repositories
{
    public interface IJobItemRepository<T>
    {
        bool AddJobItemAsync(T jobItem);
    }
}
