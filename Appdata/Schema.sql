/*
Navicat SQL Server Data Transfer

Source Server         : mssql2
Source Server Version : 130000
Source Host           : 192.168.1.4:1433
Source Database       : ite_Methodlogy_Blockchain
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 130000
File Encoding         : 65001

Date: 2019-08-25 12:43:58
*/


-- ----------------------------
-- Table structure for blockchain_edocument
-- ----------------------------
DROP TABLE [dbo].[blockchain_edocument]
GO
CREATE TABLE [dbo].[blockchain_edocument] (
[id] bigint NOT NULL IDENTITY(1,1) ,
[Index] varchar(500) NULL ,
[TimeStamp] datetime2(7) NULL ,
[PreviousHash] char(500) NULL ,
[Hash] char(500) NULL ,
[module] varchar(500) NULL ,
[identity] varchar(500) NULL ,
[Data] varchar(10) NULL ,
[description] varchar(10) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[blockchain_edocument]', RESEED, 17523)
GO

-- ----------------------------
-- Records of blockchain_edocument
-- ----------------------------
SET IDENTITY_INSERT [dbo].[blockchain_edocument] ON
GO
SET IDENTITY_INSERT [dbo].[blockchain_edocument] OFF
GO

-- ----------------------------
-- Table structure for t_documentFileTemp
-- ----------------------------
DROP TABLE [dbo].[t_documentFileTemp]
GO
CREATE TABLE [dbo].[t_documentFileTemp] (
[id] int NOT NULL IDENTITY(1,1) ,
[fileorg] text NULL ,
[filename] nvarchar(4000) NULL ,
[updatetime] datetime2(7) NULL ,
[status] varchar(255) NULL ,
[userid] varchar(500) NULL ,
[chanelupload] varchar(255) NULL ,
[subchanelupload] varchar(255) NULL ,
[checksum] text NULL ,
[remark4] varchar(255) NULL ,
[remark5] varchar(255) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[t_documentFileTemp]', RESEED, 29862)
GO

-- ----------------------------
-- Records of t_documentFileTemp
-- ----------------------------
SET IDENTITY_INSERT [dbo].[t_documentFileTemp] ON
GO
SET IDENTITY_INSERT [dbo].[t_documentFileTemp] OFF
GO

-- ----------------------------
-- Table structure for t_log_blockchain_performance
-- ----------------------------
DROP TABLE [dbo].[t_log_blockchain_performance]
GO
CREATE TABLE [dbo].[t_log_blockchain_performance] (
[id] bigint NOT NULL IDENTITY(1,1) ,
[case] varchar(255) NULL ,
[channel] varchar(255) NULL ,
[start_date] datetime2(7) NULL ,
[end_date] datetime2(7) NULL ,
[log_date] datetime2(7) NULL ,
[size] float(53) NULL ,
[avg_time] varchar(10) NULL ,
[blockchain_start_date] datetime2(7) NULL ,
[blockchain_end_date] datetime2(7) NULL ,
[blockchain_avg_time] varchar(10) NULL ,
[Filename] varchar(255) NULL ,
[filesize] varchar(255) NULL ,
[encode_size] varchar(255) NULL ,
[encode_identity] varchar(255) NULL ,
[hash_size] varchar(255) NULL ,
[ex_case] text NULL ,
[remark3] varchar(255) NULL ,
[remark4] varchar(255) NULL ,
[remark5] varchar(255) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[t_log_blockchain_performance]', RESEED, 29805)
GO

-- ----------------------------
-- Records of t_log_blockchain_performance
-- ----------------------------
SET IDENTITY_INSERT [dbo].[t_log_blockchain_performance] ON
GO
SET IDENTITY_INSERT [dbo].[t_log_blockchain_performance] OFF
GO

-- ----------------------------
-- Table structure for t_log_performance
-- ----------------------------
DROP TABLE [dbo].[t_log_performance]
GO
CREATE TABLE [dbo].[t_log_performance] (
[id] bigint NOT NULL IDENTITY(1,1) ,
[case] varchar(255) NULL ,
[channel] varchar(255) NULL ,
[start_date] datetime2(7) NULL ,
[end_date] datetime2(7) NULL ,
[log_date] datetime2(7) NULL ,
[size] float(53) NULL ,
[avg_time] varchar(10) NULL ,
[ex_case] text NULL ,
[remark3] varchar(255) NULL ,
[remark4] varchar(255) NULL ,
[remark5] varchar(255) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[t_log_performance]', RESEED, 29850)
GO

-- ----------------------------
-- Records of t_log_performance
-- ----------------------------
SET IDENTITY_INSERT [dbo].[t_log_performance] ON
GO
SET IDENTITY_INSERT [dbo].[t_log_performance] OFF
GO

-- ----------------------------
-- Procedure structure for Clear_data_all_test
-- ----------------------------
DROP PROCEDURE [dbo].[Clear_data_all_test]
GO

CREATE PROCEDURE [dbo].[Clear_data_all_test]
AS
TRUNCATE TABLE	blockchain_edocument;
TRUNCATE TABLE	t_documentFileTemp;
TRUNCATE TABLE	t_log_blockchain_performance;
TRUNCATE TABLE	t_log_performance;


GO

-- ----------------------------
-- Indexes structure for table blockchain_edocument
-- ----------------------------
CREATE INDEX [idx1] ON [dbo].[blockchain_edocument]
([Index] ASC, [module] ASC, [PreviousHash] ASC, [Hash] ASC) 
GO

-- ----------------------------
-- Primary Key structure for table blockchain_edocument
-- ----------------------------
ALTER TABLE [dbo].[blockchain_edocument] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table t_documentFileTemp
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table t_documentFileTemp
-- ----------------------------
ALTER TABLE [dbo].[t_documentFileTemp] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table t_log_blockchain_performance
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table t_log_blockchain_performance
-- ----------------------------
ALTER TABLE [dbo].[t_log_blockchain_performance] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table t_log_performance
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table t_log_performance
-- ----------------------------
ALTER TABLE [dbo].[t_log_performance] ADD PRIMARY KEY ([id])
GO
