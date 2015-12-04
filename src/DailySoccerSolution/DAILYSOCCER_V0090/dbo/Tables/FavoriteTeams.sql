-- Creating table 'FavoriteTeams'
CREATE TABLE [dbo].[FavoriteTeams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LeagueName] varchar(255)  NOT NULL,
    [TeamName] varchar(255)  NOT NULL
);
GO
-- Creating primary key on [Id] in table 'FavoriteTeams'
ALTER TABLE [dbo].[FavoriteTeams]
ADD CONSTRAINT [PK_FavoriteTeams]
    PRIMARY KEY CLUSTERED ([Id] ASC);