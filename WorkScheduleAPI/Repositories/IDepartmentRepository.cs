using System;
using System.Collections.Generic;

namespace WorkScheduleAPI.Repositories
{
    public interface IDepartmentRepository<T>
    {
        //bool AddDepartmentAsync(T department);

        List<Models.Department> GetDepartments();
    }
}
