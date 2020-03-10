using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkScheduleAPI.Entities
{
    [Table("Department", Schema = "dbo")]
    public class Department
    {
        
        [Key]
        public Guid DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

    }
    
       
}
