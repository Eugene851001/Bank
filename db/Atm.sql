/* ---------------------------------------------------- */
/*  Generated by Enterprise Architect Version 15.0 		*/
/*  Created On : 17-фев-2022 22:32:35 				*/
/*  DBMS       : SQL Server 2012 						*/
/* ---------------------------------------------------- */

/* Drop Foreign Key Constraints */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Accounts_AccountsTypes]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Accounts] DROP CONSTRAINT [FK_Accounts_AccountsTypes]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Accounts_Currencies]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Accounts] DROP CONSTRAINT [FK_Accounts_Currencies]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Accounts_Users]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Accounts] DROP CONSTRAINT [FK_Accounts_Users]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Cards_Accounts]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Cards] DROP CONSTRAINT [FK_Cards_Accounts]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_CreditPlans_CreditObject]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [CreditPlans] DROP CONSTRAINT [FK_CreditPlans_CreditObject]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_CreditPlans_CreditsNames]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [CreditPlans] DROP CONSTRAINT [FK_CreditPlans_CreditsNames]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_CreditPlans_Currencies]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [CreditPlans] DROP CONSTRAINT [FK_CreditPlans_Currencies]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Credits_Accounts_02]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Credits] DROP CONSTRAINT [FK_Credits_Accounts_02]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Credits_Accounts_03]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Credits] DROP CONSTRAINT [FK_Credits_Accounts_03]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Credits_CreditPlans]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Credits] DROP CONSTRAINT [FK_Credits_CreditPlans]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Credits_Currencies]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Credits] DROP CONSTRAINT [FK_Credits_Currencies]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Contracts_Currencies]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Deposits] DROP CONSTRAINT [FK_Contracts_Currencies]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Contracts_DepositsPlans]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Deposits] DROP CONSTRAINT [FK_Contracts_DepositsPlans]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Deposits_Accounts]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Deposits] DROP CONSTRAINT [FK_Deposits_Accounts]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Deposits_Accounts_02]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Deposits] DROP CONSTRAINT [FK_Deposits_Accounts_02]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_DepositsPlans_Currencies]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [DepositsPlans] DROP CONSTRAINT [FK_DepositsPlans_Currencies]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_DepositsPlans_DepositsNames]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [DepositsPlans] DROP CONSTRAINT [FK_DepositsPlans_DepositsNames]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Transactions_Accounts]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Transactions] DROP CONSTRAINT [FK_Transactions_Accounts]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Transactions_Accounts_02]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Transactions] DROP CONSTRAINT [FK_Transactions_Accounts_02]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Users_Cities]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_Cities]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Users_Countries]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_Countries]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Users_Disabilities]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_Disabilities]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Users_MaritalStatuses]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [Users] DROP CONSTRAINT [FK_Users_MaritalStatuses]
GO

/* Drop Tables */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Accounts]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Accounts]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[AccountsTypes]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [AccountsTypes]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Cards]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Cards]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Cities]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Cities]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Countries]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Countries]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[CreditPlans]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [CreditPlans]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Credits]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Credits]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[CreditsNames]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [CreditsNames]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[CreditsObjects]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [CreditsObjects]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Currencies]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Currencies]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Deposits]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Deposits]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[DepositsNames]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [DepositsNames]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[DepositsPlans]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [DepositsPlans]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Disabilities]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Disabilities]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[MaritalStatuses]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [MaritalStatuses]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[SystemVariables]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [SystemVariables]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Transactions]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Transactions]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Users]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE [Users]
GO

/* Create Tables */

CREATE TABLE [Accounts]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Number] char(13) NOT NULL,
	[Code] varchar(50) NOT NULL,
	[Active] tinyint NOT NULL,
	[Debit] money NOT NULL,
	[Credit] money NOT NULL,
	[Owner] int NULL,
	[AccountType] tinyint NOT NULL,
	[Currency] tinyint NOT NULL
)
GO

