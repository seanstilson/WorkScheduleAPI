using System;
using System.Collections.Generic;


namespace WorkScheduleAPI.Extensions
{
    public static class JobItemExtension
    {

        public static Entities.JobItem ToEntity(this Models.JobItem  model)
        {
            Entities.JobItem entity = new Entities.JobItem()
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

        public static Models.JobItem ToModel(this Entities.JobItem entity)
        {
            Models.JobItem model = new Models.JobItem()
            {
                JobItemId               = entity.JobItemId,
                JobName                 = entity.JobName,
                SelectedJobType         = entity.SelectedJobType,
                SelectedPhase           = entity.SelectedPhase,
                SelectedBuildingSystem  = entity.SelectedBuildingSystem,
                DeliveryDate            = entity.DeliveryDate,
                RoundTripMiles          = entity.RoundTripMiles,
                HasWindows              = entity.HasWindows,
                WindowsInstalled        = entity.WindowsInstalled,
                WindowDeliveryDate      = entity.WindowDeliveryDate,
                WallBoardFeet           = entity.WallBoardFeet,
                FloorSquareFeet         = entity.FloorSquareFeet
            };

            return model;
        }

        //Convert List of Entities to List of Models
        public static List<Models.JobItem> ToModels(this List <Entities.JobItem> entities)
        {
            List<Models.JobItem> newJobItems = new List<Models.JobItem>();

            foreach (Entities.JobItem oldJobItem in entities)
            {
                newJobItems.Add(oldJobItem.ToModel());
            }
            return newJobItems;
        }




    }
}
