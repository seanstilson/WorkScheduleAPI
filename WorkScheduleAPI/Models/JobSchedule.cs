using System;
namespace WorkScheduleAPI.Models
{
    public class JobSchedule
    {
        public Guid Id { get; set; }
        public Guid JobItemId { get; set; }

        public WorkScheduleItem DesignItem { get; set; }
        public WorkScheduleItem ProductionItem { get; set; }
        public WorkScheduleItem TransportationItem { get; set;}
        public WorkScheduleItem ReviewItem { get; set; }

        public JobSchedule()
        {
            Id = Guid.NewGuid();
        }
    }
}
