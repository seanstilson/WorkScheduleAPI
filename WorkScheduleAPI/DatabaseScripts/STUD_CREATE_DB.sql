--CREATE DATABASE STUD;
USE STUD;

/*************************************************************************************************************
STUD CLEANUP
*************************************************************************************************************/
IF OBJECT_ID('dbo.WorkScheduleItem')    IS NOT NULL     DROP TABLE dbo.WorkScheduleItem;
IF OBJECT_ID('dbo.Assignee')            IS NOT NULL     DROP TABLE dbo.Assignee;
IF OBJECT_ID('dbo.Department')          IS NOT NULL     DROP TABLE dbo.Department;
IF OBJECT_ID('dbo.JobSchedule')         IS NOT NULL     DROP TABLE dbo.JobSchedule;
IF OBJECT_ID('dbo.JobItem')             IS NOT NULL     DROP TABLE dbo.JobItem;

IF OBJECT_ID('dbo.PhaseBuildingSystem') IS NOT NULL     DROP TABLE dbo.PhaseBuildingSystem;
IF OBJECT_ID('dbo.BuildingSystem')      IS NOT NULL     DROP TABLE dbo.BuildingSystem;
IF OBJECT_ID('dbo.BuildingSystemCode')  IS NOT NULL     DROP TABLE dbo.BuildingSystemCode;
IF OBJECT_ID('dbo.Phase')               IS NOT NULL     DROP TABLE dbo.Phase;


/*************************************************************************************************************
JobItem: characteristics that describe a Job (aka like a residential house)
*************************************************************************************************************/
CREATE TABLE JobItem 
(
    JobItemId                   UNIQUEIDENTIFIER            NOT NULL PRIMARY KEY
    ,JobName                    VARCHAR(255)                NOT NULL
    ,SelectedJobType            VARCHAR(25)                 NOT NULL
    ,SelectedPhase              VARCHAR(25)                 NOT NULL
    ,SelectedBuildingSystem     VARCHAR(25)                 NOT NULL
    ,DeliveryDate               DATE                        NOT NULL
    ,RoundTripMiles             INT 
    ,HasWindows                 BIT
    ,WindowsInstalled           BIT
    ,WindowDeliveryDate         DATE
    ,WallBoardFeet              FLOAT
    ,FloorSquareFeet            FLOAT
);


/*************************************************************************************************************
JobSchedule: The master table that represents a Job
*************************************************************************************************************/
CREATE TABLE JobSchedule
(
    JobScheduleId               UNIQUEIDENTIFIER            NOT NULL PRIMARY KEY
    ,JobItemId                  UNIQUEIDENTIFIER            NOT NULL                    --one job item

    ,CONSTRAINT FK_JobSchedule_JobItemId                    FOREIGN KEY (JobItemId)         REFERENCES dbo.JobItem(JobItemId)
)

/*************************************************************************************************************
Department: Define all Departements that exist
*************************************************************************************************************/
--Add Department Conroller with GET for this
CREATE TABLE dbo.Department
(
    DepartmentId                UNIQUEIDENTIFIER            NOT NULL PRIMARY KEY
    ,DepartmentName             VARCHAR(255)                NOT NULL            
);



/*************************************************************************************************************
Assignee: defines an individual and the department they are assigned too
*************************************************************************************************************/
--Add Assignee Controller with GetAll
--GetByDepartment(DepartmentId)
CREATE TABLE dbo.Assignee
(
    AssigneeId                  UNIQUEIDENTIFIER            NOT NULL PRIMARY KEY
    ,DepartmentId               UNIQUEIDENTIFIER            NOT NULL                    --FK to Department
    ,AssigneeName               VARCHAR(255)                NULL     
    ,Capacity                   INT                         NULL

    ,CONSTRAINT FK_Assignee_DepartmentId                    FOREIGN KEY (DepartmentId)      REFERENCES dbo.Department(DepartmentId)
);

