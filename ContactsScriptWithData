USE [master]
GO
/****** Object:  Database [Contacts]    Script Date: 5/31/2023 8:42:44 PM ******/
CREATE DATABASE [Contacts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Contacts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Contacts.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Contacts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Contacts_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Contacts] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Contacts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Contacts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Contacts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Contacts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Contacts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Contacts] SET ARITHABORT OFF 
GO
ALTER DATABASE [Contacts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Contacts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Contacts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Contacts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Contacts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Contacts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Contacts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Contacts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Contacts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Contacts] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Contacts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Contacts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Contacts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Contacts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Contacts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Contacts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Contacts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Contacts] SET RECOVERY FULL 
GO
ALTER DATABASE [Contacts] SET  MULTI_USER 
GO
ALTER DATABASE [Contacts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Contacts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Contacts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Contacts] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Contacts] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Contacts] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Contacts', N'ON'
GO
ALTER DATABASE [Contacts] SET QUERY_STORE = OFF
GO
USE [Contacts]
GO
/****** Object:  Table [dbo].[ContactsDetails]    Script Date: 5/31/2023 8:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactsDetails](
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](15) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[ContactsDetails] ([LastName], [FirstName], [PhoneNumber]) VALUES (N'Bo', N'Dee', N'0580000222')
INSERT [dbo].[ContactsDetails] ([LastName], [FirstName], [PhoneNumber]) VALUES (N'Choen', N'Sheli', N'0533442440')
INSERT [dbo].[ContactsDetails] ([LastName], [FirstName], [PhoneNumber]) VALUES (N'Lord', N'Yehuda', N'0504109999')
INSERT [dbo].[ContactsDetails] ([LastName], [FirstName], [PhoneNumber]) VALUES (N'Segal', N'Shila', N'0586721234')
INSERT [dbo].[ContactsDetails] ([LastName], [FirstName], [PhoneNumber]) VALUES (N'Dev', N'Mat', N'0548478009')
INSERT [dbo].[ContactsDetails] ([LastName], [FirstName], [PhoneNumber]) VALUES (N'Tadir', N'Leahle', N'0773332105')
INSERT [dbo].[ContactsDetails] ([LastName], [FirstName], [PhoneNumber]) VALUES (N'Choen', N'Jakov', N'0550022178')
INSERT [dbo].[ContactsDetails] ([LastName], [FirstName], [PhoneNumber]) VALUES (N'Sardini', N'Tamari', N'0506963340')
GO
/****** Object:  StoredProcedure [dbo].[AddContact]    Script Date: 5/31/2023 8:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddContact]
@lastName nvarchar(30),
@firstName nvarchar(25),
@phoneNumber nvarchar(15)
as
begin
	insert into ContactsDetails
	values(@lastName, @firstName, @phoneNumber)
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteContact]    Script Date: 5/31/2023 8:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteContact]
@lastName nvarchar(30),
@firstName nvarchar(25)
as
begin
	delete from ContactsDetails
	where LastName = @lastName and FirstName = @firstName
end
GO
/****** Object:  StoredProcedure [dbo].[SearchContactByName]    Script Date: 5/31/2023 8:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SearchContactByName]
@name nvarchar(60)
as
begin
	select LastName+' ' +FirstName as FullName, PhoneNumber 
	from ContactsDetails
	where LastName like @name+'%' or FirstName like @name+'%' 
	order by FullName asc
end

GO
/****** Object:  StoredProcedure [dbo].[SelectContactsList]    Script Date: 5/31/2023 8:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectContactsList]
as
	begin
	select LastName+' ' +FirstName as FullName,PhoneNumber 
	from ContactsDetails
	order by FullName asc
end
GO
/****** Object:  StoredProcedure [dbo].[UpdatePhoneNumber]    Script Date: 5/31/2023 8:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdatePhoneNumber]
@lastName nvarchar(30),
@firstName nvarchar(25),
@phoneNumber nvarchar(15)
as
begin
	update ContactsDetails
	set PhoneNumber = @phoneNumber
	where FirstName = @firstName and LastName = @lastName
end
GO
USE [master]
GO
ALTER DATABASE [Contacts] SET  READ_WRITE 
GO
