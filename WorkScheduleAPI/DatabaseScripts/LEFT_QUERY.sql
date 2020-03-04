--USE STUD;
select * from JobItem
--delete from JobItem
select * from JobSchedule
--delete from JobSchedule


SELECT JobSchedule.JobScheduleId,JobSchedule.JobScheduleId,JobItem.*
FROM JobItem JobItem
LEFT JOIN JobSchedule JobSchedule
    ON JobItem.JobItemId            = JobSchedule.JobItemId