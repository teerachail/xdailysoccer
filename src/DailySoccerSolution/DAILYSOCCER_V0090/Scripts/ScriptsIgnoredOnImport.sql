
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2015 12:05:33
-- Generated from EDMX file: C:\Users\joker\Documents\Git\dailysoccer\src\DailySoccerSolution\DailySoccer.DAC\DAC\EF\DailySoccerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO

USE [dailysoccerdb];
GO

IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO


-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2015 12:25:04
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO


-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

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
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/03/2015 11:22:31
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

IF OBJECT_ID(N'[dbo].[FK_AccountGuessMatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GuessMatches] DROP CONSTRAINT [FK_AccountGuessMatch];
GO

IF OBJECT_ID(N'[dbo].[FK_MatchGuessMatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GuessMatches] DROP CONSTRAINT [FK_MatchGuessMatch];
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


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO
