/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2017/3/25 13:31:55                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Payroll') and o.name = 'FK_PAYROLL_RELATIONS_POSITION')
alter table Payroll
   drop constraint FK_PAYROLL_RELATIONS_POSITION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Payroll') and o.name = 'FK_PAYROLL_RELATIONS_POSTRANK')
alter table Payroll
   drop constraint FK_PAYROLL_RELATIONS_POSTRANK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Payroll')
            and   name  = 'Relationship_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Payroll.Relationship_2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Payroll')
            and   name  = 'Relationship_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index Payroll.Relationship_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Payroll')
            and   type = 'U')
   drop table Payroll
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Position')
            and   type = 'U')
   drop table Position
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PostRank')
            and   type = 'U')
   drop table PostRank
go

/*==============================================================*/
/* Table: Payroll                                               */
/*==============================================================*/
create table Payroll (
   SocialSecurityNumber varchar(50)          not null,
   SubordinateNnits     varchar(50)          null,
   Years                varchar(20)          null,
   Name                 varchar(20)          null,
   Position_ID          varchar(200)         null,
   PostRank_ID          varchar(200)         null,
   Coefficient          float                null,
   WhetherOnDuty        int                  null,
   ProbationPeriod      varchar(5)           null,
   WageAttribute        varchar(10)          null,
   PostWage             float                null,
   MonthlyPerformancePay float                null,
   PerformancePay       float                null,
   SeniorityWage        float                null,
   TechnicalAllowance   float                null,
   professionalAllowances float                null,
   QuasiVehicleAllowances float                null,
   PostAllowance        float                null,
   StaffServiceAllowance float                null,
   DustCharge           float                null,
   NightAllowance       float                null,
   HardshipAllowance    float                null,
   TollStationService   float                null,
   SmileStar            float                null,
   JobReplacement       float                null,
   ReplacementPay       float                null,
   PluggingIncome       float                null,
   Other                float                null,
   Reserve1             float                null,
   Reserve2             float                null,
   Subtotal             float                null,
   HighSubsidies        float                null,
   CommunicationSubsidy float                null,
   OvertimePay          float                null,
   Debit                float                null,
   TotalShouldBeIssued  float                null,
   NaturalYearEndPerformance float                null,
   AnnualYearEndPerformance float                null,
   constraint PK_PAYROLL primary key nonclustered (SocialSecurityNumber)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Payroll') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Payroll' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '工资表', 
   'user', @CurrentUser, 'table', 'Payroll'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SocialSecurityNumber')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'SocialSecurityNumber'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '社保编号',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'SocialSecurityNumber'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SubordinateNnits')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'SubordinateNnits'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '下属单位',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'SubordinateNnits'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Years')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Years'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '年月',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Years'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '姓名',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Position_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Position_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所在岗位ID',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Position_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PostRank_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PostRank_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '岗位职级ID',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PostRank_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Coefficient')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Coefficient'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '系数',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Coefficient'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WhetherOnDuty')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'WhetherOnDuty'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否在岗',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'WhetherOnDuty'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProbationPeriod')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'ProbationPeriod'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '试用期',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'ProbationPeriod'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WageAttribute')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'WageAttribute'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '工资属性',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'WageAttribute'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PostWage')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PostWage'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '岗位工资',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PostWage'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MonthlyPerformancePay')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'MonthlyPerformancePay'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '月绩效工资',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'MonthlyPerformancePay'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PerformancePay')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PerformancePay'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '考核绩效工资',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PerformancePay'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SeniorityWage')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'SeniorityWage'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '工龄工资',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'SeniorityWage'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TechnicalAllowance')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'TechnicalAllowance'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '技术津贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'TechnicalAllowance'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'professionalAllowances')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'professionalAllowances'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '专业津贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'professionalAllowances'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QuasiVehicleAllowances')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'QuasiVehicleAllowances'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '准驾车型补贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'QuasiVehicleAllowances'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PostAllowance')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PostAllowance'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '岗位津贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PostAllowance'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StaffServiceAllowance')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'StaffServiceAllowance'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '排障员业务补贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'StaffServiceAllowance'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DustCharge')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'DustCharge'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '防尘费',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'DustCharge'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NightAllowance')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'NightAllowance'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '夜班补贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'NightAllowance'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HardshipAllowance')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'HardshipAllowance'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '艰苦边远补贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'HardshipAllowance'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TollStationService')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'TollStationService'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '收费站业务补贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'TollStationService'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SmileStar')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'SmileStar'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '微笑之星',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'SmileStar'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'JobReplacement')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'JobReplacement'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '补发岗位工资',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'JobReplacement'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ReplacementPay')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'ReplacementPay'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '补发工资',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'ReplacementPay'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PluggingIncome')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PluggingIncome'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '堵漏增收',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'PluggingIncome'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Other')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Other'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '其他',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Other'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Reserve1')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Reserve1'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留1',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Reserve1'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Reserve2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Reserve2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '预留2',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Reserve2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Subtotal')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Subtotal'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '小计',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Subtotal'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HighSubsidies')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'HighSubsidies'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '高温补贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'HighSubsidies'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommunicationSubsidy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'CommunicationSubsidy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '通讯补贴',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'CommunicationSubsidy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OvertimePay')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'OvertimePay'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '加班费',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'OvertimePay'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Debit')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Debit'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '扣款',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'Debit'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TotalShouldBeIssued')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'TotalShouldBeIssued'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '应发合计',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'TotalShouldBeIssued'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NaturalYearEndPerformance')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'NaturalYearEndPerformance'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自然年度年终绩效年终绩效',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'NaturalYearEndPerformance'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Payroll')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AnnualYearEndPerformance')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'AnnualYearEndPerformance'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所属年度年终绩效',
   'user', @CurrentUser, 'table', 'Payroll', 'column', 'AnnualYearEndPerformance'
