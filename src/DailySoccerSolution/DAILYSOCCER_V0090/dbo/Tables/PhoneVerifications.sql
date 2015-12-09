-- Creating table 'PhoneVerifications'
CREATE TABLE [dbo].[PhoneVerifications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] varchar(100)  NOT NULL,
    [VerificationCode] varchar(10)  NOT NULL,
    [PhoneNumber] varchar(20)  NOT NULL,
    [CompletedDate] datetime  NULL
);
GO
-- Creating primary key on [Id] in table 'PhoneVerifications'
ALTER TABLE [dbo].[PhoneVerifications]
ADD CONSTRAINT [PK_PhoneVerifications]
    PRIMARY KEY CLUSTERED ([Id] ASC);