﻿using System;
using System.Diagnostics;
using WorkScheduleAPI.Database;
using WorkScheduleAPI.Entities;

namespace WorkScheduleAPI.Repositories
{
    public class WorkScheduleItemRepository : IWorkScheduleItemRepository<WorkScheduleItem>
    {
        private StudContext _workScheduleContext;

        public WorkScheduleItemRepository(StudContext context)
        {
            _workScheduleContext = context;
        }

        public bool InsertWorkScheduleItem(WorkScheduleItem item)
        {
            try
            {
                _workScheduleContext.WorkScheduleItem.Add(item);
                _workScheduleContext.SaveChanges();
                return true;
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
