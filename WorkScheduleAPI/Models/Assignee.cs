using System;
namespace WorkScheduleAPI.Models
{
    public class Assignee
    {
        public string AssigneeName { get; set; }
        public Guid Id { get; set; }

        public Assignee()
        {
        }
    }
}