CREATE TABLE [AccountsTypes]
(
	[Id] tinyint NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL,
	[Code] char(4) NOT NULL
)
GO

CREATE TABLE [Cards]
(
	[Number] char(16) NOT NULL,
	[Pin] char(4) NOT NULL,
	[Account] int NOT NULL
)
GO

CREATE TABLE [Cities]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL
)
GO

CREATE TABLE [Countries]
(
	[Id] tinyint NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL
)
GO

CREATE TABLE [CreditPlans]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Duration] int NOT NULL,
	[Percent] float NOT NULL,
	[Name] tinyint NOT NULL,
	[Object] tinyint NULL,
	[MinValue] money NULL,
	[Annuity] bit NOT NULL,
	[Currency] tinyint NOT NULL
)
GO

CREATE TABLE [Credits]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[StartDate] date NOT NULL,
	[EndDate] date NOT NULL,
	[Sum] money NOT NULL,
	[Percent] float NOT NULL,
	[Currency] tinyint NOT NULL,
	[Annuity] bit NOT NULL,
	[CreditPlan] int NULL,
	[MainAccount] int NOT NULL,
	[PercentAccount] int NOT NULL
)
GO

CREATE TABLE [CreditsNames]
(
	[Id] tinyint NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL
)
GO

CREATE TABLE [CreditsObjects]
(
	[Id] tinyint NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [Currencies]
(
	[Id] tinyint NOT NULL IDENTITY (1, 1),
	[Code] char(3) NOT NULL
)
GO

CREATE TABLE [Deposits]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[StartDate] date NOT NULL,
	[EndDate] date NOT NULL,
	[Sum] money NOT NULL,
	[Percent] float NOT NULL,
	[Currency] tinyint NOT NULL,
	[Revocable] bit NOT NULL,
	[DepositPlan] int NULL,
	[MainAccount] int NOT NULL,
	[PercentAccount] int NOT NULL
)
GO

CREATE TABLE [DepositsNames]
(
	[Id] tinyint NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(50) NOT NULL
)
GO

CREATE TABLE [DepositsPlans]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] tinyint NOT NULL,
	[Currency] tinyint NOT NULL,
	[Duration] int NOT NULL,
	[Revocable] bit NOT NULL,
	[Percent] float NOT NULL,
	[Online] bit NOT NULL,
	[MinValue] money NULL
)
GO

CREATE TABLE [Disabilities]
(
	[Id] smallint NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL
)
GO

CREATE TABLE [MaritalStatuses]
(
	[Id] tinyint NOT NULL IDENTITY (1, 1),
	[Name] varchar(50) NOT NULL
)
GO

CREATE TABLE [SystemVariables]
(
	[id] tinyint NOT NULL IDENTITY (1, 1),
	[CurrentDate] date NOT NULL
)
GO

CREATE TABLE [Transactions]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Source] int NOT NULL,
	[Destination] int NOT NULL,
	[Sum] money NOT NULL,
	[Time] datetime NULL
)
GO

CREATE TABLE [Users]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(50) NOT NULL,
	[Surname] nvarchar(50) NOT NULL,
	[Lastname] nvarchar(50) NOT NULL,
	[BirthDate] date NOT NULL,
	[Sex] bit NOT NULL,
	[PassportSeries] varchar(30) NOT NULL,
	[PassportNumber] varchar(30) NOT NULL,
	[IssuedBy] nvarchar(50) NOT NULL,
	[IssuedDate] date NOT NULL,
	[PassportId] varchar(50) NOT NULL,
	[BirthPlace] nvarchar(50) NOT NULL,
	[ResidenceCity] int NOT NULL,
	[ResidenceAddress] nvarchar(50) NOT NULL,
	[HomePhone] varchar(50) NULL,
	[MobilePhone] varchar(50) NULL,
	[Email] varchar(50) NULL,
	[MaritalStatus] tinyint NOT NULL,
	[Citizenship] tinyint NOT NULL,
	[Disability] smallint NOT NULL,
	[IsRetiree] bit NOT NULL,
	[MonthlyIncome] money NULL,
	[IsConscripted] bit NOT NULL,
	[Deleted] bit NOT NULL
)
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE [Accounts] 
 ADD CONSTRAINT [PK_Accounts]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Accounts_AccountsTypes] 
 ON [Accounts] ([AccountType] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Accounts_Currencies] 
 ON [Accounts] ([Currency] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Accounts_Users] 
 ON [Accounts] ([Owner] ASC)
