-- Creating table 'GuessMatches'
CREATE TABLE [dbo].[GuessMatches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GuessTeamId] int  NULL,
    [AccountId] int  NOT NULL,
    [MatchId] int  NOT NULL
);
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
-- Creating foreign key on [MatchId] in table 'GuessMatches'
ALTER TABLE [dbo].[GuessMatches]
ADD CONSTRAINT [FK_MatchGuessMatch]
    FOREIGN KEY ([MatchId])
    REFERENCES [dbo].[Matches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [Id] in table 'GuessMatches'
ALTER TABLE [dbo].[GuessMatches]
ADD CONSTRAINT [PK_GuessMatches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_AccountGuessMatch'
CREATE INDEX [IX_FK_AccountGuessMatch]
ON [dbo].[GuessMatches]
    ([AccountId]);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_MatchGuessMatch'
CREATE INDEX [IX_FK_MatchGuessMatch]
ON [dbo].[GuessMatches]
    ([MatchId]);