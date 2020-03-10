using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Data.SqlClient;
using WorkScheduleAPI.Database;
using WorkScheduleAPI.Extensions;

namespace WorkScheduleAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository<Entities.Department>
    {
        readonly StudContext _studContext;

        public DepartmentRepository(StudContext context)
        {
            _studContext = context;
        }


        public List<Models.Department> GetDepartments()
        {
            try
            {
                List<Entities.Department> departments = _studContext.Department.ToList();
                return departments.ToModels();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }





    }
}
