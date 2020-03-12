using System;
using System.Collections.Generic;

namespace WorkScheduleAPI.Extensions
{
    public static class BuildingSystemCodeExtension
    {

        public static Models.BuildingSystemCode ToModel(this Entities.BuildingSystemCode entity)
        {
            Models.BuildingSystemCode model = new Models.BuildingSystemCode()
            {
                BuildingSystemCodeId    = entity.BuildingSystemCodeId,
                Code                    = entity.Code,
                FullName                = entity.FullName
            };

            return model;
        }


        //Convert List of Entities to List of Models
        public static List<Models.BuildingSystemCode> ToModels(this List<Entities.BuildingSystemCode> entities)
        {
            List<Models.BuildingSystemCode> newBuildingSystemCode = new List<Models.BuildingSystemCode>();

            foreach (Entities.BuildingSystemCode oldBuildingSystemCode in entities)
            {
                newBuildingSystemCode.Add(oldBuildingSystemCode.ToModel());
            }
            return newBuildingSystemCode;
        }

    }
}
