-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [RewardGroupId] int  NOT NULL,
    [AccountId] int  NOT NULL
);
GO
-- Creating foreign key on [RewardGroupId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_RewardGroupTicket]
    FOREIGN KEY ([RewardGroupId])
    REFERENCES [dbo].[RewardGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating foreign key on [AccountId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_AccountTicket]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_RewardGroupTicket'
CREATE INDEX [IX_FK_RewardGroupTicket]
ON [dbo].[Tickets]
    ([RewardGroupId]);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_AccountTicket'
CREATE INDEX [IX_FK_AccountTicket]
ON [dbo].[Tickets]
    ([AccountId]);