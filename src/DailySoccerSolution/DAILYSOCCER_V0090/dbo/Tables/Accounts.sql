-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SecrectCode] varchar(100)  NOT NULL,
    [Points] int  NOT NULL,
    [FavoriteTeam_Id] int  NULL
);
GO
-- Creating foreign key on [FavoriteTeam_Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_FavoriteTeamAccount]
    FOREIGN KEY ([FavoriteTeam_Id])
    REFERENCES [dbo].[FavoriteTeams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_FavoriteTeamAccount'
CREATE INDEX [IX_FK_FavoriteTeamAccount]
ON [dbo].[Accounts]
    ([FavoriteTeam_Id]);