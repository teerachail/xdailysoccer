
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/02/2015 12:01:17
-- Generated from EDMX file: E:\gits\TheS\DailySoccer\src\DailySoccerSolution\DailySoccer.DAC\DAC\EF\DailySoccerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DAILYSOCCER_V0090];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SecrectCode] varchar(100)  NOT NULL,
    [Points] int  NOT NULL
);
GO

-- Creating table 'Matches'
CREATE TABLE [dbo].[Matches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LeagueName] varchar(255)  NOT NULL,
    [BeginDate] datetime  NOT NULL,
    [StartedDate] datetime  NULL,
    [CompletedDate] datetime  NULL,
    [Status] varchar(10)  NOT NULL,
    [TeamHome_Id] int  NOT NULL,
    [TeamHome_Name] nvarchar(255)  NOT NULL,
    [TeamHome_CurrentScore] int  NOT NULL,
    [TeamHome_CurrentPredictionPoints] int  NOT NULL,
    [TeamAway_Id] int  NOT NULL,
    [TeamAway_Name] nvarchar(255)  NOT NULL,
    [TeamAway_CurrentScore] int  NOT NULL,
    [TeamAway_CurrentPredictionPoints] int  NOT NULL
);
GO

-- Creating table 'GuessMatches'
CREATE TABLE [dbo].[GuessMatches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GuessTeamId] int  NULL,
    [AccountId] int  NOT NULL,
    [MatchId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Matches'
ALTER TABLE [dbo].[Matches]
ADD CONSTRAINT [PK_Matches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GuessMatches'
ALTER TABLE [dbo].[GuessMatches]
ADD CONSTRAINT [PK_GuessMatches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountId] in table 'GuessMatches'
ALTER TABLE [dbo].[GuessMatches]
ADD CONSTRAINT [FK_AccountGuessMatch]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountGuessMatch'
CREATE INDEX [IX_FK_AccountGuessMatch]
ON [dbo].[GuessMatches]
    ([AccountId]);
GO

-- Creating foreign key on [MatchId] in table 'GuessMatches'
ALTER TABLE [dbo].[GuessMatches]
ADD CONSTRAINT [FK_MatchGuessMatch]
    FOREIGN KEY ([MatchId])
    REFERENCES [dbo].[Matches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchGuessMatch'
CREATE INDEX [IX_FK_MatchGuessMatch]
ON [dbo].[GuessMatches]
    ([MatchId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------