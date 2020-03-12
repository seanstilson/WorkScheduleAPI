using System;
using System.Collections.Generic;

namespace WorkScheduleAPI.Repositories
{
    public interface IBuildingSystemCodeRepository<T>
    {
        //bool AddBuildingSystemCodeAsync(T buildingSystemCode);

        List<Models.BuildingSystemCode> GetBuildingSystemCodes();

    }
}
