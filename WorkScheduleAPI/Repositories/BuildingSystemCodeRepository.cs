using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Data.SqlClient;
using WorkScheduleAPI.Database;
using WorkScheduleAPI.Extensions;

namespace WorkScheduleAPI.Repositories
{
    public class BuildingSystemCodeRepository : IBuildingSystemCodeRepository<Entities.BuildingSystemCode>
    {
        readonly StudContext _studContext;

        public BuildingSystemCodeRepository(StudContext context)
        {
            _studContext = context;
        }

        public List<Models.BuildingSystemCode> GetBuildingSystemCodes()
        {
            try
            {
                List<Entities.BuildingSystemCode> buildingSystemCodes = _studContext.BuildingSystemCode.ToList();
                return buildingSystemCodes.ToModels();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }

    }
}
