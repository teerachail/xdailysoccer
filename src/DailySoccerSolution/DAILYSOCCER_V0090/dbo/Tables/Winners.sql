-- Creating table 'Winners'
CREATE TABLE [dbo].[Winners] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AccountId] int  NOT NULL,
    [RewardId] int  NOT NULL,
    [ReferenceCode] varchar(100)  NOT NULL,
    [LastContactDate] datetime  NULL
);
GO
-- Creating foreign key on [AccountId] in table 'Winners'
ALTER TABLE [dbo].[Winners]
ADD CONSTRAINT [FK_AccountWinner]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating foreign key on [RewardId] in table 'Winners'
ALTER TABLE [dbo].[Winners]
ADD CONSTRAINT [FK_RewardWinner]
    FOREIGN KEY ([RewardId])
    REFERENCES [dbo].[Rewards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [Id] in table 'Winners'
ALTER TABLE [dbo].[Winners]
ADD CONSTRAINT [PK_Winners]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_AccountWinner'
CREATE INDEX [IX_FK_AccountWinner]
ON [dbo].[Winners]
    ([AccountId]);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_RewardWinner'
CREATE INDEX [IX_FK_RewardWinner]
ON [dbo].[Winners]
    ([RewardId]);