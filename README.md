# CCAN_Witel_Karawang
aplikasi web internal ccan witel karawang untuk datek

## NuGet package yang dibutuhkan
- PagedList.Mvc
- FontAwesome-ASP.NET

## Persiapan Database
1. Di menu visual studio pilih **View > SQL Server Object Explorer**
1. di **SQL Server Object Explorer**, jika belum ada server buat terlebih dahulu. Jika sudah pindah ke server yang dipilih misalnya **(localdb)\ProjectsV13**
1. Buat Database baru, misalnya **dbccan**
1. Buat lalu Eksekusi SQL berikut
  * Sesuaikan script dibawah sesuai dengan format yang dikehendaki
```
USE [dbccan]
GO
CREATE TABLE [dbo].[LOOKUPRole](
  [LOOKUPRoleID] [int] IDENTITY(1,1) NOT NULL,
  [RoleName] [varchar](100) DEFAULT '',
  [RoleDescription] [varchar](500) DEFAULT '',
  [RowCreatedSYSUserID] [int] NOT NULL,
  [RowCreatedDateTime] [datetime] DEFAULT GETDATE(),
  [RowModifiedSYSUserID] [int] NOT NULL,
  [RowModifiedDateTime] [datetime] DEFAULT GETDATE(),
  PRIMARY KEY (LOOKUPRoleID)
)
GO

CREATE TABLE [dbo].[SYSUser](
  [SYSUserID] [int] IDENTITY(1,1) NOT NULL,
  [NIK] [varchar](50) NOT NULL,
  [PasswordEncryptedText] [varchar](200) NOT NULL,
  [RowCreatedSYSUserID] [int] NOT NULL,
  [RowCreatedDateTime] [datetime] DEFAULT GETDATE(),
  [RowModifiedSYSUserID] [int] NOT NULL,
  [RowModifiedDateTime] [datetime] DEFAULT GETDATE(),
  PRIMARY KEY (SYSUserID)
)
GO

CREATE TABLE [dbo].[SYSUserProfile](
  [SYSUserProfileID] [int] IDENTITY(1,1) NOT NULL,
  [SYSUserID] [int] NOT NULL,
  [Name]                 VARCHAR (50) NOT NULL,
  [NIK]                  VARCHAR (50) NOT NULL,
  [Gender]               CHAR (1)     NOT NULL,
  [Division]             VARCHAR (50) NOT NULL,
  [Phone]                VARCHAR (50) NOT NULL,
  [RowCreatedSYSUserID] [int] NOT NULL,
  [RowCreatedDateTime] [datetime] DEFAULT GETDATE(),
  [RowModifiedSYSUserID] [int] NOT NULL,
  [RowModifiedDateTime] [datetime] DEFAULT GETDATE(),
  PRIMARY KEY (SYSUserProfileID)
)
GO
ALTER TABLE [dbo].[SYSUserProfile] WITH CHECK ADD FOREIGN KEY([SYSUserID])
REFERENCES [dbo].[SYSUser] ([SYSUserID])
GO

CREATE TABLE [dbo].[SYSUserRole](
  [SYSUserRoleID] [int] IDENTITY(1,1) NOT NULL,
  [SYSUserID] [int] NOT NULL,
  [LOOKUPRoleID] [int] NOT NULL,
  [IsActive] [bit] DEFAULT (1),
  [RowCreatedSYSUserID] [int] NOT NULL,
  [RowCreatedDateTime] [datetime] DEFAULT GETDATE(),
  [RowModifiedSYSUserID] [int] NOT NULL,
  [RowModifiedDateTime] [datetime] DEFAULT GETDATE(),
  PRIMARY KEY (SYSUserRoleID)
)
GO
ALTER TABLE [dbo].[SYSUserRole] WITH CHECK ADD FOREIGN KEY([LOOKUPRoleID])
REFERENCES [dbo].[LOOKUPRole] ([LOOKUPRoleID])
GO
ALTER TABLE [dbo].[SYSUserRole] WITH CHECK ADD FOREIGN KEY([SYSUserID])
REFER

CREATE TABLE [dbo].[TechInfo](
  [TechInfoID]    INT          IDENTITY (1, 1) NOT NULL,
  [SID]           VARCHAR (50) NOT NULL,
  [TQ]            VARCHAR (50) NOT NULL,
  [AO]            VARCHAR (50) NOT NULL,
  [Name]          TEXT         NOT NULL,
  [OrderTime]     DATE         NULL,
  [Address]       TEXT         DEFAULT ('-') NULL,
  [TeNOSScomment] TEXT         DEFAULT ('-') NULL,
  [PIC]           VARCHAR (50) DEFAULT ('-') NULL,
  [AreaCode]      VARCHAR (50) DEFAULT ('-') NULL,
  [Metro]         VARCHAR (50) DEFAULT ('-') NULL,
  [GPON]          VARCHAR (50) DEFAULT ('-') NULL,
  [SN]            VARCHAR (50) DEFAULT ('-') NULL,
  [VLAN]          VARCHAR (50) DEFAULT ('-') NULL,
  [SurveyTime]    DATE         NULL,
  [CustTag]       VARCHAR (50) DEFAULT ('-') NULL,
  [SurveyTech]    VARCHAR (50) DEFAULT ('-') NULL,
  [ODPTag]        VARCHAR (50) DEFAULT ('-') NULL,
  [PT1Com]        DATE         NULL,
  [PT1End]        DATE         NULL,
  [PT1Tech]       VARCHAR (50) DEFAULT ('-') NULL,
  [JTTime]        DATE         NULL,
  [JTEnd]         DATE         NULL,
  [comment]       TEXT         DEFAULT ('-') NULL,
  [ClosedTime]    DATE         NULL,
  [status]        VARCHAR (50) DEFAULT ('-') NULL,
  PRIMARY KEY CLUSTERED ([TechInfoID] ASC)
)
GO
```
## Menghubungkan Aplikasi Web dengan Database menggunakan Entity Data Model
1. Buat Folder baru dengan nama **DB** di direktori **./Models/** kemudian klik kanan di **./Models/DB/** lalu pilih **Add > New Item**
1. **Visual C# > Data > ADO.NET Entity Data Model**, isikan dengan nama **dbccan** (disarankan penamaan sama) kemudian pilih add
1. Pilih **EF Designer from database** lalu Next, Pilih **New Connection...**
1. Isikan Server name sesuai dengan server dimana database berada, pada contoh sebelumnya di **Persiapan Database** Server name-nya adalah **(localdb)\ProjectsV13**
1. Di tab Connect to database yaitu Select or enter a database name isikan dengan nama database-nya, dalam hal ini yang dibuat sebelumnya yaitu **dbccan** lalu ok
1. Pastikan nama entities yang disimpan di Web.Config adalah **dbccanEntities**
1. Klik Next hingga Finish
