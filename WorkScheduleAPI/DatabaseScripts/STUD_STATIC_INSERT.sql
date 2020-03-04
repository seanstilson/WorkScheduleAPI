/*************************************************************************************************************
Department static data insert
*************************************************************************************************************/
--select * from Department
INSERT INTO dbo.Department
(
    DepartmentId
    ,DepartmentName
)
SELECT              '05077f40-e51e-4f26-9205-47bb05a9aea7','Project Management'     
UNION ALL SELECT    'cd30052f-5e12-43f3-8f90-49b6c40ab572','Design'
UNION ALL SELECT    '211c6eb3-e628-4ef9-8700-9cfd505eac98','Production'
UNION ALL SELECT    '8fc930a7-16ad-402c-939d-a2643da1afdd','Transportation'
UNION ALL SELECT    '0d2dfed9-a922-44e2-a283-6721bf2d09fc','Final Review'

/*************************************************************************************************************
BuildingSystemCode static data insert
*************************************************************************************************************/
--select * from BuildingSystemCode
INSERT INTO dbo.BuildingSystemCode
(
    BuildingSystemCodeId
    ,Code
    ,FullName
)

--BASEMENT
SELECT              1,      'B1',       'Basement Walls'     

--FLOOR
UNION ALL SELECT    2,      'F01',      'First Level Floor Deck or Truss'     
UNION ALL SELECT    3,      'F02',      'Second Level Floor Deck or Truss' 
UNION ALL SELECT    4,      'F03',      'Third Level Floor Deck or Truss' 
UNION ALL SELECT    5,      'F04',      'Fourth Level Floor Deck or Truss' 
UNION ALL SELECT    6,      'F05',      'Fifth Level Floor Deck or Truss' 
UNION ALL SELECT    7,      'F06',      'Sixth Level Floor Deck or Truss' 
UNION ALL SELECT    8,      'F07',      'Seventh Level Floor Deck or Truss' 
UNION ALL SELECT    9,      'F08',      'Eighth Level Floor Deck or Truss' 
UNION ALL SELECT    10,     'F09',      'Ninth Level Floor Deck or Truss' 
UNION ALL SELECT    11,     'F10',      'Tenth Level Floor Deck or Truss' 

--WALLS
UNION ALL SELECT    12,     'W01',      'First Level Walls'  
UNION ALL SELECT    13,     'W02',      'Second Level Walls' 
UNION ALL SELECT    14,     'W03',      'Third Level Walls' 
UNION ALL SELECT    15,     'W04',      'Fourth Level Walls' 
UNION ALL SELECT    16,     'W05',      'Fifth Level Walls' 
UNION ALL SELECT    17,     'W06',      'Sixth Level Walls' 
UNION ALL SELECT    18,     'W07',      'Seventh Level Walls' 
UNION ALL SELECT    19,     'W08',      'Eighth Level Walls' 
UNION ALL SELECT    20,     'W09',      'Ninth Level Walls' 
UNION ALL SELECT    21,     'W10',      'Tenth Level Walls' 

--ROOF TRUSSES
UNION ALL SELECT    22,     'RT',        'Roof Trussses'  
