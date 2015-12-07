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
-- Creating foreign key on [RewardGroupId] in table 'Rewards'
ALTER TABLE [dbo].[Rewards]
ADD CONSTRAINT [FK_RewardGroupReward]
    FOREIGN KEY ([RewardGroupId])
    REFERENCES [dbo].[RewardGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [Id] in table 'Rewards'
ALTER TABLE [dbo].[Rewards]
ADD CONSTRAINT [PK_Rewards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_RewardGroupReward'
CREATE INDEX [IX_FK_RewardGroupReward]
ON [dbo].[Rewards]
    ([RewardGroupId]);