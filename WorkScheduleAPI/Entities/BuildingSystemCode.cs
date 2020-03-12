using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkScheduleAPI.Entities
{
    [Table("BuildingSystemCode", Schema = "dbo")]
    public class BuildingSystemCode
    {

        [Key]
        public int BuildingSystemCodeId { get; set; }

        [Required]
        public string Code { get; set; }


        public string FullName { get; set; }


    }
}
