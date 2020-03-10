﻿using System;
using System.Drawing;
using WorkScheduleAPI;


namespace WorkScheduleAPI.Models
{

    public class JobItem
    {

        public Guid JobItemId { get; set; }
        public string JobName { get; set; }
        public string SelectedJobType { get; set; }
        public string SelectedPhase { get; set; }
        public string SelectedBuildingSystem { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int RoundTripMiles { get; set; }
        public bool HasWindows { get; set; }
        public bool WindowsInstalled { get; set; }
        public DateTime WindowDeliveryDate { get; set; }
        public Double WallBoardFeet { get; set; }
        public Double FloorSquareFeet { get; set; }
      
            
    }

    
}
