using System;
using System.Drawing;


namespace WorkScheduleAPI.Entities
{
    public class WorkScheduleItem
    {
        public Guid WorkScheduleItemId { get; set; }
        public Guid JobScheduleId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public DateTime WorkSchduleItemFrom { get; set; }
        public DateTime OriginalStartDate { get; set; }
        public DateTime WorkScheduleItemTo { get; set; }
        public int WorkSchduleItemFromTime { get; set; }
        public int WorkScheduleItemToTime { get; set; }
        public string Color { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid AssigneeId { get; set; }
        public bool IsAllDay { get; set; }
        public int EstimatedBoardFeet { get; set; }

        public WorkScheduleItem()
        {
            //IsAllDay = true;
        }
    }
}