GO

ALTER TABLE [AccountsTypes] 
 ADD CONSTRAINT [PK_AccountsTypes]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [Cards] 
 ADD CONSTRAINT [PK_Cards]
	PRIMARY KEY CLUSTERED ([Number] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Cards_Accounts] 
 ON [Cards] ([Account] ASC)
GO

ALTER TABLE [Cities] 
 ADD CONSTRAINT [PK_Cities]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [Countries] 
 ADD CONSTRAINT [PK_Countries]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [CreditPlans] 
 ADD CONSTRAINT [PK_CreditPlans]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_CreditPlans_CreditObject] 
 ON [CreditPlans] ([Object] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_CreditPlans_CreditsNames] 
 ON [CreditPlans] ([Name] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_CreditPlans_Currencies] 
 ON [CreditPlans] ([Currency] ASC)
GO

ALTER TABLE [Credits] 
 ADD CONSTRAINT [PK_Credits]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Credits_Accounts] 
 ON [Credits] ([Id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Credits_Accounts_02] 
 ON [Credits] ([MainAccount] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Credits_Accounts_03] 
 ON [Credits] ([PercentAccount] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Credits_CreditPlans] 
 ON [Credits] ([CreditPlan] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Credits_Currencies] 
 ON [Credits] ([Currency] ASC)
GO

ALTER TABLE [CreditsNames] 
 ADD CONSTRAINT [PK_CreditsNames]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [CreditsObjects] 
 ADD CONSTRAINT [PK_CreditObject]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [Currencies] 
 ADD CONSTRAINT [PK_Currencies]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [Deposits] 
 ADD CONSTRAINT [PK_Contracts]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Contracts_Currencies] 
 ON [Deposits] ([Currency] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Contracts_DepositsPlans] 
 ON [Deposits] ([DepositPlan] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Deposits_Accounts] 
 ON [Deposits] ([MainAccount] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Deposits_Accounts_02] 
 ON [Deposits] ([PercentAccount] ASC)
GO

ALTER TABLE [DepositsNames] 
 ADD CONSTRAINT [PK_DepositsNames]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [DepositsPlans] 
 ADD CONSTRAINT [PK_DepositsPlans]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_DepositsPlans_Currencies] 
 ON [DepositsPlans] ([Currency] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_DepositsPlans_DepositsNames] 
 ON [DepositsPlans] ([Name] ASC)
GO

ALTER TABLE [Disabilities] 
 ADD CONSTRAINT [PK_Disabilities]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [MaritalStatuses] 
 ADD CONSTRAINT [PK_MaritalStatuses]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [SystemVariables] 
 ADD CONSTRAINT [PK_SystemVariables]
	PRIMARY KEY CLUSTERED ([id] ASC)
GO

ALTER TABLE [Transactions] 
 ADD CONSTRAINT [PK_Transactions]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Transactions_Accounts] 
 ON [Transactions] ([Source] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Transactions_Accounts_02] 
 ON [Transactions] ([Destination] ASC)
GO

ALTER TABLE [Users] 
 ADD CONSTRAINT [PK_Users]
	PRIMARY KEY CLUSTERED ([Id] ASC)
GO

ALTER TABLE [Users] 
 ADD CONSTRAINT [UNQ_PassportId] UNIQUE NONCLUSTERED ([PassportId] ASC)
GO

