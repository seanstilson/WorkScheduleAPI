using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkScheduleAPI.Entities
{
    [Table("JobItem", Schema="dbo")]
    public class JobItem
    {
        [Key]
        public Guid JobItemId { get; set; }

        [Required]
        public string JobName { get; set; }

        [Required]
        public string SelectedJobType { get; set; }

        [Required]
        public string SelectedPhase { get; set; }

        [Required]
        public string SelectedBuildingSystem { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        public int RountTripMiles { get; set; }

        public bool HasWindows { get; set; }
        public bool WindowsInstalled { get; set; }

        public DateTime WindowDeliveryDate { get; set; }

        public Double WallBoardFeet { get; set; }

        public Double FloorSquareFeet { get; set; }
            
        }
}