go

/*==============================================================*/
/* Index: Relationship_1_FK                                     */
/*==============================================================*/
create index Relationship_1_FK on Payroll (
Position_ID ASC
)
go

/*==============================================================*/
/* Index: Relationship_2_FK                                     */
/*==============================================================*/
create index Relationship_2_FK on Payroll (
PostRank_ID ASC
)
go

/*==============================================================*/
/* Table: Position                                              */
/*==============================================================*/
create table Position (
   Position_ID          varchar(200)         not null,
   Position_Name        varchar(50)          null,
   constraint PK_POSITION primary key nonclustered (Position_ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Position') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Position' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '所在岗位表', 
   'user', @CurrentUser, 'table', 'Position'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Position')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Position_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Position', 'column', 'Position_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '岗位ID',
   'user', @CurrentUser, 'table', 'Position', 'column', 'Position_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Position')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Position_Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Position', 'column', 'Position_Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '岗位名称',
   'user', @CurrentUser, 'table', 'Position', 'column', 'Position_Name'
go

/*==============================================================*/
/* Table: PostRank                                              */
/*==============================================================*/
create table PostRank (
   PostRank_ID          varchar(200)         not null,
   PostRank_Name        varchar(50)          null,
   constraint PK_POSTRANK primary key nonclustered (PostRank_ID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('PostRank') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'PostRank' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '岗位职级', 
   'user', @CurrentUser, 'table', 'PostRank'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PostRank')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PostRank_ID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PostRank', 'column', 'PostRank_ID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '岗位职级ID',
   'user', @CurrentUser, 'table', 'PostRank', 'column', 'PostRank_ID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PostRank')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PostRank_Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PostRank', 'column', 'PostRank_Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '岗位职级名称',
   'user', @CurrentUser, 'table', 'PostRank', 'column', 'PostRank_Name'
go

alter table Payroll
   add constraint FK_PAYROLL_RELATIONS_POSITION foreign key (Position_ID)
      references Position (Position_ID)
go

alter table Payroll
   add constraint FK_PAYROLL_RELATIONS_POSTRANK foreign key (PostRank_ID)
      references PostRank (PostRank_ID)
go

