USE [AnswerProjectBoard]
GO

/****** Object:  Table [dbo].[Client]    Script Date: 06/12/2013 09:40:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

if(not exists(select * from INFORMATION_SCHEMA.TABLES as t where t.TABLE_NAME = 'Client' and t.TABLE_CATALOG = 'AnswerProjectBoard'))
begin
	CREATE TABLE [dbo].[Client](
		[Id] [int] NOT NULL IDENTITY(1,1),
		[Name] [varchar](255) NOT NULL,
		[Description] [varchar](1000) NULL,
		[CreatedOn] [datetime] NOT NULL default getdate(),
	 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
end

GO

if(not exists(select * from INFORMATION_SCHEMA.TABLES as t where t.TABLE_NAME = 'ProjectStatus' and t.TABLE_CATALOG = 'AnswerProjectBoard'))
begin
	CREATE TABLE [dbo].[ProjectStatus](
		[Id] [tinyint] NOT NULL,
		[Name] [varchar](255) NOT NULL,
		[Description] [varchar](1000) NULL,
		[CreatedOn] [datetime] NOT NULL default getdate()
	 CONSTRAINT [PK_ProjectStatus] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
end

GO

if(not exists(select * from dbo.ProjectStatus))
begin

	insert into dbo.ProjectStatus
	(
		Id, Name
	)
	select 1, 'Proposed'
	union
	select 2, 'Open'
	union
	select 3, 'Support Phase'
	union
	select 4, 'Closed'

end

GO

if(not exists(select * from INFORMATION_SCHEMA.TABLES as t where t.TABLE_NAME = 'Project' and t.TABLE_CATALOG = 'AnswerProjectBoard'))
begin
	CREATE TABLE [dbo].[Project](
		[Id] [int] NOT NULL IDENTITY(1,1),
		[ClientId] [int] NOT NULL,
		[StatusId] [tinyint] NOT NULL,
		[Name] [varchar](255) NOT NULL,
		[Description] [varchar](1000) NULL,
		[CreatedOn] [datetime] NOT NULL default getdate(),
		[ProposedStartDate] [datetime] NULL,
		[ProposedEndDate] [datetime] NULL,
		[ActualStartDate] [datetime] NULL,
		[ActualEndDate] [datetime] NULL,
	 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
end

GO

if(not exists(select * from sys.foreign_keys as f where f.Name = 'FK_Project_Client' and f.[type] = 'F' and f.parent_object_id = OBJECT_ID('Project', 'U')))
begin
	alter table dbo.Project
	add constraint FK_Project_Client foreign key (ClientId) references dbo.Client (Id)
end

GO

if(not exists(select * from sys.foreign_keys as f where f.Name = 'FK_Project_ProjectStatus' and f.[type] = 'F' and f.parent_object_id = OBJECT_ID('Project', 'U')))
begin
	alter table dbo.Project
	add constraint FK_Project_ProjectStatus foreign key (StatusId) references dbo.ProjectStatus (Id)
end

GO


if(not exists(select * from INFORMATION_SCHEMA.TABLES as t where t.TABLE_NAME = 'ClientProjectLinkTest' and t.TABLE_CATALOG = 'AnswerProjectBoard'))
begin
	CREATE TABLE [dbo].[ClientProjectLinkTest](
		[Id] [int] NOT NULL IDENTITY(1,1),
		[ClientId] [int] NOT NULL,
		[ProjectId] [int] NOT NULL,
		[CreatedOn] [datetime] NOT NULL default getdate(),
	 CONSTRAINT [PK_ClientProjectLinkTest] PRIMARY KEY CLUSTERED 
	(
		[ClientId], [ProjectId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
end

GO

if(not exists(select * from sys.foreign_keys as f where f.Name = 'FK_ClientProjectLinkTest_Client' and f.[type] = 'F' and f.parent_object_id = OBJECT_ID('ClientProjectLinkTest', 'U')))
begin
	alter table dbo.ClientProjectLinkTest
	add constraint FK_ClientProjectLinkTest_Client foreign key (ClientId) references dbo.Client (Id),
		constraint FK_ClientProjectLinkTest_Project foreign key (ProjectId) references dbo.Project (Id)
end

GO

SET ANSI_PADDING OFF
GO

if(not exists(select top 1 c.Id from dbo.Client as c))
begin

	insert into dbo.Client
	(
		Name		
	)
	select 'CVL' -- 1
	union
	select 'Geoplan' -- 2
	union
	select 'Helm Godfrey' -- 3
	union
	select 'Parseq' -- 4

end

GO

if(not exists(select top 1 p.Id from dbo.Project as p))
begin
	
	declare @statusPending int, @statusOpen int, @statusClosed int, @clientCVL int, @clientGeoplan int, @clientHelmG int, @clientParseq int
	set @statusPending = 1
	set @statusOpen = 2
	set @statusClosed = 3
	set @clientCVL = 1
	set @clientGeoplan = 2
	set @clientHelmG = 3
	set @clientParseq = 4

	insert into dbo.Project
	(
		ClientId,
		StatusId,
		Name
	)
	select @clientCVL, @statusPending, 'CVL Site'
	union
	select @clientGeoplan, @statusOpen, 'SKiN Online'
	union
	select @clientGeoplan, @statusOpen, 'Yum World Drilldown'
	union
	select @clientGeoplan, @statusOpen, 'Customer Provisioning'
	union
	select @clientGeoplan, @statusOpen, 'Performance Profiling'
	union
	select @clientHelmG, @statusClosed, 'iChoose Phase 1'
	union
	select @clientHelmG, @statusPending, 'iChoose Phase 2'
	union
	select @clientParseq, @statusOpen, 'EFT Online'
	union
	select @clientParseq, @statusPending, 'EFT Online Extensions'
	union
	select @clientParseq, @statusClosed, 'MCC'
	union
	select @clientParseq, @statusPending, 'MCC Extensions'

end

GO