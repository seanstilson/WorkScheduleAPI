using System;
namespace WorkScheduleAPI.Repositories
{
    public interface IJobScheduleRepository<T>
    {
        bool InsertJobSchedule(T schedule);
    }
}
