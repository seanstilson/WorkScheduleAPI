using System;
using System.Threading.Tasks;

namespace WorkScheduleAPI.Repositories
{
    public interface IWorkScheduleItemRepository<T>
    {
        bool InsertWorkScheduleItem(T WorkScheduleItem);
    }
}
