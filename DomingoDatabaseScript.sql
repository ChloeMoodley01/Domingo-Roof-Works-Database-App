USE [master]
GO
/****** Object:  Database [DomingoDatabase]    Script Date: 2025/01/19 23:15:05 ******/
CREATE DATABASE [DomingoDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DomingoDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DomingoDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DomingoDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DomingoDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DomingoDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DomingoDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DomingoDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DomingoDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DomingoDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DomingoDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DomingoDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [DomingoDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DomingoDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DomingoDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DomingoDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DomingoDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DomingoDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DomingoDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DomingoDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DomingoDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DomingoDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DomingoDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DomingoDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DomingoDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DomingoDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DomingoDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DomingoDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DomingoDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DomingoDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [DomingoDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [DomingoDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DomingoDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DomingoDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DomingoDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DomingoDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DomingoDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DomingoDatabase', N'ON'
GO
ALTER DATABASE [DomingoDatabase] SET QUERY_STORE = OFF
GO
USE [DomingoDatabase]
GO
/****** Object:  Table [dbo].[JobType]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobType](
	[JobTypeName] [varchar](30) NOT NULL,
	[DailyRate] [decimal](18, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[CustomerSurname] [varchar](50) NOT NULL,
	[CustomerAddress] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Job]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[JobCardNo] [int] NOT NULL,
	[NumOfDays] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobCardNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerJob]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerJob](
	[CustomerJobID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[JobCardNo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerJobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[MaterialsID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialsUsed] [varchar](250) NOT NULL,
	[JobTypeName] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaterialsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobMaterials]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobMaterials](
	[JobMaterialsID] [int] IDENTITY(1,1) NOT NULL,
	[JobCardNo] [int] NOT NULL,
	[MaterialsID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobMaterialsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractID] [int] IDENTITY(1,1) NOT NULL,
	[JobCardNo] [int] NOT NULL,
	[EmployeeID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Invoice]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Invoice] AS
SELECT Job.JobCardNo, Customer.CustomerName, Customer.CustomerSurname, Customer.CustomerAddress,
JobType.JobTypeName, Materials.MaterialsUsed, 
JobType.DailyRate, Job.NumOfDays,

(JobType.DailyRate * Job.NumOfDays) AS 'Subtotal',
(JobType.DailyRate * Job.NumOfDays)*0.14 AS 'Vat' ,
(((JobType.DailyRate * Job.NumOfDays)*0.14)+ (JobType.DailyRate * Job.NumOfDays)) AS 'Total'

FROM ((((( Materials
INNER JOIN JobMaterials ON Materials.MaterialsID = JobMaterials.MaterialsID)
INNER JOIN JobType ON Materials.JobTypeName = JobType.JobTypeName)
INNER JOIN Job ON Job.JobCardNo = JobMaterials.JobCardNo)
INNER JOIN CustomerJob ON CustomerJob.JobCardNo = Job.JobCardNo
INNER JOIN Customer ON Customer.CustomerID = CustomerJob.CustomerID)
INNER JOIN Contract ON Job.JobCardNo = Contract.JobCardNo)

GROUP BY Job.JobCardNo, Customer.CustomerName, Customer.CustomerSurname, Customer.CustomerAddress,
JobType.JobTypeName, Materials.MaterialsUsed, 
JobType.DailyRate, Job.NumOfDays
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [varchar](50) NOT NULL,
	[EmployeeName] [varchar](50) NOT NULL,
	[EmployeeSurname] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotation]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation](
	[QuoteID] [int] IDENTITY(1,1) NOT NULL,
	[JobTypeName] [varchar](30) NOT NULL,
	[CustomerID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD FOREIGN KEY([JobCardNo])
REFERENCES [dbo].[Job] ([JobCardNo])
GO
ALTER TABLE [dbo].[CustomerJob]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CustomerJob]  WITH CHECK ADD FOREIGN KEY([JobCardNo])
REFERENCES [dbo].[Job] ([JobCardNo])
GO
ALTER TABLE [dbo].[JobMaterials]  WITH CHECK ADD FOREIGN KEY([JobCardNo])
REFERENCES [dbo].[Job] ([JobCardNo])
GO
ALTER TABLE [dbo].[JobMaterials]  WITH CHECK ADD FOREIGN KEY([MaterialsID])
REFERENCES [dbo].[Materials] ([MaterialsID])
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD FOREIGN KEY([JobTypeName])
REFERENCES [dbo].[JobType] ([JobTypeName])
GO
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD FOREIGN KEY([JobTypeName])
REFERENCES [dbo].[JobType] ([JobTypeName])
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCustomer]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteCustomer]
(
	@CustomerID int = 0
)

AS
BEGIN
	BEGIN TRY
	BEGIN TRAN
		DELETE FROM Quotation
		WHERE CustomerID = @CustomerID

		DELETE FROM CustomerJob
		WHERE CustomerID = @CustomerID

		DELETE FROM Customer
		WHERE CustomerID = @CustomerID

	COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteEmployee]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteEmployee]
(
	@EmployeeID varChar (50) = ''
)

AS
BEGIN
	BEGIN TRY
	BEGIN TRAN
	
		DELETE FROM Contract
		WHERE EmployeeID = @EmployeeID
	
		DELETE FROM Employee
		WHERE EmployeeID = @EmployeeID

	COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	END CATCH
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteJob]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteJob]
(
	@JobCardNo int = 0
)

AS
BEGIN
	BEGIN TRY
	BEGIN TRAN

		DELETE FROM Contract
		WHERE JobCardNo = @JobCardNo

		DELETE FROM CustomerJob
		WHERE JobCardNo = @JobCardNo

		DELETE FROM JobMaterials
		WHERE JobCardNo = @JobCardNo

		DELETE FROM Job
		WHERE JobCardNo = @JobCardNo

	COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteMaterials]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteMaterials]
(
	@MaterialsID int = 0
)

AS
BEGIN
	
	BEGIN TRY
	BEGIN TRAN

		DELETE FROM JobMaterials
		WHERE MaterialsID = @MaterialsID

		DELETE FROM Materials
		WHERE MaterialsID = @MaterialsID
	
	COMMIT TRAN
	END TRY
	BEGIN CATCH
	ROLLBACK TRAN
	END CATCH

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCustomer]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllCustomer]
AS
BEGIN
	SELECT * FROM Customer
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllEmployee]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllEmployee]
AS
BEGIN
	SELECT * FROM Employee
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllJob]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllJob]
AS
BEGIN
	SELECT * FROM Job
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllJobType]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllJobType]
AS
BEGIN
	SELECT * FROM JobType
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllMaterials]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetAllMaterials]
AS
BEGIN
	SELECT * FROM Materials
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetCustomerByID]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetCustomerByID]
(
	@CustomerID int = 0
)

AS

BEGIN

	SELECT * FROM Customer
	WHERE CustomerID = @CustomerID

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetEmployeeByID]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetEmployeeByID]
(
	@EmployeeID varChar (50) = ''
)

AS

BEGIN

	SELECT * FROM Employee
	WHERE EmployeeID = @EmployeeID

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetInvoice]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetInvoice]
AS
BEGIN
	SELECT * FROM Invoice
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetInvoiceByID]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetInvoiceByID]
(
	@JobCardNo int = 0
)

AS

BEGIN

	SELECT * FROM Invoice
	WHERE JobCardNo = @JobCardNo

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetJobByID]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetJobByID]
(
	@JobCardNo int = 0
)

AS

BEGIN

	SELECT * FROM Job
	WHERE JobCardNo = @JobCardNo

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetJobTypeByID]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetJobTypeByID]
(
	@JobTypeName varChar(30) = ''
)

AS

BEGIN

	SELECT * FROM JobType
	WHERE JobTypeName = @JobTypeName

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetMaterialsByID]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetMaterialsByID]
(
	@MaterialsID int = 0
)

AS

BEGIN

	SELECT * FROM Materials
	WHERE MaterialsID = @MaterialsID

END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertCustomer]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertCustomer]
(
	@CustomerName varChar(50) = '',
	@CustomerSurname varChar(50) = '',
	@CustomerAddress varChar (100) = ''
)

AS

BEGIN

	INSERT INTO Customer
	(CustomerName, CustomerSurname, CustomerAddress)
	VALUES
	(@CustomerName, @CustomerSurname, @CustomerAddress)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertEmployee]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertEmployee]
(
	@EmployeeID varChar (50) = '',
	@EmployeeName varChar(50) = '',
	@EmployeeSurname varChar(50) = ''
)

AS

BEGIN

	INSERT INTO Employee 
	(EmployeeID, EmployeeName, EmployeeSurname)
	VALUES
	(@EmployeeID, @EmployeeName, @EmployeeSurname)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertInvoice]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertInvoice]
(
	@CustomerID int = 0,
	@EmployeeID varChar (50) = '',
	@JobCardNo int = 0,
	@MaterialsID int = 0

)

AS
BEGIN

	INSERT INTO Contract
	(JobCardNo, EmployeeID)
	VALUES
	(@JobCardNo, @EmployeeID)

	INSERT INTO CustomerJob
	(CustomerID, JobCardNo)
	VALUES
	(@CustomerID, @JobCardNo)

	INSERT INTO JobMaterials
	(JobCardNo, MaterialsID)
	VALUES
	(@JobCardNo, @MaterialsID)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertJob]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertJob]
(	
	@JobCardNo int = 0,
	@NumOfDays int = 0
)

AS

BEGIN

	INSERT INTO Job
	(JobCardNo, NumOfDays)
	VALUES
	(@JobCardNo, @NumOfDays)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertMaterials]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_InsertMaterials]
(
	@MaterialsUsed varChar(250) = '',
	@JobTypeName varChar(30)  = ''

)

AS

BEGIN

	INSERT INTO Materials
	(MaterialsUsed, JobTypeName)
	VALUES 
	(@MaterialsUsed, @JobTypeName)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_JobCardEmployee]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_JobCardEmployee]
(
	@JobCardNo int = 0
)

AS
BEGIN

SELECT Contract.*, Employee.EmployeeName, Employee.EmployeeSurname 
FROM Contract
INNER JOIN Employee
ON Contract.EmployeeID = Employee.EmployeeID
WHERE Contract.JobCardNo = @JobCardNo
ORDER BY EmployeeName;

END

GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCustomer]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateCustomer]
(
	@CustomerID int = 0,
	@CustomerName varChar(50) = '',
	@CustomerSurname varChar(50) = '',
	@CustomerAddress varChar (100) = ''

)

AS
BEGIN
	UPDATE Customer
	SET
	CustomerName = @CustomerName, CustomerSurname = @CustomerSurname, CustomerAddress = @CustomerAddress
	WHERE CustomerID = @CustomerID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateEmployee]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateEmployee]
(
	@EmployeeID varChar (50) = '',
	@EmployeeName varChar(50) = '',
	@EmployeeSurname varChar(50) = ''

)

AS
BEGIN
	UPDATE Employee
	SET
	EmployeeName = @EmployeeName, EmployeeSurname = @EmployeeSurname
	WHERE EmployeeID = @EmployeeID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateJob]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateJob]
(
	@JobCardNo int = 0,
	@NumOfDays int = 0
)

AS
BEGIN
	UPDATE Job
	SET
	JobCardNo = @JobCardNo, NumOfDays = @NumOfDays
	WHERE JobCardNo = @JobCardNo
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateJobType]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--UPDATE

CREATE PROCEDURE [dbo].[SP_UpdateJobType]
(
	@JobTypeName varChar(30) = '',
	@DailyRate decimal = 0,
	@DailyRateString varChar(10) = ''

)

AS
BEGIN
	SET @DailyRate = CONVERT(decimal(10,2), @DailyRateString)

	UPDATE JobType
	 SET
	 DailyRate = @DailyRate
	 WHERE JobTypeName = @JobTypeName
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateMaterials]    Script Date: 2025/01/19 23:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateMaterials]
(
	@MaterialsID int = 0,
	@MaterialsUsed varChar(250) = '',
	@JobTypeName varChar(30) = ''
)

AS
BEGIN
	UPDATE Materials
	SET
	MaterialsUsed  = @MaterialsUsed, JobTypeName = @JobTypeName
	WHERE MaterialsID = @MaterialsID
END
GO
USE [master]
GO
ALTER DATABASE [DomingoDatabase] SET  READ_WRITE 
GO
