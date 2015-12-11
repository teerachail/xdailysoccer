
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

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2015 10:04:02
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

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2015 14:03:29
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

IF OBJECT_ID(N'[dbo].[FK_RewardGroupReward]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rewards] DROP CONSTRAINT [FK_RewardGroupReward];
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


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2015 15:12:33
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

IF OBJECT_ID(N'[dbo].[FK_RewardGroupReward]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rewards] DROP CONSTRAINT [FK_RewardGroupReward];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountFavoriteTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FavoriteTeams] DROP CONSTRAINT [FK_AccountFavoriteTeam];
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


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2015 15:17:10
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

IF OBJECT_ID(N'[dbo].[FK_RewardGroupReward]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rewards] DROP CONSTRAINT [FK_RewardGroupReward];
GO

IF OBJECT_ID(N'[dbo].[FK_FavoriteTeamAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_FavoriteTeamAccount];
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


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/06/2015 23:45:59
-- Generated from EDMX file: E:\TheS\gits\DailySoccer\src\DailySoccerSolution\DailySoccer.DAC\DAC\EF\DailySoccerModel.edmx
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


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/07/2015 20:00:28
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

IF OBJECT_ID(N'[dbo].[FK_RewardGroupTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_RewardGroupTicket];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_AccountTicket];
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

IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2015 11:03:31
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

IF OBJECT_ID(N'[dbo].[FK_RewardGroupTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_RewardGroupTicket];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_AccountTicket];
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

IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2015 11:30:08
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

IF OBJECT_ID(N'[dbo].[FK_RewardGroupTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_RewardGroupTicket];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_AccountTicket];
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

IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO

IF OBJECT_ID(N'[dbo].[PhoneVerifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhoneVerifications];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2015 23:53:59
-- Generated from EDMX file: E:\TheS\gits\DailySoccer\src\DailySoccerSolution\DailySoccer.DAC\DAC\EF\DailySoccerModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_FavoriteTeamAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_FavoriteTeamAccount];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountWinner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Winners] DROP CONSTRAINT [FK_AccountWinner];
GO

IF OBJECT_ID(N'[dbo].[FK_RewardWinner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Winners] DROP CONSTRAINT [FK_RewardWinner];
GO

IF OBJECT_ID(N'[dbo].[FK_RewardGroupTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_RewardGroupTicket];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_AccountTicket];
GO

IF OBJECT_ID(N'[dbo].[FK_RewardGroupReward]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rewards] DROP CONSTRAINT [FK_RewardGroupReward];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountGuestAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GuestAccounts] DROP CONSTRAINT [FK_AccountGuestAccount];
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

IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO

IF OBJECT_ID(N'[dbo].[PhoneVerifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhoneVerifications];
GO

IF OBJECT_ID(N'[dbo].[GuestAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GuestAccounts];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO

-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/11/2015 20:16:54
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

IF OBJECT_ID(N'[dbo].[FK_FavoriteTeamAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_FavoriteTeamAccount];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountWinner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Winners] DROP CONSTRAINT [FK_AccountWinner];
GO

IF OBJECT_ID(N'[dbo].[FK_RewardWinner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Winners] DROP CONSTRAINT [FK_RewardWinner];
GO

IF OBJECT_ID(N'[dbo].[FK_RewardGroupTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_RewardGroupTicket];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_AccountTicket];
GO

IF OBJECT_ID(N'[dbo].[FK_RewardGroupReward]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rewards] DROP CONSTRAINT [FK_RewardGroupReward];
GO

IF OBJECT_ID(N'[dbo].[FK_AccountGuestAccount]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GuestAccounts] DROP CONSTRAINT [FK_AccountGuestAccount];
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

IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO

IF OBJECT_ID(N'[dbo].[PhoneVerifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhoneVerifications];
GO

IF OBJECT_ID(N'[dbo].[GuestAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GuestAccounts];
GO


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

GO
