USE [master]
GO
/****** Object:  Database [db_Elearning]    Script Date: 7/17/2021 9:54:55 PM ******/
CREATE DATABASE [db_Elearning]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_Elearning', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_Elearning.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_Elearning_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_Elearning_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_Elearning] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_Elearning].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_Elearning] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_Elearning] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_Elearning] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_Elearning] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_Elearning] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_Elearning] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_Elearning] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_Elearning] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_Elearning] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_Elearning] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_Elearning] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_Elearning] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_Elearning] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_Elearning] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_Elearning] SET  ENABLE_BROKER 
GO
ALTER DATABASE [db_Elearning] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_Elearning] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_Elearning] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_Elearning] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_Elearning] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_Elearning] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_Elearning] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_Elearning] SET RECOVERY FULL 
GO
ALTER DATABASE [db_Elearning] SET  MULTI_USER 
GO
ALTER DATABASE [db_Elearning] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_Elearning] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_Elearning] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_Elearning] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_Elearning] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_Elearning', N'ON'
GO
ALTER DATABASE [db_Elearning] SET QUERY_STORE = OFF
GO
USE [db_Elearning]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DayCreate] [datetime] NULL,
	[Username] [varchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[FullName] [nvarchar](100) NULL,
	[Img] [nvarchar](200) NULL,
	[BrithDay] [nvarchar](15) NULL,
	[Gender] [nvarchar](5) NULL,
	[Email] [nvarchar](100) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Role] [nvarchar](100) NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Announcement]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DayCreate] [datetime] NULL,
	[UserRecive] [varchar](100) NULL,
	[DayUpload] [datetime] NULL,
	[Header] [nvarchar](100) NULL,
	[Content] [nvarchar](max) NULL,
	[UserSend] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeAnswer] [varchar](100) NULL,
	[CharOrder] [nvarchar](10) NULL,
	[ContentQ] [nvarchar](max) NULL,
	[Img] [nvarchar](200) NULL,
	[ChoseTime] [datetime] NULL,
	[CodeQuestion] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignmentStudent]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignmentStudent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeContentLec] [int] NULL,
	[LastUpdate] [datetime] NULL,
	[point] [float] NULL,
	[TeacherGive] [int] NULL,
	[TimeGivePoint] [datetime] NULL,
	[StudentOwns] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassCourse]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassCourse](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeClass] [varchar](100) NULL,
	[nameClass] [nvarchar](200) NULL,
	[CodeCourse] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassCourse_Student]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassCourse_Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userStudent] [int] NULL,
	[CodeClass] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassCourse_Teacher]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassCourse_Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userTeacher] [int] NULL,
	[CodeClass] [int] NULL,
	[State] [smallint] NULL,
 CONSTRAINT [PK__ClassCou__3213E83FB0D7BAEF] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Self] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[TimeComment] [datetime] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentLec]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentLec](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeContentLec] [varchar](100) NULL,
	[dayCreate] [datetime] NULL,
	[header] [nvarchar](200) NULL,
	[decription] [nvarchar](200) NULL,
	[DayOpen] [datetime] NULL,
	[DayClose] [datetime] NULL,
	[TypeContentLec] [smallint] NULL,
	[DayExpire] [datetime] NULL,
	[Content] [nvarchar](max) NULL,
	[TimeStart] [datetime] NULL,
	[Duration] [int] NULL,
	[CodeLecture] [int] NULL,
	[Self] [int] NULL,
	[State] [smallint] NULL,
 CONSTRAINT [PK__ContentL__3213E83F59278113] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentLecComment]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentLecComment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeContentLec] [int] NULL,
	[idComment] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeCourse] [varchar](100) NULL,
	[NameCourse] [nvarchar](200) NULL,
	[State] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamStudent]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamStudent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeContentLec] [int] NULL,
	[DurationDo] [float] NULL,
	[point] [float] NULL,
	[TeacherGive] [int] NULL,
	[TimeGivePoint] [datetime] NULL,
	[StudentOwns] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[File]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[File](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeFile] [varchar](100) NULL,
	[NameFile] [nvarchar](200) NULL,
	[Link] [nvarchar](200) NULL,
	[PathSave] [nvarchar](200) NULL,
	[Size] [float] NULL,
	[Self] [int] NULL,
	[DayUpload] [datetime] NULL,
	[typeFile] [varchar](100) NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileAssignment]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileAssignment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeFile] [int] NULL,
	[CodeAssignmentStudent] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lecture]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecture](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeLecture] [varchar](100) NULL,
	[Header] [nvarchar](200) NULL,
	[Decription] [nvarchar](200) NULL,
	[idCourse] [int] NULL,
	[Self] [int] NULL,
	[State] [smallint] NULL,
 CONSTRAINT [PK__Lecture__3213E83F1D0FF036] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LectureClass]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LectureClass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeLecture] [int] NULL,
	[CodeClass] [int] NULL,
	[DayAdd] [datetime] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LectureStudent]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LectureStudent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeLecture] [int] NULL,
	[CodeStudent] [int] NULL,
	[isComplete] [bit] NULL,
	[PercentComplete] [float] NULL,
	[DayComplete] [datetime] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeQuestion] [varchar](100) NULL,
	[NumOrder] [nvarchar](15) NULL,
	[Header] [nvarchar](200) NULL,
	[Content] [nvarchar](max) NULL,
	[imgs] [nvarchar](max) NULL,
	[TypeQuest] [smallint] NULL,
	[idContentLec] [int] NULL,
	[CorrectAnswer] [varchar](100) NULL,
	[State] [smallint] NULL,
 CONSTRAINT [PK__Question__3213E83F70A1896C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionMatching]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionMatching](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeQuestion] [int] NULL,
	[CodeAnswer1] [int] NULL,
	[CodeAnswer2] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionMCQ]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionMCQ](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeQuestion] [int] NULL,
	[CodeAnswer] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionTF]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionTF](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeQuestion] [int] NULL,
	[CodeAnswer] [int] NULL,
	[CorrectAnswer] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeTopic] [varchar](100) NULL,
	[header] [nvarchar](200) NULL,
	[decription] [nvarchar](200) NULL,
	[dayCreate] [datetime] NULL,
	[Self] [int] NULL,
	[CodeContentLec] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TopicComment]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopicComment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeTopic] [int] NULL,
	[idComment] [int] NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeFile]    Script Date: 7/17/2021 9:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeFile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CodeType] [varchar](100) NULL,
	[NameType] [nvarchar](200) NULL,
	[Img] [nvarchar](200) NULL,
	[State] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (1, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715001', N'1715001', N'Cao Hữu Sáng', N'logo.png', N'1999/8/31', N'Nam', N'1715001@mta.edu.com.vn', N'094636184', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (2, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715002', N'1715002', N'Phạm Ngọc Bích', N'logo.png', N'1999/1/14', N'Nữ', N'1715002@mta.edu.com.vn', N'094663179', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (3, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715003', N'1715003', N'Quách Vinh Hà', N'logo.png', N'1999/9/23', N'Nam', N'1715003@mta.edu.com.vn', N'094658374', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (4, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715004', N'1715004', N'Phan Cao Hiếu', N'logo.png', N'1999/6/20', N'Nam', N'1715004@mta.edu.com.vn', N'094795095', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (5, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715005', N'1715005', N'Cao Diệu Nhung', N'logo.png', N'1999/10/6', N'Nữ', N'1715005@mta.edu.com.vn', N'094225073', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (6, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715006', N'1715006', N'Phạm Thu Giang', N'logo.png', N'1999/11/9', N'Nữ', N'1715006@mta.edu.com.vn', N'094713493', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (7, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715007', N'1715007', N'Trương Hoàng Thuý', N'logo.png', N'1999/3/12', N'Nữ', N'1715007@mta.edu.com.vn', N'094873797', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (8, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715008', N'1715008', N'Bùi Cao Minh', N'logo.png', N'1999/2/23', N'Nam', N'1715008@mta.edu.com.vn', N'094152510', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (9, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715009', N'1715009', N'Ngô Cao Tuấn', N'logo.png', N'1999/2/22', N'Nam', N'1715009@mta.edu.com.vn', N'094956787', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (10, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715010', N'1715010', N'Nguyễn Tiểu Đức', N'logo.png', N'1999/9/22', N'Nam', N'1715010@mta.edu.com.vn', N'094349937', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (11, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715011', N'1715011', N'Chu Lê Diễm', N'logo.png', N'1999/11/22', N'Nữ', N'1715011@mta.edu.com.vn', N'094793095', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (12, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715012', N'1715012', N'Phùng Ngọc Linh', N'logo.png', N'1999/3/27', N'Nữ', N'1715012@mta.edu.com.vn', N'094583507', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (13, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715013', N'1715013', N'Đàm Thái Dung', N'logo.png', N'1999/1/13', N'Nữ', N'1715013@mta.edu.com.vn', N'094272378', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (14, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715014', N'1715014', N'Đoàn Trần Phú', N'logo.png', N'1999/10/11', N'Nam', N'1715014@mta.edu.com.vn', N'094373812', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (15, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715015', N'1715015', N'Chu Bá Hiệp', N'logo.png', N'1999/4/15', N'Nam', N'1715015@mta.edu.com.vn', N'094748961', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (16, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715016', N'1715016', N'Chu Bá Chí', N'logo.png', N'1999/9/8', N'Nam', N'1715016@mta.edu.com.vn', N'094721624', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (17, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715017', N'1715017', N'Hoàng Hoàng Thành', N'logo.png', N'1999/6/21', N'Nam', N'1715017@mta.edu.com.vn', N'094783106', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (18, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715018', N'1715018', N'Tôn Thanh Chí', N'logo.png', N'1999/10/5', N'Nam', N'1715018@mta.edu.com.vn', N'094310103', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (19, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715019', N'1715019', N'Quách Đăng Sáng', N'logo.png', N'1999/2/1', N'Nam', N'1715019@mta.edu.com.vn', N'094194793', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (20, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715020', N'1715020', N'Ngô Tuấn Hải', N'logo.png', N'1999/12/6', N'Nam', N'1715020@mta.edu.com.vn', N'094920178', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (21, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715021', N'1715021', N'Đinh Thu Trang', N'logo.png', N'1999/11/11', N'Nữ', N'1715021@mta.edu.com.vn', N'094611779', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (22, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715022', N'1715022', N'Tăng Hải Ý', N'logo.png', N'1999/12/22', N'Nữ', N'1715022@mta.edu.com.vn', N'094109571', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (23, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715023', N'1715023', N'Vũ Âu Công', N'logo.png', N'1999/5/19', N'Nam', N'1715023@mta.edu.com.vn', N'094567485', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (24, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715024', N'1715024', N'Bùi Ngọc Nguyệt', N'logo.png', N'1999/7/3', N'Nữ', N'1715024@mta.edu.com.vn', N'094327323', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (25, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715025', N'1715025', N'Trương Diệu Diễm', N'logo.png', N'1999/3/18', N'Nữ', N'1715025@mta.edu.com.vn', N'094136877', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (26, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715026', N'1715026', N'Dương Kiến Hữu', N'logo.png', N'1999/10/15', N'Nam', N'1715026@mta.edu.com.vn', N'094330032', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (27, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715027', N'1715027', N'Cao Trương Đức', N'logo.png', N'1999/2/23', N'Nam', N'1715027@mta.edu.com.vn', N'094713813', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (28, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715028', N'1715028', N'Đinh Bình Lan', N'logo.png', N'1999/8/2', N'Nữ', N'1715028@mta.edu.com.vn', N'094780232', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (29, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715029', N'1715029', N'Ngô Hoàng Thanh Hoa', N'logo.png', N'1999/1/16', N'Nữ', N'1715029@mta.edu.com.vn', N'094530811', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (30, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715030', N'1715030', N'Văn Cẩm Nguyệt', N'logo.png', N'1999/4/12', N'Nữ', N'1715030@mta.edu.com.vn', N'094289042', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (31, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715031', N'1715031', N'Hồ Lê Ba', N'logo.png', N'1999/11/5', N'Nữ', N'1715031@mta.edu.com.vn', N'094287643', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (32, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715032', N'1715032', N'Bùi Mạnh Nhật', N'logo.png', N'1999/2/13', N'Nam', N'1715032@mta.edu.com.vn', N'094876906', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (33, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715033', N'1715033', N'Hồ Bình Ngọc', N'logo.png', N'1999/6/13', N'Nữ', N'1715033@mta.edu.com.vn', N'094868279', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (34, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715034', N'1715034', N'Đoàn Cẩm Mai', N'logo.png', N'1999/4/20', N'Nữ', N'1715034@mta.edu.com.vn', N'094292292', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (35, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715035', N'1715035', N'Vũ Vinh Quý', N'logo.png', N'1999/2/9', N'Nam', N'1715035@mta.edu.com.vn', N'094501279', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (36, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715036', N'1715036', N'Cao Quế Tùng', N'logo.png', N'1999/10/30', N'Nam', N'1715036@mta.edu.com.vn', N'094136251', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (37, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715037', N'1715037', N'Cao Tú Mai', N'logo.png', N'1999/12/9', N'Nữ', N'1715037@mta.edu.com.vn', N'094289166', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (38, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715038', N'1715038', N'Dương Hồng Tám', N'logo.png', N'1999/7/10', N'Nữ', N'1715038@mta.edu.com.vn', N'094728725', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (39, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715039', N'1715039', N'Trần Diệu Lê', N'logo.png', N'1999/2/25', N'Nữ', N'1715039@mta.edu.com.vn', N'094636690', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (40, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715040', N'1715040', N'Đàm Vũ Lâm', N'logo.png', N'1999/9/15', N'Nam', N'1715040@mta.edu.com.vn', N'094873330', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (41, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715041', N'1715041', N'Chu Xuân Loan', N'logo.png', N'1999/12/24', N'Nữ', N'1715041@mta.edu.com.vn', N'094633192', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (42, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715042', N'1715042', N'Lương Cao Kỳ Thanh', N'logo.png', N'1999/5/27', N'Nữ', N'1715042@mta.edu.com.vn', N'094570697', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (43, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715043', N'1715043', N'Trương Thanh Hoàng', N'logo.png', N'1999/4/12', N'Nam', N'1715043@mta.edu.com.vn', N'094112753', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (44, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715044', N'1715044', N'Cao Tôn Minh', N'logo.png', N'1999/5/25', N'Nam', N'1715044@mta.edu.com.vn', N'094470913', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (45, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715045', N'1715045', N'Hồ Hải Tư', N'logo.png', N'1999/5/25', N'Nữ', N'1715045@mta.edu.com.vn', N'094220314', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (46, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715046', N'1715046', N'Nhật Thương Hà', N'logo.png', N'1999/1/1', N'Nữ', N'1715046@mta.edu.com.vn', N'094146204', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (47, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715047', N'1715047', N'Tôn Tuấn Thư', N'logo.png', N'1999/8/4', N'Nam', N'1715047@mta.edu.com.vn', N'094492626', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (48, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715048', N'1715048', N'Trần Mạnh Tiến', N'logo.png', N'1999/5/12', N'Nam', N'1715048@mta.edu.com.vn', N'094578650', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (49, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715049', N'1715049', N'Ngô Hoàng Xuân Chi', N'logo.png', N'1999/11/8', N'Nữ', N'1715049@mta.edu.com.vn', N'094258906', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (50, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715050', N'1715050', N'Hồ Hoài Gấm', N'logo.png', N'1999/2/14', N'Nữ', N'1715050@mta.edu.com.vn', N'094212344', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (51, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715051', N'1715051', N'Phạm Cao Công', N'logo.png', N'1999/8/29', N'Nam', N'1715051@mta.edu.com.vn', N'094518790', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (52, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715052', N'1715052', N'Lương Như Hồng', N'logo.png', N'1999/4/8', N'Nữ', N'1715052@mta.edu.com.vn', N'094206860', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (53, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715053', N'1715053', N'Cao Thị Trân', N'logo.png', N'1999/11/26', N'Nữ', N'1715053@mta.edu.com.vn', N'094594488', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (54, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715054', N'1715054', N'Trương Quế Tùng', N'logo.png', N'1999/8/20', N'Nam', N'1715054@mta.edu.com.vn', N'094334131', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (55, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715055', N'1715055', N'Ngô Hoàng Xuân Linh', N'logo.png', N'1999/9/12', N'Nữ', N'1715055@mta.edu.com.vn', N'094728442', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (56, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715056', N'1715056', N'Bùi Hoàng Hương', N'logo.png', N'1999/10/22', N'Nữ', N'1715056@mta.edu.com.vn', N'094956048', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (57, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715057', N'1715057', N'Hồ Châu Hương', N'logo.png', N'1999/11/16', N'Nữ', N'1715057@mta.edu.com.vn', N'094942191', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (58, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715058', N'1715058', N'Trần Cẩm Mi', N'logo.png', N'1999/7/10', N'Nữ', N'1715058@mta.edu.com.vn', N'094638504', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (59, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715059', N'1715059', N'Hoàng Minh Hoài', N'logo.png', N'1999/5/22', N'Nữ', N'1715059@mta.edu.com.vn', N'094792318', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (60, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715060', N'1715060', N'Tăng Thương Thảo', N'logo.png', N'1999/5/15', N'Nữ', N'1715060@mta.edu.com.vn', N'094986791', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (61, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715061', N'1715061', N'Lê Tuấn Đoàn', N'logo.png', N'1999/6/5', N'Nam', N'1715061@mta.edu.com.vn', N'094803854', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (62, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715062', N'1715062', N'Quách Cao Tuấn', N'logo.png', N'1999/2/3', N'Nam', N'1715062@mta.edu.com.vn', N'094954369', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (63, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715063', N'1715063', N'Phùng  Đình Hà', N'logo.png', N'1999/5/10', N'Nam', N'1715063@mta.edu.com.vn', N'094173155', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (64, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715064', N'1715064', N'Hồ Cao Kỳ Chi', N'logo.png', N'1999/1/3', N'Nữ', N'1715064@mta.edu.com.vn', N'094684957', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (65, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715065', N'1715065', N'Tăng Thị Diễm', N'logo.png', N'1999/2/9', N'Nữ', N'1715065@mta.edu.com.vn', N'094384521', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (66, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715066', N'1715066', N'Lê Hoài Ba', N'logo.png', N'1999/7/23', N'Nữ', N'1715066@mta.edu.com.vn', N'094541322', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (67, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715067', N'1715067', N'Phùng Xuân Thuý', N'logo.png', N'1999/7/17', N'Nữ', N'1715067@mta.edu.com.vn', N'094977371', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (68, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715068', N'1715068', N'Tăng Lực Nhật', N'logo.png', N'1999/12/11', N'Nam', N'1715068@mta.edu.com.vn', N'094827976', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (69, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715069', N'1715069', N'Bùi Xuân Thanh', N'logo.png', N'1999/10/21', N'Nữ', N'1715069@mta.edu.com.vn', N'094964594', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (70, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715070', N'1715070', N'Ngô Hoàng Mỹ Linh', N'logo.png', N'1999/3/30', N'Nữ', N'1715070@mta.edu.com.vn', N'094288935', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (71, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715071', N'1715071', N'Cao Cẩm Mai', N'logo.png', N'1999/1/15', N'Nữ', N'1715071@mta.edu.com.vn', N'094299602', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (72, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715072', N'1715072', N'Chu Như Thuý', N'logo.png', N'1999/6/15', N'Nữ', N'1715072@mta.edu.com.vn', N'094797484', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (73, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715073', N'1715073', N'Tôn Tú Huyền', N'logo.png', N'1999/7/1', N'Nữ', N'1715073@mta.edu.com.vn', N'094151025', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (74, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715074', N'1715074', N'Tôn Tiểu Hiếu', N'logo.png', N'1999/9/26', N'Nam', N'1715074@mta.edu.com.vn', N'094150625', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (75, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715075', N'1715075', N'Trương Ngọc Huyền', N'logo.png', N'1999/6/3', N'Nữ', N'1715075@mta.edu.com.vn', N'094944292', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (76, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715076', N'1715076', N'Đàm Minh Phú', N'logo.png', N'1999/7/16', N'Nam', N'1715076@mta.edu.com.vn', N'094825483', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (77, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715077', N'1715077', N'Dương Trương Tiến', N'logo.png', N'1999/12/27', N'Nam', N'1715077@mta.edu.com.vn', N'094437598', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (78, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715078', N'1715078', N'Tôn Thương Tám', N'logo.png', N'1999/3/28', N'Nữ', N'1715078@mta.edu.com.vn', N'094338259', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (79, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715079', N'1715079', N'Tôn Thất Hải', N'logo.png', N'1999/4/18', N'Nam', N'1715079@mta.edu.com.vn', N'094957047', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (80, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715080', N'1715080', N'Nhật Đức Thành', N'logo.png', N'1999/12/23', N'Nam', N'1715080@mta.edu.com.vn', N'094623136', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (81, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715081', N'1715081', N'Lê Tú Thuý', N'logo.png', N'1999/10/15', N'Nữ', N'1715081@mta.edu.com.vn', N'094937497', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (82, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715082', N'1715082', N'Đoàn Khánh Quyên', N'logo.png', N'1999/1/13', N'Nữ', N'1715082@mta.edu.com.vn', N'094871054', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (83, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715083', N'1715083', N'Hồ Hồng Tư', N'logo.png', N'1999/10/18', N'Nữ', N'1715083@mta.edu.com.vn', N'094969476', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (84, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715084', N'1715084', N'Ngô Hoàng Bá Phú', N'logo.png', N'1999/5/9', N'Nam', N'1715084@mta.edu.com.vn', N'094330339', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (85, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715085', N'1715085', N'Hoàng Hoàng Đoàn', N'logo.png', N'1999/1/5', N'Nam', N'1715085@mta.edu.com.vn', N'094955032', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (86, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715086', N'1715086', N'Đàm  Đình Văn', N'logo.png', N'1999/1/25', N'Nam', N'1715086@mta.edu.com.vn', N'094322954', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (87, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715087', N'1715087', N'Nhật Ngọc Hương', N'logo.png', N'1999/6/7', N'Nữ', N'1715087@mta.edu.com.vn', N'094530057', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (88, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715088', N'1715088', N'Ngô Hoàng Hải Vân', N'logo.png', N'1999/8/26', N'Nữ', N'1715088@mta.edu.com.vn', N'094453436', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (89, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715089', N'1715089', N'Phạm Bình Anh', N'logo.png', N'1999/4/17', N'Nữ', N'1715089@mta.edu.com.vn', N'094467667', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (90, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715090', N'1715090', N'Đinh Thị Yến', N'logo.png', N'1999/8/17', N'Nữ', N'1715090@mta.edu.com.vn', N'094131280', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (91, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715091', N'1715091', N'Hoàng Thương Nga', N'logo.png', N'1999/5/10', N'Nữ', N'1715091@mta.edu.com.vn', N'094395772', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (92, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715092', N'1715092', N'Phùng Minh Hương', N'logo.png', N'1999/5/17', N'Nữ', N'1715092@mta.edu.com.vn', N'094514912', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (93, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715093', N'1715093', N'Trần Mỹ Hồng', N'logo.png', N'1999/7/16', N'Nữ', N'1715093@mta.edu.com.vn', N'094422133', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (94, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715094', N'1715094', N'Chu Hoài Lan', N'logo.png', N'1999/3/19', N'Nữ', N'1715094@mta.edu.com.vn', N'094223072', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (95, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715095', N'1715095', N'Ngô Hoàng Minh Lam', N'logo.png', N'1999/1/12', N'Nữ', N'1715095@mta.edu.com.vn', N'094992125', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (96, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715096', N'1715096', N'Lê Minh Mai', N'logo.png', N'1999/8/4', N'Nữ', N'1715096@mta.edu.com.vn', N'094547399', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (97, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715097', N'1715097', N'Trần Hải Lê', N'logo.png', N'1999/2/2', N'Nữ', N'1715097@mta.edu.com.vn', N'094745952', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (98, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715098', N'1715098', N'Hoàng Ngô Tôn Phú', N'logo.png', N'1999/12/8', N'Nam', N'1715098@mta.edu.com.vn', N'094887854', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (99, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715099', N'1715099', N'Hoàng Minh Chiều', N'logo.png', N'1999/1/7', N'Nam', N'1715099@mta.edu.com.vn', N'094162750', N'Student', 1)
GO
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (100, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1715100', N'1715100', N'Chu Cẩm Ngân', N'logo.png', N'1999/8/11', N'Nữ', N'1715100@mta.edu.com.vn', N'094781029', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (101, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615001', N'1615001', N'Cao Đăng Hoàng', N'logo.png', N'1998/11/12', N'Nam', N'1615001@mta.edu.com.vn', N'094518771', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (102, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615002', N'1615002', N'Hoàng Ngô Hoài Trân', N'logo.png', N'1998/12/7', N'Nữ', N'1615002@mta.edu.com.vn', N'034710395', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (103, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615003', N'1615003', N'Nguyễn Cao Cường', N'logo.png', N'1998/11/21', N'Nam', N'1615003@mta.edu.com.vn', N'034180895', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (104, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615004', N'1615004', N'Văn Lý Hiếu', N'logo.png', N'1998/2/9', N'Nam', N'1615004@mta.edu.com.vn', N'034571199', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (105, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615005', N'1615005', N'Quách Kiến Lâm', N'logo.png', N'1998/3/15', N'Nam', N'1615005@mta.edu.com.vn', N'034976080', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (106, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615006', N'1615006', N'Dương Đức Hoàng', N'logo.png', N'1998/1/2', N'Nam', N'1615006@mta.edu.com.vn', N'034676928', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (107, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615007', N'1615007', N'Nhật Tú Hạnh', N'logo.png', N'1998/4/29', N'Nữ', N'1615007@mta.edu.com.vn', N'034269671', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (108, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615008', N'1615008', N'Dương Bình Bích', N'logo.png', N'1998/4/24', N'Nữ', N'1615008@mta.edu.com.vn', N'034542295', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (109, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615009', N'1615009', N'Văn Thị Oanh', N'logo.png', N'1998/10/13', N'Nữ', N'1615009@mta.edu.com.vn', N'034517470', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (110, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615010', N'1615010', N'Vũ Tôn Công', N'logo.png', N'1998/12/19', N'Nam', N'1615010@mta.edu.com.vn', N'034626199', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (111, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615011', N'1615011', N'Đinh Dương Minh', N'logo.png', N'1998/5/18', N'Nam', N'1615011@mta.edu.com.vn', N'034169303', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (112, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615012', N'1615012', N'Dương Tú Nga', N'logo.png', N'1998/7/8', N'Nữ', N'1615012@mta.edu.com.vn', N'034183152', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (113, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615013', N'1615013', N'Nhật Thất Toàn', N'logo.png', N'1998/9/4', N'Nam', N'1615013@mta.edu.com.vn', N'034354173', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (114, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615014', N'1615014', N'Bùi Hữu Dũng', N'logo.png', N'1998/7/2', N'Nam', N'1615014@mta.edu.com.vn', N'034197884', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (115, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615015', N'1615015', N'Trương Trương Quý', N'logo.png', N'1998/7/20', N'Nam', N'1615015@mta.edu.com.vn', N'034601513', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (116, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615016', N'1615016', N'Văn Mạnh An', N'logo.png', N'1998/1/2', N'Nam', N'1615016@mta.edu.com.vn', N'034175756', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (117, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615017', N'1615017', N'Phùng Mỹ Nguyệt', N'logo.png', N'1998/3/27', N'Nữ', N'1615017@mta.edu.com.vn', N'034931719', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (118, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615018', N'1615018', N'Bùi Trung Phong', N'logo.png', N'1998/8/29', N'Nam', N'1615018@mta.edu.com.vn', N'034170329', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (119, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615019', N'1615019', N'Nguyễn Thanh Cường', N'logo.png', N'1998/12/30', N'Nam', N'1615019@mta.edu.com.vn', N'034759454', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (120, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615020', N'1615020', N'Lê Trần Ba', N'logo.png', N'1998/4/29', N'Nam', N'1615020@mta.edu.com.vn', N'034220768', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (121, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615021', N'1615021', N'Văn Tú Vân', N'logo.png', N'1998/7/6', N'Nữ', N'1615021@mta.edu.com.vn', N'034454655', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (122, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615022', N'1615022', N'Hoàng Hải Mai', N'logo.png', N'1998/2/16', N'Nữ', N'1615022@mta.edu.com.vn', N'034234226', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (123, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615023', N'1615023', N'Hồ Vũ Trung', N'logo.png', N'1998/11/24', N'Nam', N'1615023@mta.edu.com.vn', N'034166774', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (124, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615024', N'1615024', N'Hoàng Thương Linh', N'logo.png', N'1998/8/15', N'Nữ', N'1615024@mta.edu.com.vn', N'034325564', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (125, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615025', N'1615025', N'Văn Đô Hải', N'logo.png', N'1998/7/18', N'Nam', N'1615025@mta.edu.com.vn', N'034334699', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (126, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615026', N'1615026', N'Hoàng Ngô Hoàng Tôn', N'logo.png', N'1998/1/27', N'Nam', N'1615026@mta.edu.com.vn', N'034911977', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (127, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615027', N'1615027', N'Đoàn Minh Minh', N'logo.png', N'1998/3/4', N'Nam', N'1615027@mta.edu.com.vn', N'034765388', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (128, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615028', N'1615028', N'Phùng Hữu Anh', N'logo.png', N'1998/3/6', N'Nam', N'1615028@mta.edu.com.vn', N'034698597', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (129, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615029', N'1615029', N'Đàm Cẩm Quyên', N'logo.png', N'1998/10/2', N'Nữ', N'1615029@mta.edu.com.vn', N'034672665', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (130, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615030', N'1615030', N'Dương Âu Chiểu', N'logo.png', N'1998/9/16', N'Nam', N'1615030@mta.edu.com.vn', N'034405029', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (131, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615031', N'1615031', N'Ngô Hoàng Văn Tôn', N'logo.png', N'1998/3/29', N'Nam', N'1615031@mta.edu.com.vn', N'034809212', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (132, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615032', N'1615032', N'Nguyễn Bá Tiến', N'logo.png', N'1998/4/23', N'Nam', N'1615032@mta.edu.com.vn', N'034864991', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (133, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615033', N'1615033', N'Quách Thạch Sơn', N'logo.png', N'1998/1/12', N'Nam', N'1615033@mta.edu.com.vn', N'034890798', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (134, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615034', N'1615034', N'Ngô Hoàng Dương Tám', N'logo.png', N'1998/2/4', N'Nam', N'1615034@mta.edu.com.vn', N'034893822', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (135, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615035', N'1615035', N'Tăng Đức Toàn', N'logo.png', N'1998/8/6', N'Nam', N'1615035@mta.edu.com.vn', N'034416960', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (136, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615036', N'1615036', N'Cao Hải Nhân', N'logo.png', N'1998/7/13', N'Nữ', N'1615036@mta.edu.com.vn', N'034430628', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (137, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615037', N'1615037', N'Hồ Vinh Tám', N'logo.png', N'1998/8/20', N'Nam', N'1615037@mta.edu.com.vn', N'034348800', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (138, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615038', N'1615038', N'Trương Hải Vân', N'logo.png', N'1998/7/6', N'Nữ', N'1615038@mta.edu.com.vn', N'034935544', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (139, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615039', N'1615039', N'Tôn Thị Lệ', N'logo.png', N'1998/1/30', N'Nữ', N'1615039@mta.edu.com.vn', N'034482079', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (140, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615040', N'1615040', N'Trương Kiến Hạ', N'logo.png', N'1998/10/23', N'Nam', N'1615040@mta.edu.com.vn', N'034690002', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (141, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615041', N'1615041', N'Đoàn Lý Phong', N'logo.png', N'1998/3/16', N'Nam', N'1615041@mta.edu.com.vn', N'034796951', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (142, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615042', N'1615042', N'Ngô Hoàng Vũ Hiệp', N'logo.png', N'1998/5/5', N'Nam', N'1615042@mta.edu.com.vn', N'034144218', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (143, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615043', N'1615043', N'Nguyễn Đô Minh', N'logo.png', N'1998/2/5', N'Nam', N'1615043@mta.edu.com.vn', N'034480281', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (144, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615044', N'1615044', N'Bùi Kiến Thành', N'logo.png', N'1998/11/20', N'Nam', N'1615044@mta.edu.com.vn', N'034223412', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (145, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615045', N'1615045', N'Hoàng Cẩm Ý', N'logo.png', N'1998/2/11', N'Nữ', N'1615045@mta.edu.com.vn', N'034526803', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (146, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615046', N'1615046', N'Đinh Thị Ba', N'logo.png', N'1998/7/19', N'Nữ', N'1615046@mta.edu.com.vn', N'034361001', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (147, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615047', N'1615047', N'Hoàng Ngô Mỹ Hoài', N'logo.png', N'1998/6/10', N'Nữ', N'1615047@mta.edu.com.vn', N'034332533', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (148, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615048', N'1615048', N'Đàm Hải Nhi', N'logo.png', N'1998/3/2', N'Nữ', N'1615048@mta.edu.com.vn', N'034258021', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (149, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615049', N'1615049', N'Ngô Tú Nhân', N'logo.png', N'1998/9/11', N'Nữ', N'1615049@mta.edu.com.vn', N'034710331', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (150, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615050', N'1615050', N'Ngô Hoàng Thương Hoa', N'logo.png', N'1998/12/2', N'Nữ', N'1615050@mta.edu.com.vn', N'034287087', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (151, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615051', N'1615051', N'Trương  Đình Phúc', N'logo.png', N'1998/8/22', N'Nam', N'1615051@mta.edu.com.vn', N'034542452', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (152, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615052', N'1615052', N'Nguyễn Bá Hải', N'logo.png', N'1998/9/25', N'Nam', N'1615052@mta.edu.com.vn', N'034865118', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (153, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615053', N'1615053', N'Quách Ngọc Bích', N'logo.png', N'1998/1/31', N'Nữ', N'1615053@mta.edu.com.vn', N'034620464', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (154, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615054', N'1615054', N'Nhật Xuân Anh', N'logo.png', N'1998/10/19', N'Nữ', N'1615054@mta.edu.com.vn', N'034105198', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (155, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615055', N'1615055', N'Lê Thanh Ngân', N'logo.png', N'1998/2/9', N'Nữ', N'1615055@mta.edu.com.vn', N'034275145', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (156, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615056', N'1615056', N'Quách Thị Hồng', N'logo.png', N'1998/10/8', N'Nữ', N'1615056@mta.edu.com.vn', N'034265543', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (157, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615057', N'1615057', N'Bùi Thái Tâm', N'logo.png', N'1998/6/5', N'Nữ', N'1615057@mta.edu.com.vn', N'034369236', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (158, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615058', N'1615058', N'Trần Hải Tâm', N'logo.png', N'1998/5/14', N'Nữ', N'1615058@mta.edu.com.vn', N'034834708', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (159, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615059', N'1615059', N'Hồ Diệu Hương', N'logo.png', N'1998/3/29', N'Nữ', N'1615059@mta.edu.com.vn', N'034562229', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (160, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615060', N'1615060', N'Ngô Hoàng Cao Chiều', N'logo.png', N'1998/9/1', N'Nam', N'1615060@mta.edu.com.vn', N'034312325', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (161, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615061', N'1615061', N'Bùi Diệu Thảo', N'logo.png', N'1998/9/12', N'Nữ', N'1615061@mta.edu.com.vn', N'034873641', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (162, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615062', N'1615062', N'Tăng Lý Long', N'logo.png', N'1998/1/22', N'Nam', N'1615062@mta.edu.com.vn', N'034324096', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (163, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615063', N'1615063', N'Cao Khánh Bích', N'logo.png', N'1998/12/10', N'Nữ', N'1615063@mta.edu.com.vn', N'034399114', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (164, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615064', N'1615064', N'Phan Thành Ba', N'logo.png', N'1998/11/27', N'Nam', N'1615064@mta.edu.com.vn', N'034275858', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (165, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615065', N'1615065', N'Đoàn Trọng Hạ', N'logo.png', N'1998/7/7', N'Nam', N'1615065@mta.edu.com.vn', N'034621207', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (166, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615066', N'1615066', N'Hoàng Mỹ Linh', N'logo.png', N'1998/11/1', N'Nữ', N'1615066@mta.edu.com.vn', N'034138594', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (167, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615067', N'1615067', N'Ngô Hoàng Ngọc Ý', N'logo.png', N'1998/9/26', N'Nữ', N'1615067@mta.edu.com.vn', N'034460588', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (168, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615068', N'1615068', N'Ngô Hoàng Thành Dũng', N'logo.png', N'1998/6/26', N'Nam', N'1615068@mta.edu.com.vn', N'034587515', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (169, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615069', N'1615069', N'Lê Hải Trang', N'logo.png', N'1998/9/29', N'Nữ', N'1615069@mta.edu.com.vn', N'034615265', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (170, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615070', N'1615070', N'Tôn Trần Đoàn', N'logo.png', N'1998/7/22', N'Nam', N'1615070@mta.edu.com.vn', N'034497056', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (171, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615071', N'1615071', N'Cao Trọng Công', N'logo.png', N'1998/8/17', N'Nam', N'1615071@mta.edu.com.vn', N'034409307', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (172, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615072', N'1615072', N'Hoàng Ngô Thương Thanh', N'logo.png', N'1998/9/17', N'Nữ', N'1615072@mta.edu.com.vn', N'034857974', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (173, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615073', N'1615073', N'Ngô Hoàng Lê Hà', N'logo.png', N'1998/1/15', N'Nữ', N'1615073@mta.edu.com.vn', N'034298139', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (174, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615074', N'1615074', N'Trương Đức Minh', N'logo.png', N'1998/6/26', N'Nam', N'1615074@mta.edu.com.vn', N'034794944', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (175, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615075', N'1615075', N'Tăng Hoài Ba', N'logo.png', N'1998/10/6', N'Nữ', N'1615075@mta.edu.com.vn', N'034843683', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (176, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615076', N'1615076', N'Hoàng Tú Trang', N'logo.png', N'1998/5/7', N'Nữ', N'1615076@mta.edu.com.vn', N'034213289', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (177, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615077', N'1615077', N'Nguyễn Khuất Chiểu', N'logo.png', N'1998/5/25', N'Nam', N'1615077@mta.edu.com.vn', N'034997394', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (178, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615078', N'1615078', N'Nguyễn Châu Ngân', N'logo.png', N'1998/8/5', N'Nữ', N'1615078@mta.edu.com.vn', N'034729905', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (179, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615079', N'1615079', N'Dương Lê Lan', N'logo.png', N'1998/2/7', N'Nữ', N'1615079@mta.edu.com.vn', N'034624309', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (180, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615080', N'1615080', N'Đàm Dương Quang', N'logo.png', N'1998/8/5', N'Nam', N'1615080@mta.edu.com.vn', N'034141776', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (181, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615081', N'1615081', N'Vũ Thành Phú', N'logo.png', N'1998/10/8', N'Nam', N'1615081@mta.edu.com.vn', N'034304080', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (182, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615082', N'1615082', N'Đàm Thành Hải', N'logo.png', N'1998/9/5', N'Nam', N'1615082@mta.edu.com.vn', N'034671263', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (183, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615083', N'1615083', N'Cao Văn Minh', N'logo.png', N'1998/9/12', N'Nam', N'1615083@mta.edu.com.vn', N'034556743', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (184, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615084', N'1615084', N'Hoàng Đô Chiều', N'logo.png', N'1998/1/4', N'Nam', N'1615084@mta.edu.com.vn', N'034312832', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (185, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615085', N'1615085', N'Hoàng Ngô Cẩm Nhân', N'logo.png', N'1998/1/18', N'Nữ', N'1615085@mta.edu.com.vn', N'034394059', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (186, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615086', N'1615086', N'Đàm Lê Trân', N'logo.png', N'1998/4/6', N'Nữ', N'1615086@mta.edu.com.vn', N'034217146', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (187, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615087', N'1615087', N'Hoàng Ngô Trung Tôn', N'logo.png', N'1998/2/15', N'Nam', N'1615087@mta.edu.com.vn', N'034839603', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (188, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615088', N'1615088', N'Hồ Cẩm Trân', N'logo.png', N'1998/5/18', N'Nữ', N'1615088@mta.edu.com.vn', N'034955073', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (189, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615089', N'1615089', N'Hồ Tuấn Chiểu', N'logo.png', N'1998/10/18', N'Nam', N'1615089@mta.edu.com.vn', N'034248111', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (190, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615090', N'1615090', N'Phùng Thị Ba', N'logo.png', N'1998/6/13', N'Nữ', N'1615090@mta.edu.com.vn', N'034334703', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (191, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615091', N'1615091', N'Cao Thương Hậu', N'logo.png', N'1998/11/15', N'Nữ', N'1615091@mta.edu.com.vn', N'034474929', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (192, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615092', N'1615092', N'Đàm Minh Cường', N'logo.png', N'1998/9/15', N'Nam', N'1615092@mta.edu.com.vn', N'034555962', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (193, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615093', N'1615093', N'Văn Hải Gấm', N'logo.png', N'1998/6/9', N'Nữ', N'1615093@mta.edu.com.vn', N'034880394', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (194, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615094', N'1615094', N'Trương Thương Ly', N'logo.png', N'1998/5/14', N'Nữ', N'1615094@mta.edu.com.vn', N'034432552', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (195, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615095', N'1615095', N'Bùi Mỹ Ba', N'logo.png', N'1998/1/14', N'Nữ', N'1615095@mta.edu.com.vn', N'034826289', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (196, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615096', N'1615096', N'Đoàn Hoài Ý', N'logo.png', N'1998/2/17', N'Nữ', N'1615096@mta.edu.com.vn', N'034758944', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (197, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615097', N'1615097', N'Nhật Châu Cúc', N'logo.png', N'1998/9/6', N'Nữ', N'1615097@mta.edu.com.vn', N'034237590', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (198, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615098', N'1615098', N'Lê Xuân Lam', N'logo.png', N'1998/5/27', N'Nữ', N'1615098@mta.edu.com.vn', N'034638492', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (199, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615099', N'1615099', N'Lê Nhật Trung', N'logo.png', N'1998/8/9', N'Nam', N'1615099@mta.edu.com.vn', N'034581426', N'Student', 1)
GO
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (200, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'1615100', N'1615100', N'Ngô Hoàng Mỹ Lụa', N'logo.png', N'1998/3/28', N'Nữ', N'1615100@mta.edu.com.vn', N'034574115', N'Student', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (201, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'8605601', N'8605601', N'Trần Thị Hoàng', N'logo.png', N'1968/3/28', N'Nữ', N'8605601@mta.edu.com.vn', N'034334117', N'Teacher', 1)
INSERT [dbo].[Account] ([id], [DayCreate], [Username], [Password], [FullName], [Img], [BrithDay], [Gender], [Email], [PhoneNumber], [Role], [State]) VALUES (1002, CAST(N'2020-11-20T16:53:00.000' AS DateTime), N'3900430', N'3900430', N'Lương Văn Minh', N'logo.png', N'1976/3/23', N'Nam', N'3900430@mta.edu.com.vn', N'034574113', N'Teacher', 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([id], [CodeAnswer], [CharOrder], [ContentQ], [Img], [ChoseTime], [CodeQuestion], [State]) VALUES (1, N'ans001', N'a', N'dap1', NULL, NULL, 1, 1)
INSERT [dbo].[Answer] ([id], [CodeAnswer], [CharOrder], [ContentQ], [Img], [ChoseTime], [CodeQuestion], [State]) VALUES (2, N'ans002', N'b', N'dap2', NULL, NULL, 1, 1)
INSERT [dbo].[Answer] ([id], [CodeAnswer], [CharOrder], [ContentQ], [Img], [ChoseTime], [CodeQuestion], [State]) VALUES (3, N'ans003', N'c', N'dap3', NULL, NULL, 1, 1)
INSERT [dbo].[Answer] ([id], [CodeAnswer], [CharOrder], [ContentQ], [Img], [ChoseTime], [CodeQuestion], [State]) VALUES (4, N'ans004', N'd', N'dap4', NULL, NULL, 1, 1)
INSERT [dbo].[Answer] ([id], [CodeAnswer], [CharOrder], [ContentQ], [Img], [ChoseTime], [CodeQuestion], [State]) VALUES (6, N'ttte1', N't', N't', N'trs', NULL, 2, 1)
INSERT [dbo].[Answer] ([id], [CodeAnswer], [CharOrder], [ContentQ], [Img], [ChoseTime], [CodeQuestion], [State]) VALUES (8, N'ans007', N'cau1', N'test', N'tesst', NULL, 5, 1)
SET IDENTITY_INSERT [dbo].[Answer] OFF
SET IDENTITY_INSERT [dbo].[ClassCourse] ON 

INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (78, N'32259151 1', N'Đo lường và điều khiển bằng máy tính', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (79, N'322591512', N'Đo lường và điều khiển bằng máy tính', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (80, N'322591513', N'Đo lường và điều khiển bằng máy tính', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (81, N'32476151', N'Các hệ thống quang học trong y tế', 22, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (82, N'123211513', N'Cơ sở dữ liệu - Databases', 140, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (83, N'12464151', N'Mã hóa - Cryptography', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (84, N'12375151', N'Nhập môn cơ sở dữ liệu lớn - Introduction to Big Data', 138, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (85, N'125231513', N'Phương pháp nghiên cứu IT - Research Methodology in IT', 139, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (86, N'125231514', N'Phương pháp nghiên cứu IT - Research Methodology in IT', 139, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (87, N'12161151', N'Toán chuyên đề', 178, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (88, N'11103151', N'Vật lý đại cương 2', 465, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (89, N'123741512', N'Công nghệ web nâng cao - Advanced Web Technologies', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (90, N'12101151', N'Giải tích 1', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (91, N'31256151 2', N'Kỹ thuật thu phát vô tuyến điện', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (92, N'12556151 2', N'Lập trình nâng cao - Advanced Programming', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (93, N'12556151 3', N'Lập trình nâng cao - Advanced Programming', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (94, N'32266151 1', N'Mạng truyền thông và truyền thông công nghiệp', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (95, N'12564151', N'Thiết kế giao diện người sử dụng - User Interíace Design', 139, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (96, N'24245151', N'Động cơ điện', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (97, N'12374151 1', N'Công nghệ web nâng cao - Advanced Web Technologies', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (98, N'4463151', N'Kỹ thuật thi công 1', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (99, N'322661512', N'Mạng truyền thông và truyền thông công nghiệp', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (100, N'12461151', N'An ninh mạng - Network Security', 222, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (101, N'125581512', N'Công nghệ Client/Server - Client/Server Technology', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (102, N'32468151', N'Hệ chuyên gia trong y tế', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (103, N'31563151 1', N'Kỹ thuật truyền số liệu', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (104, N'322231512', N'Lý thuyết điều khiển tự động 1 + BTL', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (105, N'12526151 1', N'Ngôn ngữ lập trình 2 - Programming languages 2', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (106, N'51401151', N'Tư tưởng Hồ Chí Minh + TL', 465, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (107, N'12227151 1', N'Trí tuệ nhân tạo - Artiíicial Intelligence', 178, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (108, N'12227151 2', N'Trí tuệ nhân tạo - Artiíicial Intelligence', 178, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (109, N'12525151', N'Kỹ thuật lập trình - Programming fundamentals', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (110, N'32223151 1', N'Lý thuyết điều khiển tự động 1 + BTL', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (111, N'32223151 3', N'Lý thuyết điều khiển tự động 1 + BTL', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (112, N'12325151 1', N'Phân tích và thiết kế giải thuật - Algorithm analysis and design', 138, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (113, N'12523151 2', N'Phương pháp nghiên cứu IT - Research Methodology in IT', 139, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (114, N'4459151', N'Kết cấu nhà bê tông cốt thép', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (115, N'32257151', N'Lý thuyết điều khiển tự động 2', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (116, N'32358151 1', N'Lý thuyết mạch năng lượng', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (117, N'12103151', N'Lý thuyết xác suất thống kê', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (118, N'12260151', N'Công nghệ đa phương tiện', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (119, N'32222151 2', N'Cấu trúc máy tính', 44, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (120, N'12223151 1', N'Ngôn ngữ lập trình c', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (121, N'51101151', N'Những nguyên lý cơ bản của Chủ nghĩa Mác - Lênin-1', 138, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (122, N'12571151', N'Phát triển phần mềm di động - Mobile Software Development', 139, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (123, N'12523151 1', N'Phương pháp nghiên cứu IT - Research Methodology in IT', 139, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (124, N'32278151', N'Thiết kế hệ thống nhúng', 139, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (125, N'31656151 1', N'Kỹ thuật định vị dẫn đường', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (126, N'32456151', N'Mạch xử lý tín hiệu y sinh', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (127, N'31124151', N'Kỹ thuật vi xử lý và lập trình assembler', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (128, N'51301151', N'Pháp luật đại cương', 138, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (129, N'322221513', N'Cấu trúc máy tính', 122, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (130, N'315631512', N'Kỹ thuật truyền số liệu', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (131, N'32258151 1', N'Lý thuyết điều khiển tự động nâng cao', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (132, N'32258151 2', N'Lý thuyết điều khiển tự động nâng cao', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (133, N'12160151 1', N'Toán chuyên đề', 178, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (134, N'12160151 2', N'Toán chuyên đề', 178, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (135, N'12223151 2', N'Ngôn ngữ lập trình c', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (136, N'32280151 1', N'Điều khiển không gian trạng thái', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (137, N'32222151 1', N'Cấu trúc máy tính', 44, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (138, N'31560151 2', N'Thông tin số', 139, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (139, N'32280151 2', N'Điều khiển không gian trạng thái', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (140, N'32259151 4', N'Đo lường và điều khiển bằng máy tính', 110, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (141, N'12100151 1', N'Hình giải tích và đại số tuyến tính', 114, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (142, N'121001512', N'Hình giải tích và đại số tuyến tính', 114, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (143, N'24359151', N'Lập trình phát triển CAD/CAE', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (144, N'21223151', N'Chi tiết máy', 13, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (145, N'31560151 1', N'Thông tin số', 139, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (146, N'32358151 2', N'Lý thuyết mạch năng lượng', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (147, N'31557151', N'Nguyên lý truyền tin', 138, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (148, N'31256151 1', N'Kỹ thuật thu phát vô tuyến điện', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (149, N'32359151 2', N'Máy điện 1', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (150, N'32260151 1', N'Vi điều khiển trong hệ thống nhúng', 465, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (151, N'11201151 1', N'Cơ sở lý thuyết hóa học', 12, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (152, N'24258151', N'Phân tích cơ hệ nhiều vật nhờ máy tính', 138, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (153, N'12223151 3', N'Ngôn ngữ lập trình c', 137, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (154, N'112011512', N'Cơ sở lý thuyết hóa học', 11, 1)
INSERT [dbo].[ClassCourse] ([id], [CodeClass], [nameClass], [CodeCourse], [State]) VALUES (1002, N'51101151 1', N'Những nguyên lý cơ bản của Chủ nghĩa Mác - Lênin-1 -1', 1, 1)
SET IDENTITY_INSERT [dbo].[ClassCourse] OFF
SET IDENTITY_INSERT [dbo].[ClassCourse_Student] ON 

INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (2, 2, 1002, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1008, 5, 1002, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1017, 157, 78, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1020, 197, 78, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1023, 42, 78, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1024, 10, 78, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1025, 24, 78, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1026, 1, 79, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1027, 3, 79, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1031, 9, 79, 1)
INSERT [dbo].[ClassCourse_Student] ([id], [userStudent], [CodeClass], [State]) VALUES (1032, 13, 79, 1)
SET IDENTITY_INSERT [dbo].[ClassCourse_Student] OFF
SET IDENTITY_INSERT [dbo].[ClassCourse_Teacher] ON 

INSERT [dbo].[ClassCourse_Teacher] ([id], [userTeacher], [CodeClass], [State]) VALUES (1, 201, 1002, 1)
SET IDENTITY_INSERT [dbo].[ClassCourse_Teacher] OFF
SET IDENTITY_INSERT [dbo].[ContentLec] ON 

INSERT [dbo].[ContentLec] ([id], [CodeContentLec], [dayCreate], [header], [decription], [DayOpen], [DayClose], [TypeContentLec], [DayExpire], [Content], [TimeStart], [Duration], [CodeLecture], [Self], [State]) VALUES (1, N'222001', CAST(N'2020-12-20T03:09:48.123' AS DateTime), N'Kiểm tra', N'Kiểm tra chương 1', CAST(N'2020-12-20T00:00:00.000' AS DateTime), CAST(N'2020-12-20T00:00:00.000' AS DateTime), 2, CAST(N'2020-12-20T00:00:00.000' AS DateTime), NULL, CAST(N'2020-12-20T00:00:00.000' AS DateTime), 60, 1, 201, 1)
SET IDENTITY_INSERT [dbo].[ContentLec] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (1, N'51101151', N'Những nguyên lý cơ bản của Chủ nghĩa Mác - Lênin-1', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (2, N'51201151', N'Những nguyên lý cơ bản của Chủ nghĩa Mác - Lênin-2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (3, N'51401151', N'Tư tưởng Hồ Chí Minh + TL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (4, N'51301151', N'Pháp luật đại cương', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (5, N'52201151', N'Đường lối cách mạng của Đảng Cộng sản Việt Nam', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (6, N'13103151', N'Tiếng Anh B11', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (7, N'13104151', N'Tiếng Anh B12', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (8, N'12100151', N'Hình giải tích và đại số tuyến tính', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (9, N'12101151', N'Giải tích 1', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (10, N'12500151', N'Lập trình cơ bản', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (11, N'11101151', N'Vật lý đại cương 1', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (12, N'11102151', N'Th nghiệm vật lý đ i cương 1', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (13, N'12102151', N'Giải tích 2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (14, N'21201151', N'Hình họa và vẽ kỹ thuật cơ bản + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (15, N'11201151', N'Cơ sở lý thuyết hóa học', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (16, N'11202151', N'Th nghiệm cơ sở lý thuyết hóa học', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (17, N'11103151', N'Vật lý đại cương 2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (18, N'11104151', N'Th nghiệm vật lý đại cương 2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (19, N'12103151', N'Lý thuyết xác suất thống kê', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (20, N'6103151', N'Đường lối quốc phòng và an ninh của Đảng Cộng sản Việt Nam', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (21, N'6303151', N'Công tác quốc phòng và an ninh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (22, N'6204151', N'Quân sự chung, chiến thuật, kỹ thuật bắn súng ngắn và sử dụng lựu đạn', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (23, N'6104151', N'Hiểu biết chung về quân, binh chủng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (24, N'6401151', N'Giáo dục thể chất cơ bản', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (25, N'6402151', N'Chạy cự ly trung bình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (26, N'6403151', N'Nhảy xa', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (27, N'6404151', N'Nhảy cao úp bụng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (28, N'6405151', N'Bóng chuyền', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (29, N'6406151', N'Bóng bàn', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (30, N'6407151', N'Bóng rổ', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (31, N'6408151', N'Cầu lông', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (32, N'6409151', N'Bơi lội', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (33, N'21221151', N'Vẽ kỹ thuật cơ khí + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (34, N'21121151', N'Cơ lý thuyết 1 + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (35, N'21122151', N'Sức bền vật liệu 1 +BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (36, N'31121151', N'Cấu kiện điện tử', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (37, N'31122151', N'Thí nghiệm cấu kiện điện tử', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (38, N'21140151', N'Cơ lý thuyết 2 +BTL (CK)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (39, N'32223151', N'Lý thuyết điều khiển tự động 1 + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (40, N'21421151', N'Dung sai + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (41, N'31321151', N'Lý thuyết mạch + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (42, N'31322151', N'Thí nghiệm lý thuyết mạch', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (43, N'21123151', N'Thí nghiệm cơ học', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (44, N'21141151', N'Sức bền vật liệu 2 + BTL (CK)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (45, N'21523151', N'Vật liệu học', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (46, N'21540151', N'Thí nghiệm vật liệu', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (47, N'21222151', N'Nguyên lý máy + bTl', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (48, N'21321151', N'Thủy lực và máy thủy lực', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (49, N'21223151', N'Chi tiết máy', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (50, N'24321151', N'CAD/CAE', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (51, N'21422151', N'Công nghệ kim loại', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (52, N'21423151', N'Cơ sở công nghệ chế t o máy', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (53, N'21224151', N'Đồ án chi tiết máy', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (54, N'24245151', N'Động cơ điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (55, N'21322151', N'Kỹ thuật nhiệt', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (56, N'32257151', N'Lý thuyết điều khiển tự động 2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (57, N'32357151', N'An toàn điện, kh cụ điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (58, N'21124151', N'Dao động trong kỹ thuật', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (59, N'21424151', N'An toàn lao động và bảo vệ môi trường trong sản xuất', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (60, N'241001', N'Cơ học kết cấu máy bay', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (61, N'241002', N'Đo lường, tiêu chuẩn hoá trong khai thác kỹ thuật hàng không', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (62, N'31221151', N'Điện tử số + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (63, N'31255151', N'Thí nghiệm điện tử số', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (64, N'31123151', N'Điện tử tương tự + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (65, N'31155151', N'Thí nghiệm điện tử tương tự', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (66, N'32360151', N'Đồ án công nghệ CAD/CAM/CNC (CĐT)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (67, N'24356151', N'Cơ sở truyền động điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (68, N'24357151', N'Thiết kế hệ thống nhúng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (69, N'32361151', N'Đồ án thiết kế hệ thống nhúng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (70, N'32278151', N'Hệ thống tự động thuỷ khí (CĐT)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (71, N'32293151', N'PLC, PC và mạng truyền thông công nghiệp', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (72, N'24257151', N'Phân tích cơ hệ nhiều vật nhờ máy tính', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (73, N'24294151', N'Phân tích và tổ hợp hệ thống cơ điện tử', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (74, N'24258151', N'Đồ án phân tích và tổ hợp hệ thống cơ điện tử', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (75, N'24260151', N'Kỹ thuật rô bốt', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (76, N'24261151', N'Hệ thống sản xuất linh ho ạt và tích hợp', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (77, N'31323151', N'Đo lường điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (78, N'31324151', N'Thí nghiệm đo lường điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (79, N'24359151', N'Lập trình phát triển cAd/cae', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (80, N'24360151', N'Cơ sở tự động hoá máy công cụ', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (81, N'12357151', N'Thị giác máy', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (82, N'32283151', N'Cấu trúc máy tính', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (83, N'24288151', N'Động lực và điều khiển các hệ thống rôbốt', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (84, N'8121151', N'Thực tập cơ khí', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (85, N'31856151', N'Thực tập điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (86, N'31858151', N'Thực tập điện tử cơ bản', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (87, N'24262151', N'Thực tập cơ điện tử', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (88, N'24296151', N'Thực tập tốt nghiệp (CĐT)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (89, N'24297151', N'Đồ án tốt nghiệp (CĐT)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (90, N'21231151', N'Vẽ kỹ thuật xây dựng + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (91, N'21142151', N'Cơ học lý thuyết 2 + BTL (XD)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (92, N'32321151', N'Kỹ thuật điện công trình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (93, N'4121151', N'Vật liệu xây dựng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (94, N'4122151', N'Địa chất công trình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (95, N'4521151', N'Trắc địa kỹ thuật xây dựng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (96, N'4130151', N'Thí nghiệm vật liệu xây dựng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (97, N'21323151', N'Thủy lực đại cương', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (98, N'4123151', N'Cơ học kết cấu 1 + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (99, N'21143151', N'Sức bền vật liệu 2 + BTL (XD)', 1)
GO
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (100, N'4126151', N'Cơ học đất + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (101, N'4131151', N'Thí nghiệm cơ học đất', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (102, N'4421151', N'Kết cấu bê tông cốt thép (CNXD)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (103, N'4422151', N'Đồ án kết cấu bê tông cốt thép', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (104, N'23421151', N'Máy xây dựng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (105, N'4124151', N'Cơ học kết cấu 2 + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (106, N'4423151', N'Kết cấu thép, gỗ, gạch đá + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (107, N'4147151', N'Phương pháp số trong tính toán công trình + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (108, N'4121152', N'Tính toán đường chắn đất', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (109, N'4122152', N'Thử nghiệm công trình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (110, N'4123152', N'Lý thuyết tính toán tấm', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (111, N'4129151', N'Động lực học công trình + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (112, N'4124152', N'Tính toán kết cấu trên nền đàn hồi', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (113, N'4125152', N'Tính toán kết cấu dây', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (114, N'4126152', N'Động đất và tác động lên công trình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (115, N'4425151', N'Môi trường xây dựng và an toàn lao động', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (116, N'4149151', N'Ổn định công trình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (117, N'4424151', N'Kinh tế xây dựng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (118, N'4127151', N'Nền móng công trình dân dụng và công nghiệp', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (119, N'4128151', N'Đồ án nền móng công trình dân dụng và công nghiệp', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (120, N'4456151', N'Kiến trúc dân dụng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (121, N'4457151', N'Đồ án kiến trúc dân dụng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (122, N'4459151', N'Kết cấu nhà bê tông cốt thép', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (123, N'4460151', N'Đồ án kết cấu nhà bê tông cốt thép', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (124, N'4463151', N'Kỹ thuật thi công 1', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (125, N'4458151', N'Kiến trúc công nghiệp + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (126, N'21357161', N'Cấp thoát nước + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (127, N'4461151', N'Kết cấu nhà thép', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (128, N'4462151', N'Đồ án kết cấu nhà thép', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (129, N'4464151', N'Kỹ thuật thi công 2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (130, N'4465151', N'Đồ án kỹ thuật thi công 2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (131, N'4466151', N'Tổ chức thi công', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (132, N'4467151', N'Đồ án tổ chức thi công', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (133, N'4469151', N'Nguyên lý quy ho ạch', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (134, N'4468151', N'Pháp luật xây dựng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (135, N'4267151', N'Ứng dụng tin học trong thiết kế công trình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (136, N'4269151', N'Thông gió và điều hòa nhiệt độ', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (137, N'4471151', N'Nhà cao tầng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (138, N'4472151', N'Bê tông cốt thép ứng lực trước', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (139, N'4268151', N'Ứng dụng tin học trong thi công công trình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (140, N'4156151', N'Thực tập địa chất công trình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (141, N'4554151', N'Thực tập trắc địa kỹ thuật xây dựng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (142, N'4470151', N'Thực tập công nhân xây dựng (CnXD)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (143, N'4496151', N'Thực tập tốt nghiệp (XD)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (144, N'4497151', N'Đồ án tốt nghiệp (XD)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (145, N'12160151', N'Toán chuyên đề', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (146, N'32256151', N'Phần tử tự động', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (147, N'32224151', N'Thí nghiệm lý thuyết điều khiển tự động 1', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (148, N'31325151', N'Xử lý số tín hiệu', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (149, N'31349151', N'Th nghiệm xử lý số t n hiệu', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (150, N'31124151', N'Kỹ thuật vi xử lý và lập trình assembler', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (151, N'31154151', N'Th nghiệm kỹ thuật vi xử lý và lập trình assembler', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (152, N'31125151', N'Đồ án kỹ thuật vi xử lý và lập trình assembler', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (153, N'12522151', N'Lập trình hướng đối tượng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (154, N'12223151', N'Ngôn ngữ lập trình C', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (155, N'32222151', N'Cấu trúc máy tính', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (156, N'31147151', N'Thiết kế logic số', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (157, N'31148151', N'Đồ án thiết kế logic số', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (158, N'12266151', N'Mạng nơron', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (159, N'12264151', N'Chương trình dịch', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (160, N'31557151', N'Nguyên lý truyền tin', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (161, N'31257151', N'Trường điện từ và kỹ thuật siêu cao tần', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (162, N'31258151', N'Th nghiệm trường điện từ và kỹ thuật siêu cao tần', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (163, N'31256151', N'Kỹ thuật thu phát vô tuyến điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (164, N'31259151', N'Kỹ thuật ăng-ten và truyền sóng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (165, N'31563151', N'Kỹ thuật truyền số liệu', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (166, N'31560151', N'Thông tin số', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (167, N'31286151', N'Đồ án kỹ thuật thu phát vô tuyến điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (168, N'31260151', N'Th nghiệm kỹ thuật ăng-ten và truyền sóng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (169, N'31561151', N'Thí nghiệm thông tin số', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (170, N'31558151', N'Cơ sở kỹ thuật thông tin vô tuyến + BTL', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (171, N'31564151', N'Mạng viễn thông', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (172, N'31261151', N'Thiết kế RF', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (173, N'31559151', N'Các hệ thống thông tin vô tuyến số', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (174, N'12421151', N'Mạng máy tính', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (175, N'32259151', N'Đo lường và điều khiển bằng máy tính', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (176, N'31656151', N'Kỹ thuật định vị dẫn đường', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (177, N'12327151', N'Xử lý ảnh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (178, N'31756151', N'Dung hòa trường đ''iện từ', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (179, N'31566151', N'Thông tin quang', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (180, N'31568151', N'Xử lý tiếng nói', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (181, N'31567151', N'Thông tin vệ tinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (182, N'31357151', N'An toàn mạng viễn thông', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (183, N'12260151', N'Công nghệ đa phương tiện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (184, N'32290151', N'Mạng nơron trong điều khiển', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (185, N'12460151', N'Mạng không dây', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (186, N'31570151', N'Hệ thông tin di động tiên tiến', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (187, N'31862151', N'Thiết kế mạch tích hợp số', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (188, N'31263151', N'Thiết kế mạch siêu cao tần', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (189, N'31864151', N'Thiết kế mạch điện tử', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (190, N'31576151', N'Thiết kế m ch đo lường, điều khiển', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (191, N'31266151', N'Thiết kế anten', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (192, N'31565151', N'Thực hành điện tử viễn thông', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (193, N'31596151', N'Thực tập tốt nghiệp (ĐTVT)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (194, N'31597151', N'Đồ án tốt nghiệp (ĐTVT)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (195, N'31391151', N'Lý thuyết mạch năng lượng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (196, N'32359151', N'Máy điện 1', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (197, N'32387151', N'Máy điện 2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (198, N'32388151', N'Đồ án máy điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (199, N'32362151', N'Đồ án kỹ thuật biến đổi và truyền động điện tự động', 1)
GO
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (200, N'32258151', N'Lý thuyết điều khiển tự động nâng cao', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (201, N'32260151', N'Vi điều khiển trong hệ thống nhúng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (202, N'32261151', N'Thực hành vi điều khiển', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (203, N'32280151', N'Điều khiển không gian trạng thái', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (204, N'32266151', N'Mạng truyền thông và truyền thông công nghiệp', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (205, N'32264151', N'Tự động hoá với PLC', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (206, N'32265151', N'Thực hành tự động hóa với PLC', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (207, N'32269151', N'Tự động hoá quá trình công nghiệp', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (208, N'32270151', N'Hệ thống điều khiển số trong công nghiệp', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (209, N'32271151', N'Đồ án thiết bị, hệ thống điều khiển và xử lý tin', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (210, N'32273151', N'Mô phỏng các hệ thống điều khiển', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (211, N'32268151', N'Hệ thống tự động thuỷ khí', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (212, N'32275151', N'Lập trình CNC', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (213, N'32289151', N'Tích hợp hệ thống điều khiển', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (214, N'32277151', N'Thiết kế lập trình hệ SCADA', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (215, N'32279151', N'Thiết kế bộ điều khiển số', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (216, N'24259151', N'Kỹ thuật rô bốt', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (217, N'32281151', N'Mạng nơron trong điều khiển', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (218, N'32282151', N'Điều khiển mờ', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (219, N'32272151', N'Thực tập kỹ thuật điều khiển', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (220, N'32296151', N'Thực tập tốt nghiệp (ĐKCN)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (221, N'32297151', N'Đồ án tốt nghiệp (ĐKCN)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (222, N'32363151', N'Cung cấp điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (223, N'32364151', N'Cảm biến đo lường công nghiệp', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (224, N'32365151', N'Tự động điều khiển truyền động điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (225, N'32366151', N'Điều khiển số truyền động điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (226, N'32367151', N'Thiết bị điện máy công nghiệp và máy công cụ', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (227, N'32368151', N'Mô phỏng các hệ điện cơ', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (228, N'32371151', N'Tự động hóa quá trình phát dẫn điện', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (229, N'32372151', N'Điều khiển thông minh trong toà nhà', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (230, N'32375151', N'Thực tập thiết bị điện và kỹ thuật điều khiển', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (231, N'32396151', N'Thực tập tốt nghiệp (TĐH)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (232, N'32397151', N'Đồ án tốt nghiệp (TĐH)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (233, N'32056151', N'Lý sinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (234, N'32062151', N'Sinh lý (từ K14)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (235, N'32058151', N'Hoá sinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (236, N'32059151', N'Giải phẫu', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (237, N'32483151', N'Lập trình ứng dụng chuyên ngành điện tử y sinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (238, N'32464151', N'Phần tử đo lường cảm biến y sinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (239, N'32458151', N'Phân tích và xử lý tín hiệu y sinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (240, N'32456151', N'Mạch xử lý tín hiệu y sinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (241, N'32457151', N'Đồ án mạch xử lý tín hiệu y sinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (242, N'32459151', N'Thiết bị chẩn đoán chức năng', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (243, N'32484151', N'Thiết bị chẩn đoán hình ảnh 1 (từ K14)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (244, N'32471151', N'Hệ thống thông tin y tế', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (245, N'31461151', N'Thiết bị phân tích xét nghiệm', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (246, N'32462151', N'Thiết bị điều trị và trị liệu điện tử', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (247, N'32474151', N'Y học hạt nhân và kỹ thuật xạ trị', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (248, N'32487151', N'Các hệ thống chống nhiễm khuẩn y tế', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (249, N'32465151', N'Cơ sở khai thác sửa chữa trang thiết bị y tế', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (250, N'32485151', N'Thiết bị chẩn đoán hình ảnh 2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (251, N'32476151', N'Các hệ thống quang học trong y tế', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (252, N'32493151', N'Vật liệu y sinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (253, N'32477151', N'Kỹ thuật micro và nano trong y tế', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (254, N'32478151', N'Cơ sinh', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (255, N'32468151', N'Hệ chuyên gia trong y tế', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (256, N'32469151', N'Xử lý ảnh y tế', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (257, N'32467151', N'Thực tập trang thiết bị y tế', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (258, N'32498151', N'Thực tập tốt nghiệp (ĐTYS) (từ K14)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (259, N'32497151', N'Đồ án tốt nghiệp (ĐTYS)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (260, N'12524151', N'Ngôn ngữ lập trình 1 - Programming languages 1', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (261, N'12525151', N'Kỹ thuật lập trình - Programming fundamentals', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (262, N'12221151', N'Toán rời rạc - Discrete math', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (263, N'12226151', N'Lý thuyết hệ điều hành - Operating Systems', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (264, N'12526151', N'Ngôn ngữ lập trình 2 - Programming languages 2', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (265, N'12321151', N'Cơ sở dữ liệu - Databases', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (266, N'12322151', N'Đảm bảo và an toàn thông tin - Information Assurance & Security', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (267, N'12325151', N'Phân tích và thiết kế giải thuật - Algorithm analysis and design', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (268, N'12422151', N'Xây dựng, quản trị và bảo trì hệ thống - System Planning, Administration and Maintenance', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (269, N'12521151', N'Công nghệ phần mềm - Software Engineering', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (270, N'12323151', N'Công nghệ web - Web Technologies', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (271, N'12324151', N'Tương tác người máy - Human Computer Interaction', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (272, N'12423151', N'Công nghệ lập trình t ch hợp - Intergrative Programming and Technologies', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (273, N'12222151', N'Đạo đức nghề nghiệp - Professional Issues and Ethics', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (274, N'12523151', N'Phương pháp nghiên cứu IT - Research Methodology in IT', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (275, N'21756151', N'Kinh tế công nghiệp - Industrial Economics', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (276, N'21460151', N'Công nghệ CAD/CAM - CAD/CAM Technologies', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (277, N'12361151', N'Phân t ch và thiết kế hệ thống - System analysis and design', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (278, N'12359151', N'Cơ sở dữ liệu nâng cao - Advanced Databases', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (279, N'12556151', N'Lập trình nâng cao - Advanced Programming', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (280, N'12227151', N'Trí tuệ nhân tạo - Artiíicial Intelligence', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (281, N'12558151', N'Công nghệ Client/Server - Client/Server Technology', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (282, N'12565151', N'Khai phá dữ liệu - Data mining', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (283, N'12557151', N'Hệ hỗ trợ quyết định - Decision support Systems', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (284, N'12257151', N'Các hệ tri thức - Knowledge based Systems', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (285, N'12259151', N'Nhận dạng mẫu - Pattern Recognition', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (286, N'12262151', N'Xử lý ngôn ngữ tự nhiên - Natural language Processing', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (287, N'12360151', N'Các hệ thống thông tin địa lý - GIS', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (288, N'12375151', N'Nhập môn cơ sở dữ liệu lớn - Introduction to Big Data', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (289, N'12567151', N'Thực tập kỹ thuật lập trình - Programming Projects', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (290, N'12371151', N'Thực tập cơ sở dữ liệu - Database Projects', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (291, N'12568151', N'Thực tập nhóm - Group Projects', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (292, N'12468151', N'Thực tập công nghệ thông tin - IT Projects', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (293, N'12269151', N'Thực tập công nghiệp - Industrial Practice', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (294, N'12570151', N'Đồ án phần I - Hounor Thesis Part I', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (295, N'12597151', N'Đồ án tốt nghiệp (CNTT)', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (296, N'12225151', N'Đồ họa máy tính - Computer Graphics', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (297, N'12270151', N'Lập trình đa phương tiện - Multimedia Programming', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (298, N'12472151', N'Truyền thông đa phương tiện -Multimedia Communications', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (299, N'12439151', N'Truyền dữ liệu - Data Communications', 1)
GO
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (300, N'12560151', N'Quản lý dự án phần mềm - Software Project management', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (301, N'12571151', N'Phát triển phần mềm di động - Mobile Software Development', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (302, N'12464151', N'Mã hóa - Cryptography', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (303, N'12469151', N'Lập trình phần mềm an toàn - Secure Programming', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (304, N'12461151', N'An ninh mạng - Network Security', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (305, N'12456151', N'Kỹ thuật liên mạng - Internetworking', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (306, N'12473151', N'Phân tích Malwares - Malwares Analysis', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (307, N'12483151', N'Điều tra số - Digital forensics', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (308, N'12475151', N'An toàn cơ sở dữ liệu - Database Security', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (309, N'12476151', N'An toàn hệ điều hành - Operating Systems Security', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (310, N'12378151', N'An ninh các hệ thống không dây - Wireless Systems Security', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (311, N'12274151', N'Lý thuyết ngôn ngữ lập trình', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (312, N'12559151', N'Phân t ch và mô hình hóa phần mềm - Software Modeling and Analysis ', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (313, N'12562151', N'Đánh giá chất lượng phần mềm - Software Quality and Evaluation', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (314, N'12561151', N'Thiết kế và xây dựng phần mềm - Software Design and Implementation', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (315, N'12564151', N'Thiết kế giao diện người sử dụng - User Interíace Design', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (316, N'12374151', N'Công nghệ web nâng cao - Advanced Web Technologies', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (317, N'12563151', N'Công nghệ tác tử và phát triển phần mềm - Agent Technology and software development', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (318, N'12370151', N'Lập trình nhúng - Embedded Systems Programming', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (319, N'12572151', N'Hệ điều hành trong hệ thống nhúng - Embedded Operating Systems', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (320, N'12470151', N'Lập trình ghép nối thiết bị - Device Intergrative Programming', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (321, N'12573151', N'Hệ điều hành di động - Mobile Operating Systems', 1)
INSERT [dbo].[Course] ([id], [CodeCourse], [NameCourse], [State]) VALUES (322, N'12364151', N'Lập trình trò chơi và mô phỏng - Computer Game/Simulation Programming', 1)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Lecture] ON 

INSERT [dbo].[Lecture] ([id], [CodeLecture], [Header], [Decription], [idCourse], [Self], [State]) VALUES (1, N'11111', N'Bài 1', N'Giới thiệu về môn học', 1, 201, 1)
INSERT [dbo].[Lecture] ([id], [CodeLecture], [Header], [Decription], [idCourse], [Self], [State]) VALUES (2, N'11112', N'Bài 2', N'Chương 1. Triết học là gì', 1, 201, 1)
INSERT [dbo].[Lecture] ([id], [CodeLecture], [Header], [Decription], [idCourse], [Self], [State]) VALUES (3, N'11113', N'Bài 3', N'Chương 2. Phép biện chứng duy vật', 1, 201, 1)
SET IDENTITY_INSERT [dbo].[Lecture] OFF
SET IDENTITY_INSERT [dbo].[LectureClass] ON 

INSERT [dbo].[LectureClass] ([id], [CodeLecture], [CodeClass], [DayAdd], [State]) VALUES (1, 1, 1002, CAST(N'2020-12-20T01:08:23.490' AS DateTime), 1)
INSERT [dbo].[LectureClass] ([id], [CodeLecture], [CodeClass], [DayAdd], [State]) VALUES (2, 3, 1002, CAST(N'2020-12-20T01:14:32.527' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[LectureClass] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([id], [CodeQuestion], [NumOrder], [Header], [Content], [imgs], [TypeQuest], [idContentLec], [CorrectAnswer], [State]) VALUES (1, N'quest001', N'1', N'Câu 1', N'test', NULL, 2, 1, N'2', 1)
INSERT [dbo].[Question] ([id], [CodeQuestion], [NumOrder], [Header], [Content], [imgs], [TypeQuest], [idContentLec], [CorrectAnswer], [State]) VALUES (2, N'quest002', N'2', N'Cau 2', N'test', N'tesst', 2, 1, N'1', 1)
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[QuestionMCQ] ON 

INSERT [dbo].[QuestionMCQ] ([id], [CodeQuestion], [CodeAnswer], [State]) VALUES (1, 1, 1, 1)
INSERT [dbo].[QuestionMCQ] ([id], [CodeQuestion], [CodeAnswer], [State]) VALUES (2, 1, 2, 1)
INSERT [dbo].[QuestionMCQ] ([id], [CodeQuestion], [CodeAnswer], [State]) VALUES (3, 1, 3, 1)
INSERT [dbo].[QuestionMCQ] ([id], [CodeQuestion], [CodeAnswer], [State]) VALUES (4, 1, 4, 1)
SET IDENTITY_INSERT [dbo].[QuestionMCQ] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Account__536C85E43724B699]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[Account] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Answer__ADCF9B8C913A4255]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[Answer] ADD UNIQUE NONCLUSTERED 
(
	[CodeAnswer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ClassCou__C4A53F93DD6AD7C7]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[ClassCourse] ADD UNIQUE NONCLUSTERED 
(
	[CodeClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ContentL__CF4C3D88603AB737]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[ContentLec] ADD  CONSTRAINT [UQ__ContentL__CF4C3D88603AB737] UNIQUE NONCLUSTERED 
(
	[CodeContentLec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Course__4E3DEA2FFA2B886F]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[Course] ADD UNIQUE NONCLUSTERED 
(
	[CodeCourse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__File__13AEB4E1402B021D]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[File] ADD UNIQUE NONCLUSTERED 
(
	[CodeFile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Lecture__7D4BC2E51B2E1CC8]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[Lecture] ADD  CONSTRAINT [UQ__Lecture__7D4BC2E51B2E1CC8] UNIQUE NONCLUSTERED 
(
	[CodeLecture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Question__E9AE3D811640AD3D]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [UQ__Question__E9AE3D811640AD3D] UNIQUE NONCLUSTERED 
(
	[CodeQuestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Topic__13D39E391244A062]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[Topic] ADD UNIQUE NONCLUSTERED 
(
	[CodeTopic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TypeFile__D07465C0895D0FEB]    Script Date: 7/17/2021 9:54:56 PM ******/
ALTER TABLE [dbo].[TypeFile] ADD UNIQUE NONCLUSTERED 
(
	[CodeType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Img]  DEFAULT ((0)) FOR [Img]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_BrithDay]  DEFAULT (((1)-(1))-(1900)) FOR [BrithDay]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Gender]  DEFAULT (N'None') FOR [Gender]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Email]  DEFAULT (N'None') FOR [Email]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_PhoneNumber]  DEFAULT ('None') FOR [PhoneNumber]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Role]  DEFAULT (N'Account') FOR [Role]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_State]  DEFAULT ((1)) FOR [State]
GO
USE [master]
GO
ALTER DATABASE [db_Elearning] SET  READ_WRITE 
GO
