using System;
using WorkScheduleAPI.Models;
using WorkScheduleAPI.Entities;


namespace WorkScheduleAPI.Extensions
{
    public static class JobItemExtension
    {

        public static Entities.JobItemEntity ToEntity(JobItemModel model)
        {
            Entities.JobItemEntity entity = new Entities.JobItemEntity()
            {
                JobItemId               = model.JobItemId,
                JobName                 = model.JobName,
                SelectedJobType         = model.SelectedJobType,
                SelectedPhase           = model.SelectedPhase,
                SelectedBuildingSystem  = model.SelectedBuildingSystem,
                DeliveryDate            = model.DeliveryDate,
                RoundTripMiles          = model.RoundTripMiles,
                HasWindows              = model.HasWindows,
                WindowsInstalled        = model.WindowsInstalled,
                WindowDeliveryDate      = model.WindowDeliveryDate,
                WallBoardFeet           = model.WallBoardFeet,
                FloorSquareFeet         = model.FloorSquareFeet
            };
            
            return entity;

        }
    }
}
