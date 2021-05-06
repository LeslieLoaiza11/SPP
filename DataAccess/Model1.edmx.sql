
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/07/2021 00:00:36
-- Generated from EDMX file: C:\Users\A515-54-798T\Desktop\EquipoB\SPP\DataAccess\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SPP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ElectionProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_ElectionProject];
GO
IF OBJECT_ID(N'[dbo].[FK_LinkedOrganizationProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_LinkedOrganizationProject];
GO
IF OBJECT_ID(N'[dbo].[FK_LinkedOrganizationProjectManager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectManagerSet] DROP CONSTRAINT [FK_LinkedOrganizationProjectManager];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipationProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_ParticipationProject];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipationRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipationSet] DROP CONSTRAINT [FK_ParticipationRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfessorParticipation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfessorSet] DROP CONSTRAINT [FK_ProfessorParticipation];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectManager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectSet] DROP CONSTRAINT [FK_ProjectProjectManager];
GO
IF OBJECT_ID(N'[dbo].[FK_RecordDocument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentSet] DROP CONSTRAINT [FK_RecordDocument];
GO
IF OBJECT_ID(N'[dbo].[FK_Report_inherits_Document]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentSet_Report] DROP CONSTRAINT [FK_Report_inherits_Document];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentElection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ElectionSet] DROP CONSTRAINT [FK_StudentElection];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentParticipation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipationSet] DROP CONSTRAINT [FK_StudentParticipation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DocumentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentSet];
GO
IF OBJECT_ID(N'[dbo].[DocumentSet_Report]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentSet_Report];
GO
IF OBJECT_ID(N'[dbo].[ElectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ElectionSet];
GO
IF OBJECT_ID(N'[dbo].[LinkedOrganizationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LinkedOrganizationSet];
GO
IF OBJECT_ID(N'[dbo].[ParticipationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParticipationSet];
GO
IF OBJECT_ID(N'[dbo].[ProfessorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfessorSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectManagerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectManagerSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectSet];
GO
IF OBJECT_ID(N'[dbo].[RecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecordSet];
GO
IF OBJECT_ID(N'[dbo].[StudentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StudentSet'
CREATE TABLE [dbo].[StudentSet] (
    [idStudent] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NULL,
    [lastName] nvarchar(max)  NULL,
    [email] nvarchar(max)  NULL,
    [password] nvarchar(max)  NULL,
    [phone] nvarchar(max)  NULL,
    [enrollment] nvarchar(max)  NULL
);
GO

-- Creating table 'ProjectSet'
CREATE TABLE [dbo].[ProjectSet] (
    [idProject] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NULL,
    [description] nvarchar(max)  NULL,
    [date] datetime  NULL,
    [activities] nvarchar(max)  NULL,
    [methodology] nvarchar(max)  NULL,
    [schedule] nvarchar(max)  NULL,
    [generalPurpose] nvarchar(max)  NULL,
    [mediateObjective] nvarchar(max)  NULL,
    [inmediateObjective] nvarchar(max)  NULL,
    [studentsRequired] int  NULL,
    [studentsAssigned] int  NULL,
    [status] nvarchar(max)  NULL,
    [Participation_idParticipation] int  NULL,
    [Election_IdElection] int  NULL,
    [ProjectManager_IdProjectManager] int  NULL,
    [LinkedOrganization_IdLinkedOrganization] int  NOT NULL
);
GO

-- Creating table 'ProfessorSet'
CREATE TABLE [dbo].[ProfessorSet] (
    [idProfessor] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [lastName] nvarchar(max)  NOT NULL,
    [staffNumber] nvarchar(max)  NOT NULL,
    [Participation_idParticipation] int  NOT NULL
);
GO

-- Creating table 'RecordSet'
CREATE TABLE [dbo].[RecordSet] (
    [idRecord] int IDENTITY(1,1) NOT NULL,
    [totalHoursWorked] float  NOT NULL,
    [comments] nvarchar(max)  NOT NULL,
    [finalScore] float  NOT NULL
);
GO

-- Creating table 'DocumentSet'
CREATE TABLE [dbo].[DocumentSet] (
    [IdDocument] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [path] nvarchar(max)  NOT NULL,
    [weight] float  NOT NULL,
    [uploadDate] datetime  NOT NULL,
    [Record_idRecord] int  NOT NULL
);
GO

-- Creating table 'ParticipationSet'
CREATE TABLE [dbo].[ParticipationSet] (
    [idParticipation] int IDENTITY(1,1) NOT NULL,
    [year] int  NULL,
    [period] nvarchar(max)  NULL,
    [section] nvarchar(max)  NULL,
    [block] nvarchar(max)  NULL,
    [status] nvarchar(max)  NULL,
    [startDate] datetime  NULL,
    [endDate] datetime  NULL,
    [nrc] nvarchar(max)  NULL,
    [Student_idStudent] int  NOT NULL,
    [Record_idRecord] int  NOT NULL
);
GO

-- Creating table 'ElectionSet'
CREATE TABLE [dbo].[ElectionSet] (
    [IdElection] int IDENTITY(1,1) NOT NULL,
    [electionLevel] smallint  NOT NULL,
    [period] nvarchar(max)  NOT NULL,
    [Student_idStudent] int  NOT NULL
);
GO

-- Creating table 'LinkedOrganizationSet'
CREATE TABLE [dbo].[LinkedOrganizationSet] (
    [IdLinkedOrganization] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NULL,
    [adress] nvarchar(max)  NULL,
    [phone] nvarchar(max)  NULL,
    [email] nvarchar(max)  NULL
);
GO

-- Creating table 'ProjectManagerSet'
CREATE TABLE [dbo].[ProjectManagerSet] (
    [IdProjectManager] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [lastName] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [phone] nvarchar(max)  NOT NULL,
    [LinkedOrganization_IdLinkedOrganization] int  NOT NULL
);
GO

-- Creating table 'DocumentSet_Report'
CREATE TABLE [dbo].[DocumentSet_Report] (
    [hoursWorked] float  NOT NULL,
    [date] datetime  NOT NULL,
    [startDate] datetime  NOT NULL,
    [endDate] datetime  NOT NULL,
    [status] nvarchar(max)  NOT NULL,
    [comments] nvarchar(max)  NOT NULL,
    [IdDocument] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idStudent] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [PK_StudentSet]
    PRIMARY KEY CLUSTERED ([idStudent] ASC);
GO

-- Creating primary key on [idProject] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [PK_ProjectSet]
    PRIMARY KEY CLUSTERED ([idProject] ASC);
GO

-- Creating primary key on [idProfessor] in table 'ProfessorSet'
ALTER TABLE [dbo].[ProfessorSet]
ADD CONSTRAINT [PK_ProfessorSet]
    PRIMARY KEY CLUSTERED ([idProfessor] ASC);
GO

-- Creating primary key on [idRecord] in table 'RecordSet'
ALTER TABLE [dbo].[RecordSet]
ADD CONSTRAINT [PK_RecordSet]
    PRIMARY KEY CLUSTERED ([idRecord] ASC);
GO

-- Creating primary key on [IdDocument] in table 'DocumentSet'
ALTER TABLE [dbo].[DocumentSet]
ADD CONSTRAINT [PK_DocumentSet]
    PRIMARY KEY CLUSTERED ([IdDocument] ASC);
GO

-- Creating primary key on [idParticipation] in table 'ParticipationSet'
ALTER TABLE [dbo].[ParticipationSet]
ADD CONSTRAINT [PK_ParticipationSet]
    PRIMARY KEY CLUSTERED ([idParticipation] ASC);
GO

-- Creating primary key on [IdElection] in table 'ElectionSet'
ALTER TABLE [dbo].[ElectionSet]
ADD CONSTRAINT [PK_ElectionSet]
    PRIMARY KEY CLUSTERED ([IdElection] ASC);
GO

-- Creating primary key on [IdLinkedOrganization] in table 'LinkedOrganizationSet'
ALTER TABLE [dbo].[LinkedOrganizationSet]
ADD CONSTRAINT [PK_LinkedOrganizationSet]
    PRIMARY KEY CLUSTERED ([IdLinkedOrganization] ASC);
GO

-- Creating primary key on [IdProjectManager] in table 'ProjectManagerSet'
ALTER TABLE [dbo].[ProjectManagerSet]
ADD CONSTRAINT [PK_ProjectManagerSet]
    PRIMARY KEY CLUSTERED ([IdProjectManager] ASC);
GO

-- Creating primary key on [IdDocument] in table 'DocumentSet_Report'
ALTER TABLE [dbo].[DocumentSet_Report]
ADD CONSTRAINT [PK_DocumentSet_Report]
    PRIMARY KEY CLUSTERED ([IdDocument] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Student_idStudent] in table 'ParticipationSet'
ALTER TABLE [dbo].[ParticipationSet]
ADD CONSTRAINT [FK_StudentParticipation]
    FOREIGN KEY ([Student_idStudent])
    REFERENCES [dbo].[StudentSet]
        ([idStudent])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentParticipation'
CREATE INDEX [IX_FK_StudentParticipation]
ON [dbo].[ParticipationSet]
    ([Student_idStudent]);
GO

-- Creating foreign key on [Student_idStudent] in table 'ElectionSet'
ALTER TABLE [dbo].[ElectionSet]
ADD CONSTRAINT [FK_StudentElection]
    FOREIGN KEY ([Student_idStudent])
    REFERENCES [dbo].[StudentSet]
        ([idStudent])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentElection'
CREATE INDEX [IX_FK_StudentElection]
ON [dbo].[ElectionSet]
    ([Student_idStudent]);
GO

-- Creating foreign key on [Participation_idParticipation] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_ParticipationProject]
    FOREIGN KEY ([Participation_idParticipation])
    REFERENCES [dbo].[ParticipationSet]
        ([idParticipation])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipationProject'
CREATE INDEX [IX_FK_ParticipationProject]
ON [dbo].[ProjectSet]
    ([Participation_idParticipation]);
GO

-- Creating foreign key on [Election_IdElection] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_ElectionProject]
    FOREIGN KEY ([Election_IdElection])
    REFERENCES [dbo].[ElectionSet]
        ([IdElection])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ElectionProject'
CREATE INDEX [IX_FK_ElectionProject]
ON [dbo].[ProjectSet]
    ([Election_IdElection]);
GO

-- Creating foreign key on [ProjectManager_IdProjectManager] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_ProjectProjectManager]
    FOREIGN KEY ([ProjectManager_IdProjectManager])
    REFERENCES [dbo].[ProjectManagerSet]
        ([IdProjectManager])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectManager'
CREATE INDEX [IX_FK_ProjectProjectManager]
ON [dbo].[ProjectSet]
    ([ProjectManager_IdProjectManager]);
GO

-- Creating foreign key on [LinkedOrganization_IdLinkedOrganization] in table 'ProjectSet'
ALTER TABLE [dbo].[ProjectSet]
ADD CONSTRAINT [FK_LinkedOrganizationProject]
    FOREIGN KEY ([LinkedOrganization_IdLinkedOrganization])
    REFERENCES [dbo].[LinkedOrganizationSet]
        ([IdLinkedOrganization])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LinkedOrganizationProject'
CREATE INDEX [IX_FK_LinkedOrganizationProject]
ON [dbo].[ProjectSet]
    ([LinkedOrganization_IdLinkedOrganization]);
GO

-- Creating foreign key on [Participation_idParticipation] in table 'ProfessorSet'
ALTER TABLE [dbo].[ProfessorSet]
ADD CONSTRAINT [FK_ProfessorParticipation]
    FOREIGN KEY ([Participation_idParticipation])
    REFERENCES [dbo].[ParticipationSet]
        ([idParticipation])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfessorParticipation'
CREATE INDEX [IX_FK_ProfessorParticipation]
ON [dbo].[ProfessorSet]
    ([Participation_idParticipation]);
GO

-- Creating foreign key on [Record_idRecord] in table 'DocumentSet'
ALTER TABLE [dbo].[DocumentSet]
ADD CONSTRAINT [FK_RecordDocument]
    FOREIGN KEY ([Record_idRecord])
    REFERENCES [dbo].[RecordSet]
        ([idRecord])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RecordDocument'
CREATE INDEX [IX_FK_RecordDocument]
ON [dbo].[DocumentSet]
    ([Record_idRecord]);
GO

-- Creating foreign key on [Record_idRecord] in table 'ParticipationSet'
ALTER TABLE [dbo].[ParticipationSet]
ADD CONSTRAINT [FK_ParticipationRecord]
    FOREIGN KEY ([Record_idRecord])
    REFERENCES [dbo].[RecordSet]
        ([idRecord])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipationRecord'
CREATE INDEX [IX_FK_ParticipationRecord]
ON [dbo].[ParticipationSet]
    ([Record_idRecord]);
GO

-- Creating foreign key on [LinkedOrganization_IdLinkedOrganization] in table 'ProjectManagerSet'
ALTER TABLE [dbo].[ProjectManagerSet]
ADD CONSTRAINT [FK_LinkedOrganizationProjectManager]
    FOREIGN KEY ([LinkedOrganization_IdLinkedOrganization])
    REFERENCES [dbo].[LinkedOrganizationSet]
        ([IdLinkedOrganization])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LinkedOrganizationProjectManager'
CREATE INDEX [IX_FK_LinkedOrganizationProjectManager]
ON [dbo].[ProjectManagerSet]
    ([LinkedOrganization_IdLinkedOrganization]);
GO

-- Creating foreign key on [IdDocument] in table 'DocumentSet_Report'
ALTER TABLE [dbo].[DocumentSet_Report]
ADD CONSTRAINT [FK_Report_inherits_Document]
    FOREIGN KEY ([IdDocument])
    REFERENCES [dbo].[DocumentSet]
        ([IdDocument])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------