/*************************************************************************************************************
WorkScheduleItem:  Defines which Department and Assignee that are associated with a JobSchedule
*************************************************************************************************************/
CREATE TABLE dbo.WorkScheduleItem
(
    WorkScheduleItemId          UNIQUEIDENTIFIER            NOT NULL PRIMARY KEY
    ,JobScheduleId              UNIQUEIDENTIFIER            NOT NULL                    --FK JobSchedule                 
    ,DepartmentId               UNIQUEIDENTIFIER            NOT NULL                    --FK Department     
    ,AssigneeId                 UNIQUEIDENTIFIER            NOT NULL                    --FK Assignee
    ,ItemName                   VARCHAR(255)                                    
    ,Description                VARCHAR(MAX)        
    ,WorkSchduleItemFrom        DATETIME                                       
    ,WorkScheduleItemTo         DATETIME                                       
    ,WorkSchduleItemFromTime    BIGINT                                       
    ,WorkScheduleItemToTime     BIGINT                                       
    ,Color                      VARCHAR(25)
    ,IsAllDay                   BIT
    ,EstimatedBoardFeet         INT
    
    

    ,CONSTRAINT FK_WorkScheduleItem_JobScheduleId           FOREIGN KEY (JobScheduleId)     REFERENCES dbo.JobSchedule(JobScheduleId)
    ,CONSTRAINT FK_WorkScheduleItem_DepartmentId            FOREIGN KEY (DepartmentId)      REFERENCES dbo.Department(DepartmentId)
    ,CONSTRAINT FK_WorkScheduleItem_AssigneeId              FOREIGN KEY (AssigneeId)        REFERENCES dbo.Assignee(AssigneeId)
);

/*************************************************************************************************************
Phase: defines how many phases associated with a JobItemId
*************************************************************************************************************/
CREATE TABLE Phase
(
    PhaseId                     UNIQUEIDENTIFIER    NOT NULL PRIMARY KEY
    ,JobItemId                  INT
    ,PhaseNumber                INT                                   --1,2,3
)

/*************************************************************************************************************
BuildingSystemRef: Prefilled master table of Building System Codes
*************************************************************************************************************/
--create a CONTROLLER with GET for this table
--prefill table
CREATE TABLE BuildingSystemCode
(
    BuildingSystemCodeId        INT                 NOT NULL PRIMARY KEY
    ,Code                       VARCHAR(3)          NOT NULL                    --W1,F1,RT,B1 (only one basement)
    ,FullName                   VARCHAR(100)
)

/*************************************************************************************************************
BuildingSystemInfo:  attch extra info to each Building 
*************************************************************************************************************/
CREATE TABLE BuildingSystem
(
    BuildingSystemId            INT IDENTITY(1,1)   NOT NULL PRIMARY KEY
    ,BuildingSystemCodeId       INT
    ,EstimatedBoardFeet         INT
    ,ActualBoardFeet            INT

    ,CONSTRAINT FK_BuildingSystem_BuildingSystemCodeId          FOREIGN KEY (BuildingSystemCodeId)     REFERENCES dbo.BuildingSystemCode(BuildingSystemCodeId)
)

/*************************************************************************************************************
PhaseBuildingSystem:  A Phase has multiple building systems associated with it, define these relationships
*************************************************************************************************************/
CREATE TABLE PhaseBuildingSystem
(
    PhaseBuildingSystemId       INT IDENTITY (1,1)  NOT NULL PRIMARY KEY
    ,PhaseId                    UNIQUEIDENTIFIER
    ,BuildingSystemId           INT

    ,CONSTRAINT FK_PhaseBuildingSystem_PhaseId                  FOREIGN KEY (PhaseId)               REFERENCES dbo.Phase(PhaseId)
    ,CONSTRAINT FK_PhaseBuildingSystem_BuildingSystemId         FOREIGN KEY (BuildingSystemId)      REFERENCES dbo.BuildingSystem(BuildingSystemId)
)