
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/07/2015 15:56:57
-- Generated from EDMX file: C:\Users\joker\Documents\Git\dailysoccer\src\DailySoccerSolution\DailySoccer.DAC\DAC\EF\DailySoccerModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_AccountGuessMatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GuessMatches] DROP CONSTRAINT [FK_AccountGuessMatch];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchGuessMatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GuessMatches] DROP CONSTRAINT [FK_MatchGuessMatch];
GO
IF OBJECT_ID(N'[dbo].[FK_RewardGroupReward]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rewards] DROP CONSTRAINT [FK_RewardGroupReward];
GO
IF OBJECT_ID(N'[dbo].[FK_FavoriteTeamAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_FavoriteTeamAccount];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountWinner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Winners] DROP CONSTRAINT [FK_AccountWinner];
GO
IF OBJECT_ID(N'[dbo].[FK_RewardWinner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Winners] DROP CONSTRAINT [FK_RewardWinner];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Matches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Matches];
GO
IF OBJECT_ID(N'[dbo].[GuessMatches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GuessMatches];
GO
IF OBJECT_ID(N'[dbo].[RewardGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RewardGroups];
GO
IF OBJECT_ID(N'[dbo].[Rewards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rewards];
GO
IF OBJECT_ID(N'[dbo].[FavoriteTeams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FavoriteTeams];
GO
IF OBJECT_ID(N'[dbo].[Winners]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Winners];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SecretCode] varchar(100)  NOT NULL,
    [Points] int  NOT NULL,
    [FavoriteTeam_Id] int  NULL
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
    [MatchId] int  NOT NULL,
    [PredictionPoints] int  NOT NULL,
    [IsWinner] bit  NOT NULL,
    [WinnerPoints] int  NULL
);
GO

-- Creating table 'RewardGroups'
CREATE TABLE [dbo].[RewardGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RequestPoints] int  NOT NULL,
    [ExpiredDate] datetime  NOT NULL
);
GO

-- Creating table 'Rewards'
CREATE TABLE [dbo].[Rewards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Amount] int  NOT NULL,
    [RemainingAmount] int  NULL,
    [ThumbnailPath] nvarchar(max)  NULL,
    [ImagePath] nvarchar(max)  NULL,
    [RewardGroupId] int  NOT NULL
);
GO

-- Creating table 'FavoriteTeams'
CREATE TABLE [dbo].[FavoriteTeams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LeagueName] varchar(255)  NOT NULL,
    [TeamName] varchar(255)  NOT NULL
);
GO

-- Creating table 'Winners'
CREATE TABLE [dbo].[Winners] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccountId] int  NOT NULL,
    [RewardId] int  NOT NULL,
    [ReferenceCode] varchar(100)  NOT NULL,
    [LastContactDate] datetime  NULL
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

-- Creating primary key on [Id] in table 'RewardGroups'
ALTER TABLE [dbo].[RewardGroups]
ADD CONSTRAINT [PK_RewardGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rewards'
ALTER TABLE [dbo].[Rewards]
ADD CONSTRAINT [PK_Rewards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FavoriteTeams'
ALTER TABLE [dbo].[FavoriteTeams]
ADD CONSTRAINT [PK_FavoriteTeams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Winners'
ALTER TABLE [dbo].[Winners]
ADD CONSTRAINT [PK_Winners]
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

-- Creating foreign key on [RewardGroupId] in table 'Rewards'
ALTER TABLE [dbo].[Rewards]
ADD CONSTRAINT [FK_RewardGroupReward]
    FOREIGN KEY ([RewardGroupId])
    REFERENCES [dbo].[RewardGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RewardGroupReward'
CREATE INDEX [IX_FK_RewardGroupReward]
ON [dbo].[Rewards]
    ([RewardGroupId]);
GO

-- Creating foreign key on [FavoriteTeam_Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_FavoriteTeamAccount]
    FOREIGN KEY ([FavoriteTeam_Id])
    REFERENCES [dbo].[FavoriteTeams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FavoriteTeamAccount'
CREATE INDEX [IX_FK_FavoriteTeamAccount]
ON [dbo].[Accounts]
    ([FavoriteTeam_Id]);
GO

-- Creating foreign key on [AccountId] in table 'Winners'
ALTER TABLE [dbo].[Winners]
ADD CONSTRAINT [FK_AccountWinner]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountWinner'
CREATE INDEX [IX_FK_AccountWinner]
ON [dbo].[Winners]
    ([AccountId]);
GO

-- Creating foreign key on [RewardId] in table 'Winners'
ALTER TABLE [dbo].[Winners]
ADD CONSTRAINT [FK_RewardWinner]
    FOREIGN KEY ([RewardId])
    REFERENCES [dbo].[Rewards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RewardWinner'
CREATE INDEX [IX_FK_RewardWinner]
ON [dbo].[Winners]
    ([RewardId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------