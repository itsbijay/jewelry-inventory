using System;
using System.ComponentModel;
using System.IO;
using System.Configuration.Install;
using System.Collections;
using JetCoders.Shared;
using System.Data.SqlClient;


namespace JewelInstaller
{
	[RunInstaller(true)]
	public class JewelInstaller : Installer
	{

		private const String DbName = "Inventory";
		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
		public override void Install(IDictionary savedState)
		{
			base.Install(savedState);
			RunAndGo();
		}


		public void RunAndGo()
		{
			using (var conn = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True"))
			{
				conn.Open();
				const string dbsqlText = @"IF EXISTS (SELECT * FROM SYSDATABASES WHERE NAME='" + DbName + "')" +
				                         " BEGIN " +
				                         "	select 1; " +
				                         " END " +
				                         " ELSE " +
				                         " BEGIN  " +
				                         "	select 0;  " +
				                         " END";
				var command = new SqlCommand(dbsqlText, conn);
				try
				{
					var i = (Int32)command.ExecuteScalar();
					if (i == 1) return;
				}
				catch (Exception e)
				{
					return;
				}

			}

			using (var conn = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True"))
			{
				conn.Open();
				const string dbsqlText = @"IF NOT EXISTS (SELECT * FROM SYSDATABASES WHERE NAME='" + DbName + "')  CREATE DATABASE " + DbName + ";";
				var command = new SqlCommand(dbsqlText, conn);
				try
				{
					command.ExecuteNonQuery();
				}
				catch (Exception)
				{
					// MDF LDf already exists
					const string subKey = "SOFTWARE\\Microsoft\\Microsoft SQL Server\\MSSQL10.SQLEXPRESS\\Setup";
					const string keyname = "SQLPath";

					var regedit = new RegistryUtility();
					var path = regedit.Read(subKey, keyname);

					var mdfFilePath = path + "\\Data\\" + DbName + ".mdf";
					var ldfFilePath = path + "\\Data\\" + DbName + "_Log.ldf";


					var dbsqlAttachText = @"CREATE DATABASE [" + DbName + "] ON  ( FILENAME = N'" + mdfFilePath + "' ), ( FILENAME = N'" + ldfFilePath + "' ) FOR ATTACH ;";

					if (File.Exists(mdfFilePath) && File.Exists(ldfFilePath))
					{
						command = new SqlCommand(dbsqlAttachText, conn);
						command.ExecuteNonQuery();
					}

					return;
				}
			}

			using (var conn = new SqlConnection(@"Data Source=.\SqlExpress;Initial Catalog=" + DbName + ";Integrated Security=True;MultipleActiveResultSets=True"))
			{
				conn.Open();
                const string tablesqlText = @"
USE INVENTORY

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[JewelStockLedgers]') AND type in (N'U'))
BEGIN
CREATE TABLE [JewelStockLedgers](
	[JewelStockMasterId] [int] IDENTITY(1,1) NOT NULL,
	[JewelNumber] [nvarchar](max) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[DesignCode] [nvarchar](max) NOT NULL,
	[MetalType_Enum] [smallint] NOT NULL,
	[MetalWeight] [decimal](18, 4) NOT NULL,
	[MetalColor] [nvarchar](max) NULL,
	[StoneWeight] [decimal](18, 4) NOT NULL,
	[StonePcs] [int] NOT NULL,
	[CStoneWeight] [decimal](18, 4) NOT NULL,
	[CStonePcs] [int] NOT NULL,
	[KT] [nvarchar](max) NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[CertificateNumber] [nvarchar](max) NOT NULL,
	[StockStatus_Enum] [smallint] NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
 CONSTRAINT [PK_JewelStockLedgers] PRIMARY KEY CLUSTERED 
(
	[JewelStockMasterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[JewelMasters]') AND type in (N'U'))
BEGIN
CREATE TABLE [JewelMasters](
	[JewelId] [int] IDENTITY(1,1) NOT NULL,
	[JewelNo] [nvarchar](max) NOT NULL,
	[StyleNo] [nvarchar](max) NOT NULL,
	[JewelDescription] [nvarchar](max) NOT NULL,
	[MetalColor] [nvarchar](max) NOT NULL,
	[ImagePath] [nvarchar](max) NOT NULL,
	[DiamondPcs] [int] NULL,
	[DiamondWt] [decimal](18, 4) NULL,
	[GoldPcs] [int] NULL,
	[GoldWt] [decimal](18, 4) NULL,
	[AccessedDate] [datetime] NULL,
	[AccessedBy] [int] NULL,
 CONSTRAINT [PK_JewelMasters] PRIMARY KEY CLUSTERED 
(
	[JewelId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[FirmMasters]') AND type in (N'U'))
BEGIN
CREATE TABLE [FirmMasters](
	[FirmMasterId] [int] IDENTITY(1,1) NOT NULL,
	[FirmName] [nvarchar](max) NOT NULL,
	[FirmEmail] [nvarchar](max) NOT NULL,
	[FirmHeader] [nvarchar](max) NOT NULL,
	[FirmWebsite] [nvarchar](max) NOT NULL,
	[FirmLogo] [varbinary](max) NULL,
	[FirmVATNumber] [varchar](100) NULL,
	[FirmTINNumber] [varchar](100) NULL,
	[FirmAddress] [nvarchar](max) NULL,
	[FirmAdditionalInfo] [nvarchar](max) NULL,
	[Tax] [decimal](18, 2) NULL,
	[OtherTax] [decimal](18, 2) NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
 CONSTRAINT [PK_FirmMasters] PRIMARY KEY CLUSTERED 
(
	[FirmMasterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_PADDING OFF

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[FinancialYearMasters]') AND type in (N'U'))
BEGIN
CREATE TABLE [FinancialYearMasters](
	[FinancialYearMasterId] [int] IDENTITY(1,1) NOT NULL,
	[YearCode] [nvarchar](max) NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsCancelled] [bit] NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
 CONSTRAINT [PK_FinancialYearMasters] PRIMARY KEY CLUSTERED 
(
	[FinancialYearMasterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TransactionLookups]') AND type in (N'U'))
BEGIN
CREATE TABLE [TransactionLookups](
	[TransactionLookupId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionLookupKey] [uniqueidentifier] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[TransactionType_Enum] [smallint] NOT NULL,
	[NetAmount] [decimal](18, 4) NOT NULL,
	[TransactionPartyRef] [varchar](max) NOT NULL,
	[MemoNumber] [nvarchar](max) NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
 CONSTRAINT [PK_TransactionLookups] PRIMARY KEY CLUSTERED 
(
	[TransactionLookupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_PADDING OFF

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TransactionInvoices]') AND type in (N'U'))
BEGIN
CREATE TABLE [TransactionInvoices](
	[TransactionInvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [nvarchar](max) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[NetAmount] [decimal](18, 4) NOT NULL,
	[OtherCharges] [decimal](18, 4) NOT NULL,
	[Tax] [decimal](18, 4) NOT NULL,
	[TransactionPartyRef] [varchar](max) NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	[PaymentTerm] [nvarchar](max) NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
 CONSTRAINT [PK_TransactionInvoices] PRIMARY KEY CLUSTERED 
(
	[TransactionInvoiceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_PADDING OFF

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[TraceLogs]') AND type in (N'U'))
BEGIN
CREATE TABLE [TraceLogs](
	[TraceLogId] [uniqueidentifier] NOT NULL,
	[TraceLogDate] [datetime] NOT NULL,
	[LogGuid] [varchar](max) NULL,
	[LogDateTime] [varchar](max) NULL,
	[Level] [varchar](max) NULL,
	[MachineName] [varchar](max) NULL,
	[Class] [varchar](max) NULL,
	[Message] [varchar](max) NULL,
	[Exception] [varchar](max) NULL,
	[GCTotalMemory] [bigint] NULL,
	[GCGen0Count] [int] NULL,
	[GCGen1Count] [int] NULL,
	[GCGen2Count] [int] NULL,
	[GCMaxGen] [int] NULL,
	[ProcessId] [int] NULL,
	[Identity] [varchar](max) NULL,
 CONSTRAINT [PK_TraceLogs] PRIMARY KEY CLUSTERED 
(
	[TraceLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_PADDING OFF

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CostingDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [CostingDetails](
	[CostingDetailId] [int] IDENTITY(1,1) NOT NULL,
	[CostingRates_Xml] [nvarchar](max) NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
 CONSTRAINT [PK_CostingDetails] PRIMARY KEY CLUSTERED 
(
	[CostingDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ConfigurationMasters]') AND type in (N'U'))
BEGIN
CREATE TABLE [ConfigurationMasters](
	[ConfigurationId] [int] IDENTITY(1,1) NOT NULL,
	[Particulars] [nvarchar](max) NOT NULL,
	[ConfigurationValue] [nvarchar](max) NOT NULL,
	[ProductCategory_Enum] [smallint] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
	[MetalType_Enum] [smallint] NOT NULL
) ON [PRIMARY]
END

SET IDENTITY_INSERT [ConfigurationMasters] ON
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (1, N'Alloy', N'Alloy', 101, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (2, N'14 KT', N'14 KT', 101, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (3, N'18 KT', N'18 KT', 101, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (4, N'22 KT', N'22 KT', 101, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (5, N'9 KT', N'9 KT', 101, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (6, N'995', N'995', 101, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (7, N'999', N'999', 101, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (8, N'CS-Real', N'Real', 104, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (9, N'CS-Semi Precious', N'Semi Precious', 104, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (10, N'Buggets', N'1/5', 102, N'1/5 (0.176 To 0.21)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (11, N'Buggets', N'1/4', 102, N'1/4 (0.22 To 0.27)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (12, N'Buggets', N'1/3', 102, N'1/4 (0.28 To 0.37)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (13, N'Buggets', N'3/8', 102, N'3/8 (0.38 To 0.43)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (14, N'Buggets', N'1/2', 102, N'1/2 (0.44 To 0.69)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (15, N'Buggets', N'SEVENTY', 102, N'SEVENTY (0.70 To 0.89)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (16, N'Buggets', N'NINTY', 102, N'NINTY(0.90 To 0.99)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (17, N'Buggets', N'-2', 102, N'-2 (0.004 To 0.008)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (18, N'Buggets', N'+2-6', 102, N'+2-6 (0.009 To 0.018)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (19, N'Buggets', N'+6-10', 102, N'+6-10 (0.019 To 0.058)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (20, N'Buggets', N'+10-11', 102, N'+10-11 (0.059 To 0.074)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (21, N'Buggets', N'+11-13', 102, N'+11-13 (0.075 To 0.108)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (22, N'Buggets', N'1/8', 102, N'1/8 (0.11 To 0.125)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (23, N'Buggets', N'1/7', 102, N'1/7 (0.13 To 0.146)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (24, N'Buggets', N'1/6', 102, N'1/6 (0.147 To 0.175)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (25, N'Choki', N'1/5', 102, N'1/5 (0.176 To 0.21)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (26, N'Choki', N'1/4', 102, N'1/4 (0.22 To 0.27)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (27, N'Choki', N'1/3', 102, N'1/4 (0.28 To 0.37)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (28, N'Choki', N'3/8', 102, N'3/8 (0.38 To 0.43)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (29, N'Choki', N'1/2', 102, N'1/2 (0.44 To 0.69)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (30, N'Choki', N'SEVENTY', 102, N'SEVENTY (0.70 To 0.89)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (31, N'Choki', N'NINTY', 102, N'NINTY(0.90 To 0.99)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (32, N'Choki', N'-2', 102, N'-2 (0.004 To 0.008)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (33, N'Choki', N'+2-6', 102, N'+2-6 (0.009 To 0.018)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (34, N'Choki', N'+6-10', 102, N'+6-10 (0.019 To 0.058)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (35, N'Choki', N'+10-11', 102, N'+10-11 (0.059 To 0.074)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (36, N'Choki', N'+11-13', 102, N'+11-13 (0.075 To 0.108)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (37, N'Choki', N'1/8', 102, N'1/8 (0.11 To 0.125)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (38, N'Choki', N'1/7', 102, N'1/7 (0.13 To 0.146)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (39, N'Choki', N'1/6', 102, N'1/6 (0.147 To 0.175)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (40, N'Marquis', N'1/5', 102, N'1/5 (0.176 To 0.21)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (41, N'Marquis', N'1/4', 102, N'1/4 (0.22 To 0.27)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (42, N'Marquis', N'1/3', 102, N'1/4 (0.28 To 0.37)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (43, N'Marquis', N'3/8', 102, N'3/8 (0.38 To 0.43)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (44, N'Marquis', N'1/2', 102, N'1/2 (0.44 To 0.69)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (45, N'Marquis', N'SEVENTY', 102, N'SEVENTY (0.70 To 0.89)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (46, N'Marquis', N'NINTY', 102, N'NINTY(0.90 To 0.99)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (47, N'Marquis', N'-2', 102, N'-2 (0.004 To 0.008)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (48, N'Marquis', N'+2-6', 102, N'+2-6 (0.009 To 0.018)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (49, N'Marquis', N'+6-10', 102, N'+6-10 (0.019 To 0.058)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (50, N'Marquis', N'+10-11', 102, N'+10-11 (0.059 To 0.074)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (51, N'Marquis', N'+11-13', 102, N'+11-13 (0.075 To 0.108)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (52, N'Marquis', N'1/8', 102, N'1/8 (0.11 To 0.125)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (53, N'Marquis', N'1/7', 102, N'1/7 (0.13 To 0.146)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (54, N'Marquis', N'1/6', 102, N'1/6 (0.147 To 0.175)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (55, N'Priancess', N'1/5', 102, N'1/5 (0.176 To 0.21)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (56, N'Priancess', N'1/4', 102, N'1/4 (0.22 To 0.27)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (57, N'Priancess', N'1/3', 102, N'1/4 (0.28 To 0.37)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (58, N'Priancess', N'3/8', 102, N'3/8 (0.38 To 0.43)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (59, N'Priancess', N'1/2', 102, N'1/2 (0.44 To 0.69)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (60, N'Priancess', N'SEVENTY', 102, N'SEVENTY (0.70 To 0.89)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (61, N'Priancess', N'NINTY', 102, N'NINTY(0.90 To 0.99)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (62, N'Priancess', N'-2', 102, N'-2 (0.004 To 0.008)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (63, N'Priancess', N'+2-6', 102, N'+2-6 (0.009 To 0.018)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (64, N'Priancess', N'+6-10', 102, N'+6-10 (0.019 To 0.058)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (65, N'Priancess', N'+10-11', 102, N'+10-11 (0.059 To 0.074)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (66, N'Priancess', N'+11-13', 102, N'+11-13 (0.075 To 0.108)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (67, N'Priancess', N'1/8', 102, N'1/8 (0.11 To 0.125)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (68, N'Priancess', N'1/7', 102, N'1/7 (0.13 To 0.146)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (69, N'Priancess', N'1/6', 102, N'1/6 (0.147 To 0.175)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (70, N'Round', N'-2', 102, N'-2 (0.004 To 0.008)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (71, N'Round', N'+2-6', 102, N'+2-6 (0.009 To 0.018)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (72, N'Round', N'+6-10', 102, N'+6-10 (0.019 To 0.058)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (73, N'Round', N'+10-11', 102, N'+10-11 (0.059 To 0.074)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (74, N'Round', N'+11-13', 102, N'+11-13 (0.075 To 0.108)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (75, N'Round', N'1/8', 102, N'1/8 (0.11 To 0.125)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (76, N'Round', N'1/7', 102, N'1/7 (0.13 To 0.146)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (77, N'Round', N'1/6', 102, N'1/6 (0.147 To 0.175)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (78, N'Round', N'1/5', 102, N'1/5 (0.176 To 0.21)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (79, N'Round', N'1/4', 102, N'1/4 (0.22 To 0.27)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (80, N'Round', N'1/3', 102, N'1/4 (0.28 To 0.37)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (81, N'Round', N'3/8', 102, N'3/8 (0.38 To 0.43)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (82, N'Round', N'1/2', 102, N'1/2 (0.44 To 0.69)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (83, N'Round', N'SEVENTY', 102, N'SEVENTY (0.70 To 0.89)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (84, N'Round', N'NINTY', 102, N'NINTY(0.90 To 0.99)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (85, N'Tappers', N'1/5', 102, N'1/5 (0.176 To 0.21)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (86, N'Tappers', N'1/4', 102, N'1/4 (0.22 To 0.27)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (87, N'Tappers', N'1/3', 102, N'1/4 (0.28 To 0.37)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (88, N'Tappers', N'3/8', 102, N'3/8 (0.38 To 0.43)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (89, N'Tappers', N'1/2', 102, N'1/2 (0.44 To 0.69)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (90, N'Tappers', N'SEVENTY', 102, N'SEVENTY (0.70 To 0.89)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (91, N'Tappers', N'NINTY', 102, N'NINTY(0.90 To 0.99)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (92, N'Tappers', N'-2', 102, N'-2 (0.004 To 0.008)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (93, N'Tappers', N'+2-6', 102, N'+2-6 (0.009 To 0.018)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (94, N'Tappers', N'+6-10', 102, N'+6-10 (0.019 To 0.058)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (95, N'Tappers', N'+10-11', 102, N'+10-11 (0.059 To 0.074)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (96, N'Tappers', N'+11-13', 102, N'+11-13 (0.075 To 0.108)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (97, N'Tappers', N'1/8', 102, N'1/8 (0.11 To 0.125)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (98, N'Tappers', N'1/7', 102, N'1/7 (0.13 To 0.146)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (99, N'Tappers', N'1/6', 102, N'1/6 (0.147 To 0.175)', 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (100, N'Bangles', N'Bangles', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)

print 'Processed 100 total records'
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (101, N'Braclets', N'Braclets', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (102, N'Chains', N'Chains', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (103, N'Earring', N'Earring', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (104, N'Necklase Set', N'Necklase Set', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (105, N'Necklases', N'Necklases', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (106, N'Nose Rings', N'Nose Ring', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (107, N'Pendant Set', N'Pendant Set', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (108, N'Pendants', N'Pendants', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (109, N'Ring', N'Ring', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (110, N'Tanmania', N'Tanmania', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (111, N'Tanmania Set', N'Tanmania Set', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (112, N'Watches', N'Watches', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (113, N'Bangles', N'Bangles', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (114, N'Braclets', N'Braclets', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (115, N'Chains', N'Chains', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (116, N'Earring', N'Earring', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (117, N'Necklase Set', N'Necklase Set', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (118, N'Necklases', N'Necklases', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (119, N'Nose Rings', N'Nose Ring', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (120, N'Pendant Set', N'Pendant Set', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (121, N'Pendants', N'Pendants', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (122, N'Ring', N'Ring', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (123, N'Tanmania', N'Tanmania', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (124, N'Tanmania Set', N'Tanmania Set', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (125, N'Watches', N'Watches', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (126, N'Bangles', N'Bangles', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (127, N'Braclets', N'Braclets', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (128, N'Chains', N'Chains', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (129, N'Earring', N'Earring', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (130, N'Necklase Set', N'Necklase Set', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (131, N'Necklases', N'Necklases', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (132, N'Nose Rings', N'Nose Ring', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (133, N'Pendant Set', N'Pendant Set', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (134, N'Pendants', N'Pendants', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (135, N'Ring', N'Ring', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (136, N'Tanmania', N'Tanmania', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (137, N'Tanmania Set', N'Tanmania Set', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (138, N'Watches', N'Watches', 103, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (139, N'CS-Real', N'Real', 104, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (140, N'CS-Semi Precious', N'Semi Precious', 104, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (141, N'CS-Real', N'Real', 104, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (142, N'CS-Semi Precious', N'Semi Precious', 104, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 35)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (146, N'Cubic Zirconia ', N'CZ', 104, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 33)
INSERT [ConfigurationMasters] ([ConfigurationId], [Particulars], [ConfigurationValue], [ProductCategory_Enum], [Remarks], [Active], [AccessedDate], [AccessedBy], [MetalType_Enum]) VALUES (147, N'Cubic Zirconia ', N'CZ', 104, NULL, 1, CAST(0x00009FCB00000000 AS DateTime), 0, 34)
SET IDENTITY_INSERT [ConfigurationMasters] OFF
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Addresses]') AND type in (N'U'))
BEGIN
CREATE TABLE [Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressLine1] [nvarchar](100) NOT NULL,
	[AddressLine2] [nvarchar](100) NULL,
	[City] [nvarchar](100) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[State] [nvarchar](100) NOT NULL,
	[Country] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](100) NOT NULL,
	[Fax] [nvarchar](100) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET IDENTITY_INSERT [Addresses] ON
INSERT [Addresses] ([AddressId], [AddressLine1], [AddressLine2], [City], [PostalCode], [State], [Country], [Phone], [Fax]) VALUES (1, N'D-24, DEBONAIR SOCIETY', N'ALMEIDA ROAD, CHANDANWADI', N'THANE ', 400602, N'MAHARASHTRA', N'INDIA', N'9967996073', NULL)
SET IDENTITY_INSERT [Addresses] OFF
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AccountLedgers]') AND type in (N'U'))
BEGIN
CREATE TABLE [AccountLedgers](
	[TransactionInvoicesId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionLookupKey] [uniqueidentifier] NOT NULL,
	[InvoiceNumber] [nvarchar](max) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[NetAmount] [decimal](18, 4) NOT NULL,
	[OtherCharges] [decimal](18, 4) NOT NULL,
	[Tax] [decimal](18, 4) NOT NULL,
	[TransactionPartyRef] [varchar](max) NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
 CONSTRAINT [PK_AccountLedgers] PRIMARY KEY CLUSTERED 
(
	[TransactionInvoicesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_PADDING OFF

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ProductMasters]') AND type in (N'U'))
BEGIN
CREATE TABLE [ProductMasters](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ProductMasters] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LooseDiamondTransactions]') AND type in (N'U'))
BEGIN
CREATE TABLE [LooseDiamondTransactions](
	[LooseDiamondTransactionId] [int] IDENTITY(1,1) NOT NULL,
	[FinancialYearCode] [nvarchar](max) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[TransactionLookupKey] [uniqueidentifier] NOT NULL,
	[ContactName] [nvarchar](max) NOT NULL,
	[DocNumber] [nvarchar](max) NULL,
	[Remarks] [nvarchar](max) NULL,
	[TransactionPartyRef] [nvarchar](max) NULL,
	[SieveSize] [decimal](18, 4) NOT NULL,
	[DiamondWeight] [decimal](18, 4) NOT NULL,
	[Quality] [nvarchar](max) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[LooseDiamondType] [nvarchar](max) NOT NULL,
	[TransactionType_Enum] [smallint] NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
 CONSTRAINT [PK_LooseDiamondTransactions] PRIMARY KEY CLUSTERED 
(
	[LooseDiamondTransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[LoginInformations]') AND type in (N'U'))
BEGIN
CREATE TABLE [LoginInformations](
	[LoginId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UserType_Enum] [smallint] NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
 CONSTRAINT [PK_LoginInformations] PRIMARY KEY CLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_PADDING OFF

SET IDENTITY_INSERT [LoginInformations] ON
INSERT [LoginInformations] ([LoginId], [Username], [Password], [IsActive], [UserType_Enum], [AccessedDate], [AccessedBy]) VALUES (1, N'superuser', N'mail_123', 1, 447, CAST(0x00009FCB00000000 AS DateTime), 0)
SET IDENTITY_INSERT [LoginInformations] OFF
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[JewelTransactions]') AND type in (N'U'))
BEGIN
CREATE TABLE [JewelTransactions](
	[JewelTransactionId] [int] IDENTITY(1,1) NOT NULL,
	[FinancialYearCode] [nvarchar](max) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[TransactionLookupKey] [uniqueidentifier] NOT NULL,
	[ContactName] [nvarchar](max) NOT NULL,
	[DocNumber] [nvarchar](max) NULL,
	[Remarks] [nvarchar](max) NULL,
	[CertificateNumber] [nvarchar](max) NULL,
	[JewelType] [nvarchar](max) NOT NULL,
	[JewelNumber] [nvarchar](max) NULL,
	[DesignCode] [nvarchar](max) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[MetalWeight] [decimal](18, 4) NOT NULL,
	[MetalColor] [nvarchar](max) NULL,
	[StoneWeight] [decimal](18, 4) NOT NULL,
	[StonePcs] [int] NOT NULL,
	[CStoneWeight] [decimal](18, 4) NOT NULL,
	[CStonePcs] [int] NOT NULL,
	[TotalAmount] [decimal](18, 4) NOT NULL,
	[TransactionDetails_Xml] [nvarchar](max) NOT NULL,
	[TransactionType_Enum] [smallint] NOT NULL,
	[TransactionPartyRef] [nvarchar](max) NULL,
	[MetalType_Enum] [smallint] NOT NULL,
	[KT] [nvarchar](max) NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
	[CostingDetail_CostingDetailId] [int] NULL,
 CONSTRAINT [PK_JewelTransactions] PRIMARY KEY CLUSTERED 
(
	[JewelTransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[UserStatus_Enum] [smallint] NOT NULL,
	[UserProperties_Xml] [varchar](max) NOT NULL,
	[UserImageId] [int] NULL,
	[LastLoginDate] [datetime] NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
	[LoginInformations_LoginId] [int] NOT NULL,
	[Address_AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_PADDING OFF

SET IDENTITY_INSERT [Users] ON
INSERT [Users] ([UserId], [Email], [UserStatus_Enum], [UserProperties_Xml], [UserImageId], [LastLoginDate], [AccessedDate], [AccessedBy], [LoginInformations_LoginId], [Address_AddressId]) VALUES (5, N'admin@jetcodersolutions.com', 447, N'<UserProperties xmlns=""http://schemas.datacontract.org/2004/07/Connections"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">  <Email>admin@jetcodersolutions.com</Email>   <FirstName>superuser</FirstName>    <LastName>superuser</LastName>   <MiddleName /> </UserProperties>', NULL, CAST(0x0000A1A90110681A AS DateTime), CAST(0x00009FCB00000000 AS DateTime), 0, 1, 1)
SET IDENTITY_INSERT [Users] OFF
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Suppliers]') AND type in (N'U'))
BEGIN
CREATE TABLE [Suppliers](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[SupplierCode] [varchar](100) NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[ContactName] [varchar](100) NOT NULL,
	[SupplierStatus_Enum] [smallint] NOT NULL,
	[SupplierProperties_Xml] [varchar](max) NOT NULL,
	[VATNumber] [varchar](100) NOT NULL,
	[PANNumber] [nvarchar](max) NOT NULL,
	[CSTNumber] [nvarchar](max) NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
	[Address_AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_PADDING OFF

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [Customers](
	[CustomersId] [int] IDENTITY(1,1) NOT NULL,
	[CustomersCode] [varchar](100) NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[ContactName] [varchar](100) NOT NULL,
	[CustomesStatus_Enum] [smallint] NOT NULL,
	[CustomerProperties_Xml] [varchar](max) NOT NULL,
	[VATNumber] [varchar](100) NOT NULL,
	[CSTNumber] [nvarchar](max) NOT NULL,
	[PANNumber] [nvarchar](max) NOT NULL,
	[AccessedDate] [datetime] NOT NULL,
	[AccessedBy] [int] NOT NULL,
	[Address_AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomersId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_PADDING OFF

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CostingReport_StoneDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [CostingReport_StoneDetail]
(
    @JeweltransId varchar(max) = ''''
)
AS 
BEGIN


DECLARE @TEMP TABLE (AliasesValue XML)

INSERT INTO @TEMP
	SELECT CAST( Replace(Replace([TransactionDetails_Xml], ''xmlns=""http://schemas.datacontract.org/2004/07/Connections"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""'', ''''), ''<?xml version=""1.0"" encoding=""UTF-8""?>'', '''') AS XML) From JewelTransactions where JewelTransactionId = @JeweltransId
			
SELECT c.query(''data(StoneSieveSz)'') AS [SIEV.SZ], c.query(''data(StonePcs)'') AS [DIA PCS], c.query(''data(StoneWt)'') AS [DIA.WT], c.query(''data(StoneValue)'') AS [DIA.PR]
 	FROM @TEMP r
	CROSS APPLY AliasesValue.nodes(''TransactionDetails/ItemDetails/StoneDetail/StoneChart/StoneMetaDetailList/StoneMetaDetail'') x(c)
END
' 
END

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CostingReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [CostingReport]
(
    @Jeweltrans varchar(max) = ''''
)
AS 
BEGIN

DECLARE @x XML

SELECT @x = 
( SELECT 
     [CertificateNumber]
    ,[DesignCode]
    ,[JewelType]
    ,[TotalWeight]
    ,[MetalWeight]
    ,[MetalColor]
    ,[StonePcs]
    ,[StoneWeight]
    ,[CStonePcs]
	,[CStoneWeight]
	,[TotalAmount]
    ,CAST( Replace(Replace([TransactionDetails_Xml], ''xmlns=""http://schemas.datacontract.org/2004/07/Connections"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""'', ''''), ''<?xml version=""1.0"" encoding=""UTF-8""?>'', '''') AS XML).query(''
            for $tran in //TransactionDetails
            return <TransactionDetails 
                MetalNetAmount=""{$tran/ItemDetails/MetalDetail/MetalNetAmount}""
                StoneType = ""{$tran/ItemDetails/StoneDetail/StoneType}""
                LabourCharges = ""{$tran/ItemDetails/LabourCharges}""
                StampingCharges = ""{$tran/ItemDetails/StampingCharges}""
                StoneNetAmount = ""{$tran/ItemDetails/StoneDetail/StoneNetAmount}""
                ColorStoneNetAmount  = ""{$tran/ItemDetails/ColorStoneDetail/ColorStoneNetAmount}""
                CertificateCharges = ""{$tran/ItemDetails/CertificateCharges}""
            />
    '') 
  FROM JewelTransactions WHERE Cast([JewelTransactionId] as varchar(1)) in (@Jeweltrans)
  FOR XML AUTO
) 

-- RESULTS
SELECT [CER.NO] = T.Item.value(''../@CertificateNumber'', ''varchar(20)''),
	   [DESIGN NO] = T.Item.value(''../@DesingCode'', ''varchar(20)''),
	   [TYPE] = T.Item.value(''../@JewelType'', ''varchar(20)''),
	   [GR.WT] = T.Item.value(''../@TotalWeight'', ''decimal(18,4)''),
	   [NT.WT] = T.Item.value(''../@MetalWeight'', ''decimal(18,4)''),
	   [G.AMT] = T.Item.value(''@MetalNetAmount'' , ''decimal(18,4)''),
	   [COLOR] = T.Item.value(''../@MetalColor'' , ''varchar(20)''),
	   [DIA.PCS] = T.Item.value(''../@StonePcs'', ''int''),
	   [DIA.WT] = T.Item.value(''../@StoneWeight'', ''decimal(18,4)''),
	   [DIA.TYPE] = T.Item.value(''@StoneType'', ''varchar(20)''),
	   [SIEV.SZ] = '''',	
	   [DIA PCS] = '''',
	   [DIA.WT] = '''',
	   [DIA.PR] = '''',
	   [C.PCS] = T.Item.value(''../@CStonePcs'', ''int''),       
	   [C.WT] = T.Item.value(''../@CStoneWeight'', ''decimal(18,4)''),
	   [STONE.VAL] = 
	    CASE T.Item.value(''../@StonePcs'', ''int'')
         WHEN 0 THEN T.Item.value(''@ColorStoneNetAmount'', ''decimal(18,4)'')
         ELSE T.Item.value(''@StoneNetAmount'', ''decimal(18,4)'')
		END,
	   [LABR] = T.Item.value(''@LabourCharges'', ''decimal(18,4)''),   
	   [CERT] = T.Item.value(''@CertificateCharges'', ''decimal(18,4)''),   
	   [STAMP] = T.Item.value(''@StampingCharges'', ''decimal(18,4)''), 
	   [AMT] = T.Item.value(''../@TotalAmount'', ''decimal(18,4)'')
FROM   @x.nodes(''//JewelTransactions/TransactionDetails'') AS T(Item)

END
' 
END

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_AddressCustomer]') AND parent_object_id = OBJECT_ID(N'[Customers]'))
ALTER TABLE [Customers]  WITH CHECK ADD  CONSTRAINT [FK_AddressCustomer] FOREIGN KEY([Address_AddressId])
REFERENCES [Addresses] ([AddressId])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_AddressCustomer]') AND parent_object_id = OBJECT_ID(N'[Customers]'))
ALTER TABLE [Customers] CHECK CONSTRAINT [FK_AddressCustomer]

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_PurchaseTransactionCostingRate]') AND parent_object_id = OBJECT_ID(N'[JewelTransactions]'))
ALTER TABLE [JewelTransactions]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseTransactionCostingRate] FOREIGN KEY([CostingDetail_CostingDetailId])
REFERENCES [CostingDetails] ([CostingDetailId])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_PurchaseTransactionCostingRate]') AND parent_object_id = OBJECT_ID(N'[JewelTransactions]'))
ALTER TABLE [JewelTransactions] CHECK CONSTRAINT [FK_PurchaseTransactionCostingRate]

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_AddressSupplier]') AND parent_object_id = OBJECT_ID(N'[Suppliers]'))
ALTER TABLE [Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_AddressSupplier] FOREIGN KEY([Address_AddressId])
REFERENCES [Addresses] ([AddressId])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_AddressSupplier]') AND parent_object_id = OBJECT_ID(N'[Suppliers]'))
ALTER TABLE [Suppliers] CHECK CONSTRAINT [FK_AddressSupplier]

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_AddressUser]') AND parent_object_id = OBJECT_ID(N'[Users]'))
ALTER TABLE [Users]  WITH CHECK ADD  CONSTRAINT [FK_AddressUser] FOREIGN KEY([Address_AddressId])
REFERENCES [Addresses] ([AddressId])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_AddressUser]') AND parent_object_id = OBJECT_ID(N'[Users]'))
ALTER TABLE [Users] CHECK CONSTRAINT [FK_AddressUser]

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_UserLoginInformation]') AND parent_object_id = OBJECT_ID(N'[Users]'))
ALTER TABLE [Users]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginInformation] FOREIGN KEY([LoginInformations_LoginId])
REFERENCES [LoginInformations] ([LoginId])

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[FK_UserLoginInformation]') AND parent_object_id = OBJECT_ID(N'[Users]'))
ALTER TABLE [Users] CHECK CONSTRAINT [FK_UserLoginInformation]



";


				var command = new SqlCommand(tablesqlText, conn);
				command.ExecuteNonQuery();
			}
		}
	}
}