ALTER TABLE [Users] 
 ADD CONSTRAINT [UNQ_PassportNumber] UNIQUE NONCLUSTERED ([PassportNumber] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Users_Cities] 
 ON [Users] ([ResidenceCity] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Users_Countries] 
 ON [Users] ([Citizenship] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Users_Disabilities] 
 ON [Users] ([Disability] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Users_MaritalStatuses] 
 ON [Users] ([MaritalStatus] ASC)
GO

/* Create Foreign Key Constraints */

ALTER TABLE [Accounts] ADD CONSTRAINT [FK_Accounts_AccountsTypes]
	FOREIGN KEY ([AccountType]) REFERENCES [AccountsTypes] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Accounts] ADD CONSTRAINT [FK_Accounts_Currencies]
	FOREIGN KEY ([Currency]) REFERENCES [Currencies] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Accounts] ADD CONSTRAINT [FK_Accounts_Users]
	FOREIGN KEY ([Owner]) REFERENCES [Users] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Cards] ADD CONSTRAINT [FK_Cards_Accounts]
	FOREIGN KEY ([Account]) REFERENCES [Accounts] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [CreditPlans] ADD CONSTRAINT [FK_CreditPlans_CreditObject]
	FOREIGN KEY ([Object]) REFERENCES [CreditsObjects] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [CreditPlans] ADD CONSTRAINT [FK_CreditPlans_CreditsNames]
	FOREIGN KEY ([Name]) REFERENCES [CreditsNames] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [CreditPlans] ADD CONSTRAINT [FK_CreditPlans_Currencies]
	FOREIGN KEY ([Currency]) REFERENCES [Currencies] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Credits] ADD CONSTRAINT [FK_Credits_Accounts_02]
	FOREIGN KEY ([MainAccount]) REFERENCES [Accounts] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Credits] ADD CONSTRAINT [FK_Credits_Accounts_03]
	FOREIGN KEY ([PercentAccount]) REFERENCES [Accounts] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Credits] ADD CONSTRAINT [FK_Credits_CreditPlans]
	FOREIGN KEY ([CreditPlan]) REFERENCES [CreditPlans] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Credits] ADD CONSTRAINT [FK_Credits_Currencies]
	FOREIGN KEY ([Currency]) REFERENCES [Currencies] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Deposits] ADD CONSTRAINT [FK_Contracts_Currencies]
	FOREIGN KEY ([Currency]) REFERENCES [Currencies] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Deposits] ADD CONSTRAINT [FK_Contracts_DepositsPlans]
	FOREIGN KEY ([DepositPlan]) REFERENCES [DepositsPlans] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Deposits] ADD CONSTRAINT [FK_Deposits_Accounts]
	FOREIGN KEY ([MainAccount]) REFERENCES [Accounts] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Deposits] ADD CONSTRAINT [FK_Deposits_Accounts_02]
	FOREIGN KEY ([PercentAccount]) REFERENCES [Accounts] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [DepositsPlans] ADD CONSTRAINT [FK_DepositsPlans_Currencies]
	FOREIGN KEY ([Currency]) REFERENCES [Currencies] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [DepositsPlans] ADD CONSTRAINT [FK_DepositsPlans_DepositsNames]
	FOREIGN KEY ([Name]) REFERENCES [DepositsNames] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Transactions] ADD CONSTRAINT [FK_Transactions_Accounts]
	FOREIGN KEY ([Source]) REFERENCES [Accounts] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Transactions] ADD CONSTRAINT [FK_Transactions_Accounts_02]
	FOREIGN KEY ([Destination]) REFERENCES [Accounts] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Cities]
	FOREIGN KEY ([ResidenceCity]) REFERENCES [Cities] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Countries]
	FOREIGN KEY ([Citizenship]) REFERENCES [Countries] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Disabilities]
	FOREIGN KEY ([Disability]) REFERENCES [Disabilities] ([Id]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_MaritalStatuses]
	FOREIGN KEY ([MaritalStatus]) REFERENCES [MaritalStatuses] ([Id]) ON DELETE No Action ON UPDATE No Action
GO
