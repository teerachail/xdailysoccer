-- Creating table 'Matches'
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
-- Creating primary key on [Id] in table 'Matches'
-- Creating primary key on [Id] in table 'Matches'
ALTER TABLE [dbo].[Matches]
ADD CONSTRAINT [PK_Matches]
    PRIMARY KEY CLUSTERED ([Id] ASC);