
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 09/17/2014 12:37:21
-- Generated from EDMX file: F:\jetcoder_jetcoder\tirth_billing\JewelInventory\Connections\Entities\inventory.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Inventory];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserLoginInformation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserLoginInformation];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK_AddressCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressSupplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Suppliers] DROP CONSTRAINT [FK_AddressSupplier];
GO
IF OBJECT_ID(N'[dbo].[FK_AddressUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_AddressUser];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseTransactionCostingRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JewelTransactions] DROP CONSTRAINT [FK_PurchaseTransactionCostingRate];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionLookupJewelTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JewelTransactions] DROP CONSTRAINT [FK_TransactionLookupJewelTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_LooseDiamondLookupLooseDiamondTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LooseDiamondTransactions] DROP CONSTRAINT [FK_LooseDiamondLookupLooseDiamondTransaction];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[LoginInformations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoginInformations];
GO
IF OBJECT_ID(N'[dbo].[Suppliers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Suppliers];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[ProductMasters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductMasters];
GO
IF OBJECT_ID(N'[dbo].[ConfigurationMasters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConfigurationMasters];
GO
IF OBJECT_ID(N'[dbo].[JewelTransactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JewelTransactions];
GO
IF OBJECT_ID(N'[dbo].[CostingDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CostingDetails];
GO
IF OBJECT_ID(N'[dbo].[JewelStockLedgers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JewelStockLedgers];
GO
IF OBJECT_ID(N'[dbo].[FinancialYearMasters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FinancialYearMasters];
GO
IF OBJECT_ID(N'[dbo].[TransactionLookups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionLookups];
GO
IF OBJECT_ID(N'[dbo].[JewelMasters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JewelMasters];
GO
IF OBJECT_ID(N'[dbo].[TraceLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TraceLogs];
GO
IF OBJECT_ID(N'[dbo].[LooseDiamondTransactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LooseDiamondTransactions];
GO
IF OBJECT_ID(N'[dbo].[TransactionInvoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionInvoices];
GO
IF OBJECT_ID(N'[dbo].[AccountLedgers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountLedgers];
GO
IF OBJECT_ID(N'[dbo].[FirmMasters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FirmMasters];
GO
IF OBJECT_ID(N'[dbo].[CreditNotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditNotes];
GO
IF OBJECT_ID(N'[dbo].[LooseDiamondLookups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LooseDiamondLookups];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressId] int IDENTITY(1,1) NOT NULL,
    [AddressLine1] nvarchar(100)  NOT NULL,
    [AddressLine2] nvarchar(100)  NULL,
    [City] nvarchar(100)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL,
    [State] nvarchar(100)  NOT NULL,
    [Country] nvarchar(100)  NOT NULL,
    [Phone] nvarchar(100)  NOT NULL,
    [Fax] nvarchar(100)  NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomersId] int IDENTITY(1,1) NOT NULL,
    [CustomersCode] varchar(100)  NOT NULL,
    [CompanyName] varchar(100)  NOT NULL,
    [ContactName] varchar(100)  NOT NULL,
    [CustomesStatus_Enum] smallint  NOT NULL,
    [CustomerProperties_Xml] varchar(max)  NOT NULL,
    [VATNumber] varchar(100)  NULL,
    [CSTNumber] nvarchar(max)  NULL,
    [PANNumber] nvarchar(max)  NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL,
    [Address_AddressId] int  NOT NULL
);
GO

-- Creating table 'LoginInformations'
CREATE TABLE [dbo].[LoginInformations] (
    [LoginId] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(100)  NOT NULL,
    [Password] varchar(100)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [UserType_Enum] smallint  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [SupplierId] int IDENTITY(1,1) NOT NULL,
    [SupplierCode] varchar(100)  NOT NULL,
    [CompanyName] varchar(100)  NOT NULL,
    [ContactName] varchar(100)  NOT NULL,
    [SupplierStatus_Enum] smallint  NOT NULL,
    [SupplierProperties_Xml] varchar(max)  NOT NULL,
    [VATNumber] varchar(100)  NULL,
    [PANNumber] nvarchar(max)  NULL,
    [CSTNumber] nvarchar(max)  NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL,
    [Address_AddressId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Email] varchar(100)  NOT NULL,
    [UserStatus_Enum] smallint  NOT NULL,
    [UserProperties_Xml] varchar(max)  NOT NULL,
    [UserImageId] int  NULL,
    [LastLoginDate] datetime  NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL,
    [LoginInformations_LoginId] int  NOT NULL,
    [Address_AddressId] int  NOT NULL
);
GO

-- Creating table 'ProductMasters'
CREATE TABLE [dbo].[ProductMasters] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'ConfigurationMasters'
CREATE TABLE [dbo].[ConfigurationMasters] (
    [ConfigurationId] int IDENTITY(1,1) NOT NULL,
    [Particulars] nvarchar(max)  NOT NULL,
    [ConfigurationValue] nvarchar(max)  NOT NULL,
    [ProductCategory_Enum] smallint  NOT NULL,
    [Remarks] nvarchar(max)  NULL,
    [Active] bit  NOT NULL,
    [JewelItemCategory_Enum] smallint  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL
);
GO

-- Creating table 'JewelTransactions'
CREATE TABLE [dbo].[JewelTransactions] (
    [JewelTransactionId] int IDENTITY(1,1) NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [CertificateNumber] nvarchar(max)  NULL,
    [JewelType] nvarchar(max)  NOT NULL,
    [JewelNumber] nvarchar(max)  NULL,
    [DesignCode] nvarchar(max)  NOT NULL,
    [TotalWeight] decimal(18,4)  NOT NULL,
    [MetalWeight] decimal(18,4)  NOT NULL,
    [MetalColor] nvarchar(max)  NULL,
    [StoneWeight] decimal(18,4)  NOT NULL,
    [StonePcs] int  NOT NULL,
    [CStoneWeight] decimal(18,4)  NOT NULL,
    [CStonePcs] int  NOT NULL,
    [TotalAmount] decimal(18,4)  NOT NULL,
    [TransactionDetails_Xml] nvarchar(max)  NOT NULL,
    [TransactionType_Enum] smallint  NOT NULL,
    [TransactionPartyRef] nvarchar(max)  NULL,
    [JewelItemCategory_Enum] smallint  NOT NULL,
    [KT] nvarchar(max)  NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL,
    [UpdatedTransactionBy] int  NULL,
    [CostingDetail_CostingDetailId] int  NULL,
    [TransactionLookup_TransactionLookupId] int  NOT NULL
);
GO

-- Creating table 'CostingDetails'
CREATE TABLE [dbo].[CostingDetails] (
    [CostingDetailId] int IDENTITY(1,1) NOT NULL,
    [CostingRates_Xml] nvarchar(max)  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL
);
GO

-- Creating table 'JewelStockLedgers'
CREATE TABLE [dbo].[JewelStockLedgers] (
    [JewelStockMasterId] int IDENTITY(1,1) NOT NULL,
    [JewelNumber] nvarchar(max)  NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [DesignCode] nvarchar(max)  NOT NULL,
    [JewelItemCategory_Enum] smallint  NOT NULL,
    [JewelType] nvarchar(max)  NOT NULL,
    [MetalWeight] decimal(18,4)  NOT NULL,
    [MetalColor] nvarchar(max)  NULL,
    [JewelState_Enum] smallint  NOT NULL,
    [StoneWeight] decimal(18,4)  NOT NULL,
    [StonePcs] int  NOT NULL,
    [CStoneWeight] decimal(18,4)  NOT NULL,
    [CStonePcs] int  NOT NULL,
    [KT] nvarchar(max)  NULL,
    [TotalWeight] decimal(18,4)  NOT NULL,
    [CertificateNumber] nvarchar(max)  NULL,
    [StockStatus_Enum] smallint  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL
);
GO

-- Creating table 'FinancialYearMasters'
CREATE TABLE [dbo].[FinancialYearMasters] (
    [FinancialYearMasterId] int IDENTITY(1,1) NOT NULL,
    [YearCode] nvarchar(max)  NOT NULL,
    [DateFrom] datetime  NOT NULL,
    [DateTo] datetime  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IsCancelled] bit  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL
);
GO

-- Creating table 'TransactionLookups'
CREATE TABLE [dbo].[TransactionLookups] (
    [TransactionLookupId] int IDENTITY(1,1) NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [ContactName] nvarchar(max)  NOT NULL,
    [DocNumber] nvarchar(max)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [TransactionType_Enum] smallint  NOT NULL,
    [NetAmount] decimal(18,4)  NOT NULL,
    [TransactionPartyRef] varchar(max)  NOT NULL,
    [MemoNumber] nvarchar(max)  NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL,
    [FinancialYearCode] nvarchar(max)  NOT NULL,
    [TransactionLookupDetail_Xml] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'JewelMasters'
CREATE TABLE [dbo].[JewelMasters] (
    [JewelId] int IDENTITY(1,1) NOT NULL,
    [JewelNo] nvarchar(max)  NOT NULL,
    [StyleNo] nvarchar(max)  NOT NULL,
    [JewelDescription] nvarchar(max)  NOT NULL,
    [MetalColor] nvarchar(max)  NULL,
    [DiamondPcs] int  NULL,
    [DiamondWt] decimal(18,4)  NULL,
    [CStoneWeight] decimal(18,4)  NOT NULL,
    [CStonePcs] int  NOT NULL,
    [GrsWt] decimal(18,0)  NULL,
    [NetWt] decimal(18,4)  NULL,
    [AccessedDate] datetime  NULL,
    [AccessedBy] int  NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'TraceLogs'
CREATE TABLE [dbo].[TraceLogs] (
    [TraceLogId] uniqueidentifier  NOT NULL,
    [TraceLogDate] datetime  NOT NULL,
    [LogGuid] varchar(max)  NULL,
    [LogDateTime] varchar(max)  NULL,
    [Level] varchar(max)  NULL,
    [MachineName] varchar(max)  NULL,
    [Class] varchar(max)  NULL,
    [Message] varchar(max)  NULL,
    [Exception] varchar(max)  NULL,
    [GCTotalMemory] bigint  NULL,
    [GCGen0Count] int  NULL,
    [GCGen1Count] int  NULL,
    [GCGen2Count] int  NULL,
    [GCMaxGen] int  NULL,
    [ProcessId] int  NULL,
    [Identity] varchar(max)  NULL
);
GO

-- Creating table 'LooseDiamondTransactions'
CREATE TABLE [dbo].[LooseDiamondTransactions] (
    [LooseDiamondTransactionId] int IDENTITY(1,1) NOT NULL,
    [SieveSize] decimal(18,4)  NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [DiamondWeight] decimal(18,4)  NOT NULL,
    [Quality] nvarchar(max)  NOT NULL,
    [Amount] decimal(18,4)  NOT NULL,
    [LooseDiamondType] nvarchar(max)  NOT NULL,
    [TransactionType_Enum] smallint  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL,
    [LooseDiamondLookup_LooseDiamondLookupId] int  NOT NULL
);
GO

-- Creating table 'TransactionInvoices'
CREATE TABLE [dbo].[TransactionInvoices] (
    [TransactionInvoiceId] int IDENTITY(1,1) NOT NULL,
    [InvoiceNumber] nvarchar(max)  NOT NULL,
    [InvoiceDate] datetime  NOT NULL,
    [NetAmount] decimal(18,4)  NOT NULL,
    [OtherCharges] decimal(18,4)  NOT NULL,
    [Tax] decimal(18,4)  NOT NULL,
    [TransactionPartyRef] varchar(max)  NOT NULL,
    [Remarks] nvarchar(max)  NOT NULL,
    [PaymentTerm] nvarchar(max)  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL,
    [Cancelled] bit  NOT NULL
);
GO

-- Creating table 'AccountLedgers'
CREATE TABLE [dbo].[AccountLedgers] (
    [TransactionInvoicesId] int IDENTITY(1,1) NOT NULL,
    [TransactionLookupKey] uniqueidentifier  NOT NULL,
    [InvoiceNumber] nvarchar(max)  NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [NetAmount] decimal(18,4)  NOT NULL,
    [OtherCharges] decimal(18,4)  NOT NULL,
    [Tax] decimal(18,4)  NOT NULL,
    [TransactionPartyRef] varchar(max)  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL
);
GO

-- Creating table 'FirmMasters'
CREATE TABLE [dbo].[FirmMasters] (
    [FirmMasterId] int IDENTITY(1,1) NOT NULL,
    [FirmName] nvarchar(max)  NOT NULL,
    [FirmEmail] nvarchar(max)  NOT NULL,
    [FirmTopHeader] nvarchar(max)  NULL,
    [FirmHeader] nvarchar(max)  NOT NULL,
    [FirmWebsite] nvarchar(max)  NOT NULL,
    [FirmLogo] varbinary(max)  NULL,
    [FirmVATNumber] varchar(100)  NOT NULL,
    [FirmTINNumber] varchar(100)  NOT NULL,
    [FirmAddress] nvarchar(max)  NOT NULL,
    [FirmAdditionalInfo] nvarchar(max)  NOT NULL,
    [Tax] decimal(18,2)  NOT NULL,
    [OtherTax] decimal(18,2)  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL,
    [SyncCatalogData] bit  NULL
);
GO

-- Creating table 'CreditNotes'
CREATE TABLE [dbo].[CreditNotes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerCode] nvarchar(max)  NOT NULL,
    [InvoiceNo] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [IsActive] bit  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL
);
GO

-- Creating table 'LooseDiamondLookups'
CREATE TABLE [dbo].[LooseDiamondLookups] (
    [LooseDiamondLookupId] int IDENTITY(1,1) NOT NULL,
    [FinancialYearCode] nvarchar(max)  NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [ContactName] nvarchar(max)  NOT NULL,
    [DocNumber] nvarchar(max)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [TransactionPartyRef] nvarchar(max)  NULL,
    [TransactionType_Enum] smallint  NOT NULL,
    [AccessedDate] datetime  NOT NULL,
    [AccessedBy] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AddressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- Creating primary key on [CustomersId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomersId] ASC);
GO

-- Creating primary key on [LoginId] in table 'LoginInformations'
ALTER TABLE [dbo].[LoginInformations]
ADD CONSTRAINT [PK_LoginInformations]
    PRIMARY KEY CLUSTERED ([LoginId] ASC);
GO

-- Creating primary key on [SupplierId] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([SupplierId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ProductId] in table 'ProductMasters'
ALTER TABLE [dbo].[ProductMasters]
ADD CONSTRAINT [PK_ProductMasters]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [ConfigurationId] in table 'ConfigurationMasters'
ALTER TABLE [dbo].[ConfigurationMasters]
ADD CONSTRAINT [PK_ConfigurationMasters]
    PRIMARY KEY CLUSTERED ([ConfigurationId] ASC);
GO

-- Creating primary key on [JewelTransactionId] in table 'JewelTransactions'
ALTER TABLE [dbo].[JewelTransactions]
ADD CONSTRAINT [PK_JewelTransactions]
    PRIMARY KEY CLUSTERED ([JewelTransactionId] ASC);
GO

-- Creating primary key on [CostingDetailId] in table 'CostingDetails'
ALTER TABLE [dbo].[CostingDetails]
ADD CONSTRAINT [PK_CostingDetails]
    PRIMARY KEY CLUSTERED ([CostingDetailId] ASC);
GO

-- Creating primary key on [JewelStockMasterId] in table 'JewelStockLedgers'
ALTER TABLE [dbo].[JewelStockLedgers]
ADD CONSTRAINT [PK_JewelStockLedgers]
    PRIMARY KEY CLUSTERED ([JewelStockMasterId] ASC);
GO

-- Creating primary key on [FinancialYearMasterId] in table 'FinancialYearMasters'
ALTER TABLE [dbo].[FinancialYearMasters]
ADD CONSTRAINT [PK_FinancialYearMasters]
    PRIMARY KEY CLUSTERED ([FinancialYearMasterId] ASC);
GO

-- Creating primary key on [TransactionLookupId] in table 'TransactionLookups'
ALTER TABLE [dbo].[TransactionLookups]
ADD CONSTRAINT [PK_TransactionLookups]
    PRIMARY KEY CLUSTERED ([TransactionLookupId] ASC);
GO

-- Creating primary key on [JewelId] in table 'JewelMasters'
ALTER TABLE [dbo].[JewelMasters]
ADD CONSTRAINT [PK_JewelMasters]
    PRIMARY KEY CLUSTERED ([JewelId] ASC);
GO

-- Creating primary key on [TraceLogId] in table 'TraceLogs'
ALTER TABLE [dbo].[TraceLogs]
ADD CONSTRAINT [PK_TraceLogs]
    PRIMARY KEY CLUSTERED ([TraceLogId] ASC);
GO

-- Creating primary key on [LooseDiamondTransactionId] in table 'LooseDiamondTransactions'
ALTER TABLE [dbo].[LooseDiamondTransactions]
ADD CONSTRAINT [PK_LooseDiamondTransactions]
    PRIMARY KEY CLUSTERED ([LooseDiamondTransactionId] ASC);
GO

-- Creating primary key on [TransactionInvoiceId] in table 'TransactionInvoices'
ALTER TABLE [dbo].[TransactionInvoices]
ADD CONSTRAINT [PK_TransactionInvoices]
    PRIMARY KEY CLUSTERED ([TransactionInvoiceId] ASC);
GO

-- Creating primary key on [TransactionInvoicesId] in table 'AccountLedgers'
ALTER TABLE [dbo].[AccountLedgers]
ADD CONSTRAINT [PK_AccountLedgers]
    PRIMARY KEY CLUSTERED ([TransactionInvoicesId] ASC);
GO

-- Creating primary key on [FirmMasterId] in table 'FirmMasters'
ALTER TABLE [dbo].[FirmMasters]
ADD CONSTRAINT [PK_FirmMasters]
    PRIMARY KEY CLUSTERED ([FirmMasterId] ASC);
GO

-- Creating primary key on [Id] in table 'CreditNotes'
ALTER TABLE [dbo].[CreditNotes]
ADD CONSTRAINT [PK_CreditNotes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LooseDiamondLookupId] in table 'LooseDiamondLookups'
ALTER TABLE [dbo].[LooseDiamondLookups]
ADD CONSTRAINT [PK_LooseDiamondLookups]
    PRIMARY KEY CLUSTERED ([LooseDiamondLookupId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LoginInformations_LoginId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserLoginInformation]
    FOREIGN KEY ([LoginInformations_LoginId])
    REFERENCES [dbo].[LoginInformations]
        ([LoginId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLoginInformation'
CREATE INDEX [IX_FK_UserLoginInformation]
ON [dbo].[Users]
    ([LoginInformations_LoginId]);
GO

-- Creating foreign key on [Address_AddressId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_AddressCustomer]
    FOREIGN KEY ([Address_AddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressCustomer'
CREATE INDEX [IX_FK_AddressCustomer]
ON [dbo].[Customers]
    ([Address_AddressId]);
GO

-- Creating foreign key on [Address_AddressId] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [FK_AddressSupplier]
    FOREIGN KEY ([Address_AddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressSupplier'
CREATE INDEX [IX_FK_AddressSupplier]
ON [dbo].[Suppliers]
    ([Address_AddressId]);
GO

-- Creating foreign key on [Address_AddressId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_AddressUser]
    FOREIGN KEY ([Address_AddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressUser'
CREATE INDEX [IX_FK_AddressUser]
ON [dbo].[Users]
    ([Address_AddressId]);
GO

-- Creating foreign key on [CostingDetail_CostingDetailId] in table 'JewelTransactions'
ALTER TABLE [dbo].[JewelTransactions]
ADD CONSTRAINT [FK_PurchaseTransactionCostingRate]
    FOREIGN KEY ([CostingDetail_CostingDetailId])
    REFERENCES [dbo].[CostingDetails]
        ([CostingDetailId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseTransactionCostingRate'
CREATE INDEX [IX_FK_PurchaseTransactionCostingRate]
ON [dbo].[JewelTransactions]
    ([CostingDetail_CostingDetailId]);
GO

-- Creating foreign key on [TransactionLookup_TransactionLookupId] in table 'JewelTransactions'
ALTER TABLE [dbo].[JewelTransactions]
ADD CONSTRAINT [FK_TransactionLookupJewelTransaction]
    FOREIGN KEY ([TransactionLookup_TransactionLookupId])
    REFERENCES [dbo].[TransactionLookups]
        ([TransactionLookupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionLookupJewelTransaction'
CREATE INDEX [IX_FK_TransactionLookupJewelTransaction]
ON [dbo].[JewelTransactions]
    ([TransactionLookup_TransactionLookupId]);
GO

-- Creating foreign key on [LooseDiamondLookup_LooseDiamondLookupId] in table 'LooseDiamondTransactions'
ALTER TABLE [dbo].[LooseDiamondTransactions]
ADD CONSTRAINT [FK_LooseDiamondLookupLooseDiamondTransaction]
    FOREIGN KEY ([LooseDiamondLookup_LooseDiamondLookupId])
    REFERENCES [dbo].[LooseDiamondLookups]
        ([LooseDiamondLookupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LooseDiamondLookupLooseDiamondTransaction'
CREATE INDEX [IX_FK_LooseDiamondLookupLooseDiamondTransaction]
ON [dbo].[LooseDiamondTransactions]
    ([LooseDiamondLookup_LooseDiamondLookupId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------