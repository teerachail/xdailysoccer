-- Creating table 'RewardGroups'
CREATE TABLE [dbo].[RewardGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RequestPoints] int  NOT NULL,
    [ExpiredDate] datetime  NOT NULL
);
GO
-- Creating primary key on [Id] in table 'RewardGroups'
ALTER TABLE [dbo].[RewardGroups]
ADD CONSTRAINT [PK_RewardGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);