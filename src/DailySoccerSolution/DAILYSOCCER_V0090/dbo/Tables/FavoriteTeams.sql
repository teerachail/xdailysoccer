-- Creating table 'FavoriteTeams'
CREATE TABLE [dbo].[FavoriteTeams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LeagueName] varchar(255)  NOT NULL,
    [TeamName] varchar(255)  NOT NULL,
    [TeamId] int  NOT NULL,
    [Account_Id] int  NOT NULL
);
GO
-- Creating foreign key on [Account_Id] in table 'FavoriteTeams'
ALTER TABLE [dbo].[FavoriteTeams]
ADD CONSTRAINT [FK_AccountFavoriteTeam]
    FOREIGN KEY ([Account_Id])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [Id] in table 'FavoriteTeams'
ALTER TABLE [dbo].[FavoriteTeams]
ADD CONSTRAINT [PK_FavoriteTeams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_AccountFavoriteTeam'
CREATE INDEX [IX_FK_AccountFavoriteTeam]
ON [dbo].[FavoriteTeams]
    ([Account_Id]);