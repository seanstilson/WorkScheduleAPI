using System;
namespace WorkScheduleAPI.Entities
{
    public class JobSchedule
    {
        public Guid JobItemId { get; set; }
        public Guid JobScheduleId { get; set; }

        public JobSchedule()
        {
        }
    }
}
