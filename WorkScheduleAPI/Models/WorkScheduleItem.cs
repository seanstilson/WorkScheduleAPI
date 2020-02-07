using System;
using System.Drawing;


namespace WorkScheduleAPI.Models
{
    public class WorkScheduleItem
    {
        public Guid Id { get; set; }
        public Guid JobScheduleId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public DateTime WorkSchduleItemFrom { get; set; }
        public DateTime OriginalStartDate { get; set; }
        public DateTime WorkScheduleItemTo { get; set; }
        public int WorkSchduleItemFromTime { get; set; }
        public int WorkScheduleItemToTime { get; set; }
        public Color Color { get; set; }
        public Department Department { get; set; }
        public Assignee Assignee { get; set; }
        public bool IsAllDay { get; set; }
        public DateTime OriginalEndDate { get; set; }
        public int EstimatedBoardFeet { get; set; }
        public string Notes => $"Start:{WorkSchduleItemFrom} End: {WorkScheduleItemTo}, Assignee: {Assignee?.AssigneeName}";
        public string BoardFeetString => EstimatedBoardFeet.ToString();

        public WorkScheduleItem()
        {
            IsAllDay = true;
        }
    }
}
