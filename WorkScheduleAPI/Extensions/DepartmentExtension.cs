using System;
using System.Collections.Generic;


namespace WorkScheduleAPI.Extensions
{
    public static class DepartmentExtension
    {

        public static Models.Department ToModel(this Entities.Department entity)
        {
            Models.Department model = new Models.Department()
            {
                Id          = entity.DepartmentId,
                name        = entity.DepartmentName
            };

            return model;
        }


        //Convert List of Entities to List of Models
        public static List<Models.Department> ToModels(this List<Entities.Department> entities)
        {
            List<Models.Department> newDepartments = new List<Models.Department>();

            foreach (Entities.Department oldDepartment in entities)
            {
                newDepartments.Add(oldDepartment.ToModel());
            }
            return newDepartments;
        }



    }
}
