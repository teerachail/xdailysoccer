-- Creating table 'GuestAccounts'
CREATE TABLE [dbo].[GuestAccounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SecretCode] nvarchar(max)  NOT NULL,
    [AccountId] int  NOT NULL
);
GO
-- Creating foreign key on [AccountId] in table 'GuestAccounts'
ALTER TABLE [dbo].[GuestAccounts]
ADD CONSTRAINT [FK_AccountGuestAccount]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [Id] in table 'GuestAccounts'
ALTER TABLE [dbo].[GuestAccounts]
ADD CONSTRAINT [PK_GuestAccounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_AccountGuestAccount'
CREATE INDEX [IX_FK_AccountGuestAccount]
ON [dbo].[GuestAccounts]
    ([AccountId]);