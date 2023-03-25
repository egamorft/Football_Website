USE [master]
GO
/****** Object:  Database [ProjectPRN231]    Script Date: 2023-03-25 21:19:26 ******/
CREATE DATABASE [ProjectPRN231]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectPRN231', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.EGAMORFT\MSSQL\DATA\ProjectPRN231.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectPRN231_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.EGAMORFT\MSSQL\DATA\ProjectPRN231_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjectPRN231] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectPRN231].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectPRN231] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectPRN231] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectPRN231] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectPRN231] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectPRN231] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectPRN231] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectPRN231] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectPRN231] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectPRN231] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectPRN231] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectPRN231] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectPRN231] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectPRN231] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectPRN231] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectPRN231] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProjectPRN231] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectPRN231] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectPRN231] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectPRN231] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectPRN231] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectPRN231] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectPRN231] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectPRN231] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectPRN231] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectPRN231] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectPRN231] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectPRN231] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectPRN231] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectPRN231] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectPRN231] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectPRN231', N'ON'
GO
ALTER DATABASE [ProjectPRN231] SET QUERY_STORE = OFF
GO
USE [ProjectPRN231]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 2023-03-25 21:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](30) NOT NULL,
	[password] [varchar](18) NOT NULL,
	[full_name] [varchar](30) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[role_id] [int] NOT NULL,
	[status_id] [int] NOT NULL,
 CONSTRAINT [PK__Account___46A222CD2E6F8ACD] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Match_Scorers]    Script Date: 2023-03-25 21:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match_Scorers](
	[statistic_id] [int] NOT NULL,
	[player_id] [int] NOT NULL,
	[score_minutes] [int] NOT NULL,
	[isOwnGoal] [tinyint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 2023-03-25 21:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matches](
	[matches_id] [int] IDENTITY(1,1) NOT NULL,
	[datetime] [datetime] NOT NULL,
	[tournament_id] [int] NOT NULL,
	[team1_id] [int] NOT NULL,
	[team2_id] [int] NOT NULL,
 CONSTRAINT [PK__Matches__85EA4E2F11D9736E] PRIMARY KEY CLUSTERED 
(
	[matches_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 2023-03-25 21:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[player_id] [int] IDENTITY(1,1) NOT NULL,
	[player_name] [varchar](50) NOT NULL,
	[DOB] [date] NULL,
	[nationality] [varchar](50) NOT NULL,
	[position] [varchar](5) NOT NULL,
	[goal] [int] NOT NULL,
	[assist] [int] NOT NULL,
	[height] [int] NOT NULL,
	[img] [varchar](255) NOT NULL,
	[team_id] [int] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[player_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2023-03-25 21:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_description] [varchar](50) NULL,
 CONSTRAINT [PK__Role__760965CC731F855F] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statistics]    Script Date: 2023-03-25 21:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statistics](
	[statistic_id] [int] IDENTITY(1,1) NOT NULL,
	[team1_goal] [int] NOT NULL,
	[team2_goal] [int] NOT NULL,
	[team1_shoot] [int] NOT NULL,
	[team2_shoot] [int] NOT NULL,
	[team1_ontarget] [int] NOT NULL,
	[team2_ontarget] [int] NOT NULL,
	[team1_possession] [float] NOT NULL,
	[team2_possession] [float] NOT NULL,
	[team1_corner] [int] NOT NULL,
	[team2_corner] [int] NOT NULL,
	[matches_id] [int] NOT NULL,
 CONSTRAINT [PK_Statistics] PRIMARY KEY CLUSTERED 
(
	[statistic_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 2023-03-25 21:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[status_description] [varchar](50) NULL,
 CONSTRAINT [PK__Status__3683B53136E0CF90] PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 2023-03-25 21:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[team_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[stadium] [varchar](50) NOT NULL,
	[logo] [varchar](100) NOT NULL,
	[location] [varchar](50) NULL,
	[site] [varchar](50) NULL,
	[tournament_id] [int] NOT NULL,
 CONSTRAINT [PK__Team__F82DEDBCFF37A99A] PRIMARY KEY CLUSTERED 
(
	[team_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournament]    Script Date: 2023-03-25 21:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournament](
	[tournament_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[description] [varchar](70) NULL,
 CONSTRAINT [PK__Tourname__B93AA09DEABDCFEC] PRIMARY KEY CLUSTERED 
(
	[tournament_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (1, N'egamorft', N'123', N'huy tung', CAST(N'1905-06-22T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (2, N'tung', N'123', N'tung huy ', CAST(N'2023-03-16T16:03:32.790' AS DateTime), 2, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (3, N'duc', N'123', N'minh', CAST(N'2023-03-16T16:03:54.150' AS DateTime), 2, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (5, N'minhduc', N'123', N'minh duc', CAST(N'2023-03-16T16:04:21.443' AS DateTime), 1, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (7, N'tung1', N'123', N'tung1111', CAST(N'2023-03-16T16:07:15.270' AS DateTime), 2, 2)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (8, N'duc1', N'123', N'duc1111', CAST(N'2023-03-16T16:07:26.363' AS DateTime), 2, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (9, N'admin', N'123', N'admin', CAST(N'2023-03-16T16:07:37.600' AS DateTime), 2, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (10, N'testPost', N'123', N'hehe', CAST(N'2023-03-17T09:07:01.673' AS DateTime), 2, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (11, N'hahaa', N'123', N'hehee', CAST(N'2023-03-17T09:08:58.647' AS DateTime), 2, 2)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (12, N'tester', N'123', N'testt', CAST(N'2023-03-23T10:40:36.947' AS DateTime), 2, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (13, N'string', N'string', N'string', CAST(N'2023-03-23T10:41:32.187' AS DateTime), 2, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (14, N'egamorft1', N'123', N'123', CAST(N'2023-03-23T11:52:03.100' AS DateTime), 2, 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (1, 25, 9, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (1, 25, 80, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (1, 26, 47, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (1, 32, 39, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (1, 28, 17, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (2, 34, 81, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (2, 35, 26, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (2, 83, 71, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (3, 38, 17, 1)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (3, 82, 82, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (3, 39, 37, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (3, 41, 28, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (3, 43, 66, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (4, 47, 47, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (4, 50, 9, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (5, 88, 8, 1)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (5, 66, 65, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (5, 68, 30, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (5, 86, 40, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (6, 89, 50, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (6, 90, 33, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (6, 91, 45, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (7, 52, 10, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (7, 54, 90, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (7, 94, 30, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (7, 94, 15, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (7, 95, 13, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (7, 95, 66, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (7, 96, 70, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (8, 69, 72, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (9, 61, 12, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (9, 76, 72, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (9, 61, 79, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (9, 60, 33, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (9, 62, 90, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (10, 101, 73, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (10, 101, 39, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (10, 99, 20, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (10, 100, 90, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (11, 10, 39, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (11, 6, 20, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (11, 83, 65, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (12, 8, 39, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (12, 10, 49, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (12, 10, 75, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (12, 34, 34, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (12, 35, 88, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (12, 36, 10, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (13, 25, 73, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (13, 27, 43, 1)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (14, 6, 40, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (15, 27, 29, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (15, 28, 57, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (15, 30, 19, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (15, 25, 48, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (15, 34, 95, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (15, 35, 22, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (17, 48, 38, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (17, 48, 83, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (17, 50, 8, 0)
INSERT [dbo].[Match_Scorers] ([statistic_id], [player_id], [score_minutes], [isOwnGoal]) VALUES (17, 51, 77, 0)
GO
SET IDENTITY_INSERT [dbo].[Matches] ON 

INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (1, CAST(N'2023-03-05T00:00:00.000' AS DateTime), 4, 1, 3)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (3, CAST(N'2023-03-07T23:30:00.000' AS DateTime), 4, 4, 5)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (5, CAST(N'2023-03-07T21:00:00.000' AS DateTime), 4, 6, 7)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (6, CAST(N'2023-03-08T18:00:00.000' AS DateTime), 4, 8, 9)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (7, CAST(N'2023-03-08T20:00:00.000' AS DateTime), 4, 10, 11)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (8, CAST(N'2023-03-10T20:20:00.000' AS DateTime), 4, 12, 13)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (9, CAST(N'2023-03-10T21:00:00.000' AS DateTime), 4, 14, 15)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (10, CAST(N'2023-03-11T21:00:00.000' AS DateTime), 4, 16, 17)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (11, CAST(N'2023-03-12T21:10:00.000' AS DateTime), 4, 18, 19)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (12, CAST(N'2023-03-12T21:30:00.000' AS DateTime), 4, 20, 21)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (13, CAST(N'2023-03-13T20:30:00.000' AS DateTime), 9, 2, 22)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (14, CAST(N'2023-03-13T23:00:00.000' AS DateTime), 4, 1, 4)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (15, CAST(N'2023-03-14T20:10:00.000' AS DateTime), 4, 1, 5)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (16, CAST(N'2023-03-14T21:00:00.000' AS DateTime), 4, 3, 4)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (18, CAST(N'2023-03-15T21:30:00.000' AS DateTime), 4, 1, 6)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (19, CAST(N'2023-03-15T22:15:00.000' AS DateTime), 4, 3, 5)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (20, CAST(N'2023-03-16T21:00:00.000' AS DateTime), 4, 4, 6)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (21, CAST(N'2023-03-16T23:30:00.000' AS DateTime), 4, 5, 9)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (22, CAST(N'2023-03-17T22:30:00.000' AS DateTime), 4, 7, 8)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (23, CAST(N'2023-03-17T23:20:00.000' AS DateTime), 4, 9, 10)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (24, CAST(N'2023-03-18T21:30:00.000' AS DateTime), 4, 11, 12)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (25, CAST(N'2023-03-18T23:30:00.000' AS DateTime), 4, 10, 13)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (26, CAST(N'2023-03-19T20:30:00.000' AS DateTime), 4, 13, 14)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (27, CAST(N'2023-03-19T22:30:00.000' AS DateTime), 4, 12, 15)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (28, CAST(N'2023-03-20T21:30:00.000' AS DateTime), 4, 10, 15)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (29, CAST(N'2023-03-20T23:30:00.000' AS DateTime), 4, 11, 14)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (30, CAST(N'2023-03-21T21:30:00.000' AS DateTime), 4, 12, 16)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (31, CAST(N'2023-03-21T23:30:00.000' AS DateTime), 4, 13, 17)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (32, CAST(N'2023-03-22T20:20:00.000' AS DateTime), 4, 14, 18)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (33, CAST(N'2023-03-22T22:30:00.000' AS DateTime), 4, 15, 19)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (34, CAST(N'2023-03-09T21:30:00.000' AS DateTime), 4, 16, 20)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (35, CAST(N'2023-03-09T23:30:00.000' AS DateTime), 4, 17, 21)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (36, CAST(N'2023-03-03T21:20:00.000' AS DateTime), 4, 12, 18)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (37, CAST(N'2023-03-03T23:30:00.000' AS DateTime), 4, 13, 19)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (38, CAST(N'2023-03-24T21:30:00.000' AS DateTime), 4, 10, 14)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (39, CAST(N'2023-03-24T23:30:00.000' AS DateTime), 4, 11, 15)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (40, CAST(N'2023-03-26T21:30:00.000' AS DateTime), 4, 1, 10)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (41, CAST(N'2023-03-26T23:30:00.000' AS DateTime), 4, 3, 11)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (42, CAST(N'2023-03-27T21:30:00.000' AS DateTime), 4, 4, 12)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (43, CAST(N'2023-03-27T23:30:00.000' AS DateTime), 4, 5, 13)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (44, CAST(N'2023-03-29T21:20:00.000' AS DateTime), 4, 6, 14)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (45, CAST(N'2023-03-29T23:30:00.000' AS DateTime), 4, 7, 15)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (46, CAST(N'2023-03-31T21:30:00.000' AS DateTime), 4, 8, 18)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (47, CAST(N'2023-04-05T23:30:00.000' AS DateTime), 4, 9, 19)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (48, CAST(N'2023-04-07T21:30:00.000' AS DateTime), 4, 6, 12)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (49, CAST(N'2023-04-07T23:30:00.000' AS DateTime), 4, 7, 13)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (50, CAST(N'2023-04-09T21:30:00.000' AS DateTime), 4, 1, 12)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (51, CAST(N'2023-04-10T23:30:00.000' AS DateTime), 4, 3, 14)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (52, CAST(N'2023-04-12T22:30:00.000' AS DateTime), 4, 4, 17)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (53, CAST(N'2023-04-14T23:30:00.000' AS DateTime), 4, 5, 15)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (54, CAST(N'2023-04-18T22:30:00.000' AS DateTime), 4, 6, 19)
SET IDENTITY_INSERT [dbo].[Matches] OFF
GO
SET IDENTITY_INSERT [dbo].[Players] ON 

INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (1, N'David De Gea', CAST(N'1990-07-11' AS Date), N'ESP', N'GK', 0, 0, 192, N'degea.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (2, N'Raphaël Varane', CAST(N'1993-04-25' AS Date), N'FRA', N'DF', 0, 0, 191, N'varane.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (3, N'Diogo Dalot', CAST(N'1999-03-18' AS Date), N'POR', N'DF', 0, 2, 183, N'dalot.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (4, N'Luke Shaw', CAST(N'1995-07-12' AS Date), N'ENG', N'DF', 1, 2, 185, N'shaw.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (5, N'Lisandro Martínez', CAST(N'1998-01-18' AS Date), N'ARG', N'DF', 1, 0, 175, N'lisandro.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (6, N'Bruno Fernandes', CAST(N'1994-09-08' AS Date), N'POR', N'MF', 5, 6, 179, N'bruno.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (7, N'Christian Eriksen', CAST(N'1992-02-14' AS Date), N'DEN', N'MF', 1, 7, 182, N'eriksen.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (8, N'Casemiro', CAST(N'1992-02-23' AS Date), N'BRA', N'MF', 2, 3, 185, N'casemiro.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (9, N'Antony', CAST(N'2000-02-24' AS Date), N'BRA', N'CF', 3, 0, 174, N'antony.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (10, N'Marcus Rashford', CAST(N'1997-10-31' AS Date), N'ENG', N'CF', 14, 3, 180, N'rashford.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (11, N'Wout Weghorst', CAST(N'1992-08-07' AS Date), N'NED', N'CF', 2, 4, 197, N'weghorst.png', 1)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (12, N'Gavi', CAST(N'2004-08-05' AS Date), N'ESP', N'MF', 1, 2, 173, N'gavi.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (13, N'Robert Lewandowski', CAST(N'1988-08-21' AS Date), N'POL', N'CF', 15, 5, 185, N'lewandowski.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (15, N'Pedri', CAST(N'2002-11-25' AS Date), N'ESP', N'MF', 6, 0, 174, N'pedri.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (17, N'Marc-André ter Stegen', CAST(N'1992-04-30' AS Date), N'GER', N'GK', 0, 0, 187, N'terstegen.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (18, N'Ronald Araújo', CAST(N'1999-07-03' AS Date), N'URU', N'DF', 0, 1, 188, N'araujo.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (19, N'Jules Koundé', CAST(N'1998-12-11' AS Date), N'FRA', N'DF', 0, 2, 180, N'kounde.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (20, N'Marcos Alonso', CAST(N'1990-12-28' AS Date), N'ESP', N'DF', 1, 0, 188, N'alonso.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (21, N'Alejandro Balde', CAST(N'2003-10-18' AS Date), N'ESP', N'DF', 0, 4, 175, N'balde.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (22, N'Sergio Busquets', CAST(N'1988-07-16' AS Date), N'ESP', N'MF', 0, 3, 189, N'busquet.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (23, N'Frenkie de Jong', CAST(N'1997-12-05' AS Date), N'NED', N'MF', 2, 1, 181, N'dejong.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (24, N'Raphael Dias Belloli', CAST(N'1996-12-14' AS Date), N'BRA', N'CF', 6, 4, 176, N'raphinha.png', 2)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (25, N'Mohamed Salah', CAST(N'1996-12-12' AS Date), N'
EGY', N'CF', 9, 7, 179, N'Mohamed.jpg', 3)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (26, N'Cody Gakpo', CAST(N'2000-12-24' AS Date), N'NED', N'CF', 7, 1, 181, N'gakpo.jpg', 3)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (27, N'Virgil van Dijk', CAST(N'1997-02-12' AS Date), N'NED', N'DF', 2, 3, 185, N'virgil.jpg', 3)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (28, N'Roberto Firmino', CAST(N'1995-05-07' AS Date), N'BRA', N'CF', 6, 2, 180, N'firmino.jpg', 3)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (29, N'Jordan Henderson', CAST(N'1994-06-09' AS Date), N'ENG', N'MF', 5, 3, 182, N'henderson.jpg', 3)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (30, N'Fabinho', CAST(N'1993-10-11' AS Date), N'BRA', N'MF', 1, 2, 181, N'fabinho.jpeg', 3)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (31, N'Alisson', CAST(N'1992-10-02' AS Date), N'BRA', N'GK', 1, 2, 186, N'alisson.jpg', 3)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (32, N'Darwin Núñez', CAST(N'1999-06-24' AS Date), N'URU', N'CF', 7, 2, 180, N'nunez.jpg', 3)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (33, N'Oleksandr Zinchenko', CAST(N'1996-12-15' AS Date), N'UKR', N'MF', 2, 3, 179, N'zinchenko.jpg', 5)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (34, N'Bukayo Saka', CAST(N'2001-09-05' AS Date), N'ENG', N'MF', 3, 4, 178, N'saka.jpg', 5)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (35, N'Gabriel Jesus', CAST(N'1997-04-03' AS Date), N'BRA', N'CF', 2, 2, 175, N'jesus.jpg', 5)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (36, N'Jorginho', CAST(N'1991-12-20' AS Date), N'ITA', N'MF', 3, 1, 178, N'jorginho.jpeg', 5)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (37, N'Aaron Ramsdale', CAST(N'1998-05-14' AS Date), N'ENG', N'GK', 0, 0, 188, N'ramsdale.jpg', 5)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (38, N'Emiliano Martínez', CAST(N'1992-09-02' AS Date), N'ARG', N'GK', 0, 1, 195, N'emiliano.jpg', 6)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (39, N'Philippe Coutinho', CAST(N'1992-06-12' AS Date), N'BRA', N'MF', 1, 3, 172, N'coutinho.jpg', 6)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (40, N'Jhon Durán', CAST(N'2003-12-13' AS Date), N'COL', N'CF', 1, 1, 186, N'duran.jpg', 6)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (41, N'Douglas Luiz', CAST(N'1998-05-09' AS Date), N'BRA', N'MF', 0, 4, 175, N'luiz.jpg', 6)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (42, N'Leon Bailey', CAST(N'1997-08-09' AS Date), N'JAM', N'CF', 2, 3, 178, N'bailey.png', 6)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (43, N'Ivan Toney', CAST(N'1996-03-16' AS Date), N'ENG', N'CF', 2, 1, 179, N'toney.jpg', 7)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (44, N'Saman Ghoddos', CAST(N'1993-09-06' AS Date), N'ESP', N'CF', 1, 2, 176, N'ghoddos.jpg', 7)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (45, N'David Raya', CAST(N'1995-09-15' AS Date), N'ESP', N'GK', 0, 0, 183, N'raya.jpg', 7)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (46, N'Kevin Schade', CAST(N'2001-11-27' AS Date), N'GER', N'CF', 3, 2, 185, N'schade.jpg', 7)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (47, N'Enzo Fernández', CAST(N'2001-01-17' AS Date), N'ARG', N'MF', 4, 1, 178, N'enzo.jpg', 9)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (48, N'João Félix', CAST(N'1999-11-10' AS Date), N'POR', N'CF', 2, 2, 181, N'felix.png', 9)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (49, N'N''Golo Kanté', CAST(N'1991-03-29' AS Date), N'FRA', N'MF', 1, 0, 171, N'kante.jpg', 9)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (50, N'Kai Havertz', CAST(N'1999-06-11' AS Date), N'GER', N'MF', 2, 3, 191, N'havertz.jpg', 9)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (51, N'Mason Mount', CAST(N'1999-01-10' AS Date), N'ENG', N'MF', 0, 3, 181, N'MasonMount.jpg', 9)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (52, N'Erling Haaland', CAST(N'2000-07-21' AS Date), N'NOR', N'CF', 20, 7, 194, N'haaland.jpg', 15)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (53, N'Julián Álvarez', CAST(N'2000-01-31' AS Date), N'ARG', N'CF', 10, 4, 172, N'alvarez.png', 15)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (54, N'Kevin De Bruyne', CAST(N'1991-06-28' AS Date), N'BEL', N'MF', 8, 9, 181, N'KevinBruyne.jpg', 15)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (55, N'Phil Foden', CAST(N'2000-05-28' AS Date), N'ENG', N'MF', 7, 6, 171, N'foden.jpg', 15)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (58, N'Jack Grealish', CAST(N'1995-09-10' AS Date), N'ENG', N'MF', 6, 3, 175, N'grealish.jpg', 15)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (59, N'Ederson', CAST(N'1993-08-19' AS Date), N'BRA', N'GK', 0, 0, 188, N'ederson.jpg', 15)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (60, N'Son Heung-min', CAST(N'1992-07-08' AS Date), N'KOR', N'CF', 7, 3, 183, N'son.jpg', 19)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (61, N'Harry Kane', CAST(N'1993-07-28' AS Date), N'ENG', N'CF', 6, 2, 188, N'kane.jpg', 19)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (62, N'Richarlison', CAST(N'1997-05-10' AS Date), N'BRA', N'CF', 5, 2, 184, N'richarlison.jpg', 19)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (63, N'Pedro Porro', CAST(N'1999-09-13' AS Date), N'ESP', N'DF', 0, 3, 173, N'porro.jpeg', 19)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (64, N'Hugo Lloris', CAST(N'1986-12-26' AS Date), N'FRA', N'GK', 0, 0, 188, N'lloris.jpg', 19)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (65, N'Jordan Pickford', CAST(N'1994-03-07' AS Date), N'ENG', N'GK', 0, 1, 185, N'pickford.png', 11)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (66, N'Amadou Onana', CAST(N'2001-08-16' AS Date), N'BEL', N'MF', 1, 5, 192, N'onana.jpg', 11)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (67, N'Ellis Simms', CAST(N'2001-01-05' AS Date), N'ENG', N'CF', 1, 1, 191, N'simms.jpg', 11)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (68, N'Dominic Calvert-Lewin', CAST(N'1997-03-16' AS Date), N'ENG', N'CF', 0, 1, 187, N'dominic.jpg', 11)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (69, N'Alexander Isak', CAST(N'1999-09-21' AS Date), N'SWE', N'CF', 3, 1, 192, N'alexander.jpg', 16)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (70, N'Miguel Almirón', CAST(N'1994-02-10' AS Date), N'URU', N'MF', 1, 3, 174, N'miguel.jpg', 16)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (71, N'Loris Karius', CAST(N'1993-03-26' AS Date), N'GER', N'GK', 0, 0, 189, N'karius.jpg', 16)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (72, N'Anthony Gordon', CAST(N'2001-02-24' AS Date), N'ENG', N'CF', 4, 1, 183, N'gordon.jpg', 16)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (73, N'Joelinton', CAST(N'1996-08-14' AS Date), N'BRA', N'CF', 4, 2, 186, N'joelinton.jpg', 16)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (74, N'Kieran Trippier', CAST(N'1990-09-19' AS Date), N'ENG', N'DF', 0, 1, 178, N'trippier.jpg', 16)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (75, N'Dan Burn', CAST(N'1992-05-09' AS Date), N'ENG', N'DF', 0, 1, 198, N'DanBurn.png', 16)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (76, N'James Ward-Prowse', CAST(N'1994-01-01' AS Date), N'ENG', N'MF', 1, 3, 173, N'WardProwse.png', 18)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (77, N'Carlos Alcaraz', CAST(N'2002-11-30' AS Date), N'ARG', N'MF', 0, 2, 176, N'alcaraz.jpg', 18)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (78, N'Mislav Oršic', CAST(N'1992-12-29' AS Date), N'CRO', N'CF', 4, 4, 178, N'orsic.jpg', 18)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (79, N'Paul Onuachu', CAST(N'1994-04-28' AS Date), N'NIG', N'CF', 3, 2, 199, N'onuachu.jpg', 18)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (80, N'Willy Caballero', CAST(N'1981-09-28' AS Date), N'ARG', N'GK', 0, 0, 186, N'caballero.png', 18)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (81, N'Aaron Hickey', CAST(N'2002-06-10' AS Date), N'ENG', N'DF', 0, 0, 185, N'hickey.jpg', 7)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (82, N'Ben Mee', CAST(N'1989-09-21' AS Date), N'ENG', N'DF', 0, 0, 181, N'BenMee.jpg', 7)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (83, N'Dominic Solanke', CAST(N'1997-09-14' AS Date), N'ENG', N'CF', 3, 2, 187, N'solanke.png', 4)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (84, N'Chris Mepham', CAST(N'1997-05-11' AS Date), N'ENG', N'DF', 0, 0, 193, N'mepham.jpg', 4)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (85, N'Jefferson Lerma', CAST(N'1994-10-25' AS Date), N'COL', N'MF', 2, 5, 179, N'lerma.png', 4)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (86, N'Wilfried Zaha', CAST(N'1992-10-11' AS Date), N'ENG', N'CF', 3, 4, 180, N'zaha.jpg', 10)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (87, N'Michael Olise', CAST(N'2001-12-12' AS Date), N'FRA', N'MF', 1, 5, 181, N'olise.jpg', 10)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (88, N'Chris Richards', CAST(N'2000-03-28' AS Date), N'USA', N'DF', 0, 3, 188, N'richards.jpg', 10)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (89, N'Willian Borges Silva', CAST(N'1988-08-09' AS Date), N'BRA', N'CF', 4, 3, 175, N'willian.jpg', 12)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (90, N'Manor Solomon', CAST(N'1999-07-24' AS Date), N'ISR', N'MF', 2, 4, 179, N'solomon.png', 12)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (91, N'Wilfried Gnonto', CAST(N'2003-05-11' AS Date), N'ITA', N'CF', 2, 3, 172, N'gnonto.jpg', 13)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (92, N'Brenden Aaronson', CAST(N'2000-10-22' AS Date), N'USA', N'MF', 1, 5, 178, N'Aaronson.png', 13)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (93, N'Maximilian Wöber', CAST(N'1998-02-04' AS Date), N'ESP', N'DF', 1, 1, 188, N'maximilian.jpg', 13)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (94, N'Jamie Vardy', CAST(N'1987-01-11' AS Date), N'ENG', N'CF', 4, 3, 179, N'vardy.jpg', 14)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (95, N'James Maddison', CAST(N'1996-11-23' AS Date), N'ENG', N'MF', 2, 3, 175, N'maddison.jpg', 14)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (96, N'Youri Tielemans', CAST(N'1997-07-05' AS Date), N'BEL', N'MF', 3, 3, 176, N'tielemans.jpg', 14)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (97, N'Gustavo Scarpa', CAST(N'1994-01-05' AS Date), N'BRA', N'MF', 2, 6, 176, N'scarpa.jpg', 17)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (98, N'Brennan Johnson', CAST(N'2001-05-23' AS Date), N'WAL', N'CF', 4, 2, 178, N'johnson.jpg', 17)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (99, N'Michail Antonio', CAST(N'1990-03-28' AS Date), N'ENG', N'CF', 4, 1, 180, N'antonio.png', 20)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (100, N'Declan Rice', CAST(N'1999-01-14' AS Date), N'ENG', N'MF', 2, 3, 185, N'declan.jpg', 20)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (101, N'João Moutinho', CAST(N'1986-09-08' AS Date), N'POR', N'MF', 3, 0, 181, N'moutinho.jpg', 21)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (102, N'Solly March', CAST(N'1994-07-20' AS Date), N'ENG', N'MF', 4, 2, 180, N'solly.png', 8)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (103, N'Lewis Dunk', CAST(N'1991-11-21' AS Date), N'ENG', N'DF', 1, 0, 181, N'dunk.jpg', 8)
GO
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (104, N'Adam Lallana', CAST(N'1988-05-10' AS Date), N'ENG', N'MF', 3, 1, 182, N'lallana.png', 8)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (105, N'Alexis Mac Allister', CAST(N'1998-12-24' AS Date), N'ARG', N'MF', 5, 3, 174, N'MacAllister.png', 8)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (106, N'Jeremy Sarmiento', CAST(N'2002-06-16' AS Date), N'ECU', N'MF', 1, 0, 178, N'sarmiento.png', 8)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (107, N'Rúben Neves', CAST(N'1997-03-13' AS Date), N'POR', N'MF', 2, 2, 180, N'neves.png', 21)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (108, N'Adama Traoré', CAST(N'1996-01-25' AS Date), N'ESP', N'MF', 2, 1, 178, N'traore.jpg', 21)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (109, N'Raúl Jiménez', CAST(N'1991-05-05' AS Date), N'MEX', N'CF', 3, 2, 181, N'jimenez.jpg', 21)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (110, N'Daniel Podence', CAST(N'1995-10-21' AS Date), N'POR', N'CF', 3, 1, 165, N'podence.png', 21)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (111, N'Bryan Mbeumo', CAST(N'1999-08-07' AS Date), N'FRA', N'CF', 4, 2, 171, N'mbeumo.png', 7)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (113, N'Pablo Fornals', CAST(N'1996-02-22' AS Date), N'ESP', N'MF', 5, 2, 178, N'fornals.png', 20)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (114, N'Manuel Lanzini', CAST(N'1993-02-15' AS Date), N'ARG', N'MF', 3, 1, 167, N'lanzini.jpg', 20)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (115, N'Jarrod Bowen', CAST(N'1996-12-20' AS Date), N'ENG', N'CF', 2, 1, 175, N'bowen.jpg', 20)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (117, N'Saïd Benrahma', CAST(N'1995-08-10' AS Date), N'ARG', N'CF', 3, 0, 172, N'benrahma.jpg', 20)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (119, N'Jesse Lingard', CAST(N'1992-12-15' AS Date), N'ENG', N'MF', 3, 1, 175, N'lingard.png', 17)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (120, N'Morgan Gibbs-White', CAST(N'2000-01-27' AS Date), N'ENG', N'MF', 3, 0, 178, N'Gibbs-White.jpg', 17)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (121, N'Chris Wood', CAST(N'1991-12-07' AS Date), N'ENG', N'CF', 5, 1, 191, N'chris-wood.jpg', 17)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (123, N'André Ayew', CAST(N'1989-12-17' AS Date), N'FRA', N'CF', 2, 0, 175, N'ayew.png', 17)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (124, N'Eberechi Eze', CAST(N'1998-06-29' AS Date), N'ENG', N'MF', 3, 1, 173, N'eberechi.jpg', 10)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (125, N'Will Hughes', CAST(N'1995-04-17' AS Date), N'ENG', N'MF', 4, 0, 185, N'hughes.jpg', 10)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (127, N'Albert Sambi Lokonga
', CAST(N'1999-10-22' AS Date), N'BEL', N'MF', 3, 2, 183, N'lokonga.jpg', 10)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (128, N'Naouirou Ahamada', CAST(N'2002-03-29' AS Date), N'FRA', N'MF', 2, 4, 183, N'ahamada.jpg', 10)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (129, N'Andreas Pereira', CAST(N'1996-01-01' AS Date), N'BEL', N'MF', 3, 1, 178, N'pereira.jpg', 12)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (130, N'Carlos Vinícius', CAST(N'1995-03-25' AS Date), N'BRA', N'CF', 4, 1, 190, N'carlosVinicius.jpg', 12)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (131, N'João Palhinha', CAST(N'1995-05-07' AS Date), N'POR', N'MF', 3, 1, 190, N'palhinha.png', 12)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (132, N'Daniel James', CAST(N'1997-11-10' AS Date), N'ENG', N'CF', 3, 2, 171, N'DanielJames.jpg', 12)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (133, N'Weston McKennie', CAST(N'1998-08-28' AS Date), N'USA', N'MF', 3, 1, 183, N'mckennie.jpg', 13)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (134, N'Georginio Rutter', CAST(N'2002-04-20' AS Date), N'FRA', N'CF', 5, 1, 182, N'rutter.jpg', 13)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (135, N'Tyler Adams', CAST(N'1999-02-14' AS Date), N'USA', N'MF', 4, 1, 175, N'TylerAdams.jpg', 13)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (136, N'Patrick Bamford
', CAST(N'1993-09-05' AS Date), N'ENG', N'CF', 3, 2, 185, N'bamford.png', 13)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (137, N'Patson Daka', CAST(N'1998-10-09' AS Date), N'BRA', N'CF', 4, 2, 183, N'patson.jpg', 14)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (139, N'Kelechi Iheanacho', CAST(N'1996-10-03' AS Date), N'NIG', N'CF', 5, 1, 185, N'iheanacho.png', 14)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (140, N'Harvey Barnes', CAST(N'1997-12-09' AS Date), N'ENG', N'MF', 2, 1, 175, N'HarveyBarnes.png', 14)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (141, N'Wilfred Ndidi', CAST(N'1996-12-16' AS Date), N'NIG', N'MF', 2, 3, 181, N'Ndidi.png', 14)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (142, N'Alex Iwobi', CAST(N'1996-05-03' AS Date), N'NIG', N'CF', 5, 1, 180, N'Iwobi.jpg', 11)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (143, N'Demarai Gray', CAST(N'1996-06-28' AS Date), N'ENG', N'CF', 4, 1, 180, N'DemaraiGray.jpg', 11)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (145, N'Idrissa Gueye', CAST(N'1989-09-26' AS Date), N'ENG', N'MF', 3, 2, 174, N'Gueye.png', 11)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (146, N'Riyad Mahrez', CAST(N'1991-02-21' AS Date), N'FRA', N'CF', 6, 2, 179, N'mahrez.jpg', 15)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (147, N'Rico Lewis', CAST(N'2004-11-21' AS Date), N'ENG', N'DF', 2, 0, 169, N'lewis.jpg', 15)
INSERT [dbo].[Players] ([player_id], [player_name], [DOB], [nationality], [position], [goal], [assist], [height], [img], [team_id]) VALUES (148, N'Diogo Jota', CAST(N'1996-12-04' AS Date), N'POR', N'CF', 6, 1, 178, N'Jota.jpg', 3)
SET IDENTITY_INSERT [dbo].[Players] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([role_id], [role_description]) VALUES (1, N'User')
INSERT [dbo].[Role] ([role_id], [role_description]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Statistics] ON 

INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (1, 0, 5, 7, 18, 3, 12, 35.4, 76.7, 5, 9, 1)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (2, 1, 2, 8, 12, 5, 11, 30.2, 82, 6, 4, 3)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (3, 2, 3, 5, 8, 1, 7, 45.5, 78.9, 3, 4, 5)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (4, 0, 2, 6, 14, 3, 9, 32, 67.8, 4, 5, 6)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (5, 3, 1, 17, 6, 13, 4, 67.8, 54.1, 3, 5, 7)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (6, 2, 1, 14, 10, 12, 8, 78.8, 71.8, 5, 4, 8)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (7, 2, 5, 7, 19, 4, 15, 50.5, 88.8, 6, 10, 9)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (8, 1, 0, 10, 7, 6, 2, 60.7, 34.1, 5, 7, 10)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (9, 1, 4, 5, 10, 2, 8, 40.2, 67.7, 5, 8, 11)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (10, 2, 2, 6, 7, 3, 4, 50.7, 52.1, 5, 7, 12)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (11, 2, 1, 8, 6, 6, 2, 75.4, 64.3, 5, 3, 14)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (12, 3, 3, 9, 8, 5, 6, 60.2, 62.7, 7, 8, 15)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (13, 1, 1, 10, 12, 8, 5, 70.1, 74.4, 5, 2, 16)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (14, 1, 0, 8, 5, 5, 2, 76.5, 55.6, 7, 6, 18)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (15, 4, 2, 12, 8, 10, 4, 78.9, 67.8, 6, 9, 19)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (16, 0, 0, 7, 8, 5, 5, 68.8, 65.6, 6, 10, 20)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (17, 0, 4, 8, 17, 2, 13, 50, 89.7, 2, 6, 21)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (18, 2, 3, 10, 15, 8, 12, 46.7, 53.3, 5, 8, 22)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (19, 3, 1, 12, 8, 10, 4, 67.9, 32.1, 7, 9, 23)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (21, 2, 2, 18, 12, 15, 8, 62.3, 37.7, 5, 6, 24)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (22, 2, 3, 10, 11, 8, 5, 46.7, 53.3, 2, 3, 25)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (23, 2, 4, 7, 9, 4, 8, 50.1, 49.1, 6, 9, 26)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (25, 1, 5, 5, 15, 3, 13, 34.2, 65.8, 8, 10, 27)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (26, 1, 3, 8, 10, 6, 9, 40.2, 59.8, 5, 6, 28)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (27, 1, 0, 5, 4, 5, 2, 35.5, 64.5, 6, 5, 29)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (29, 2, 4, 6, 9, 3, 8, 46.7, 53.3, 4, 7, 30)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (30, 1, 2, 7, 12, 5, 10, 45.5, 54.5, 6, 9, 31)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (31, 3, 2, 10, 8, 9, 5, 67.7, 32.3, 7, 5, 32)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (32, 2, 2, 12, 15, 10, 11, 50.5, 49.5, 6, 7, 33)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (33, 3, 0, 10, 6, 8, 2, 78.8, 21.2, 6, 5, 34)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (34, 1, 0, 9, 9, 8, 7, 65.2, 34.8, 7, 5, 35)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (35, 3, 3, 10, 12, 9, 10, 48.2, 51.8, 5, 6, 36)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (36, 1, 3, 6, 9, 3, 8, 43.7, 56.3, 7, 9, 37)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (37, 2, 2, 7, 8, 7, 7, 57.3, 42.7, 6, 8, 38)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (38, 0, 2, 7, 12, 4, 10, 40.1, 59.9, 5, 9, 39)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (40, 3, 1, 12, 8, 10, 5, 68.7, 31.3, 7, 5, 40)
INSERT [dbo].[Statistics] ([statistic_id], [team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [matches_id]) VALUES (41, 1, 2, 7, 9, 5, 8, 48.8, 51.2, 6, 10, 41)
SET IDENTITY_INSERT [dbo].[Statistics] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([status_id], [status_description]) VALUES (1, N'active')
INSERT [dbo].[Status] ([status_id], [status_description]) VALUES (2, N'inactive')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (1, N'Manchester United', N'Old Trafford', N'ManUTD.png', N'Manchester', N'www.manutd.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (2, N'Barcelona', N'Nou Camp', N'Barcelona.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (3, N'Liverpool', N'Anfield', N'Liverpool.png', N'Liverpool', N'www.liverpoolfc.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (4, N'Bournemouth', N'Vitality Stadium', N'Bournemouth.png', N'Bournemouth', N'www.afcb.co.uk', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (5, N'Arsenal', N'Emirates Stadium', N'arsenal.png', N'London', N'www.arsenal.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (6, N'Aston Villa', N'Villa Park', N'astonvilla.png', N'Birmingham', N'www.avfc.co.uk ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (7, N'Brentford', N'Gtech Community', N'brentford.png', N'London', N'www.brentfordfc.com', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (8, N'Brighton & Hove Albion', N'Amax Stadium', N'brighton.png', N'Brighton', N'www.brightonandhovealbion.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (9, N'Chelsea', N'Stamford Bridge', N'chelsea.png', N'London', N'www.chelseafc.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (10, N'Crystal Palace', N'Sulhurst Park', N'crystalpalace.png', N'London', N'www.cpfc.co.uk ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (11, N'Everton', N'Goodison Park', N'everton.png', N'Liverpool', N'www.evertonfc.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (12, N'Fulham', N'Craven Cottage', N'fulham.png', N'London', N'www.fulhamfc.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (13, N'Leeds United', N'Elland Road', N'leeds.png', N'Leeds', N'www.leedsunited.com/ ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (14, N'Leicester City', N'King Power Stadium', N'leicester.png', N'Leicester', N'www.lcfc.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (15, N'Manchester City', N'Etihad Stadium', N'mc.png', N'Manchester', N'www.mancity.com', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (16, N'Newcastle United', N'St. James''Park', N'nu.png', N'Newcastle', N'www.nufc.co.uk ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (17, N'Nottingham Forest', N'The City Ground', N'nott.png', N'Bridgford', N'www.nottinghamforest.co.uk', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (18, N'Southampton', N'St.Mary''s Statium', N'southampton.png', N'Southamton', N'www.southamptonfc.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (19, N'Tottenham Hotspurr', N'Tottenham Hotspur', N'tott.png', N'London', N'www.tottenhamhotspur.com', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (20, N'West Ham United', N'London Stadium', N'westham.png', N'London', N'www.whufc.com ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (21, N'Wolverhampton Wanderers', N'Molineux Stadium', N'wolves.png', N'Wolverhamton', N'www.wolves.co.uk ', 4)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (22, N'Real Madrid', N'Santiago Bernabéu Stadium', N'real.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (23, N'Atlentico Madrid', N'Civitas Metropolitan Stadium', N'alt.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (24, N'Real Sociedad', N'Civitas Metropolitan Stadium', N'realsociedad.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (25, N'Athletic Club', N'	Estadio San Mames', N'athleticbilbao.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (26, N'Cadiz', N'Nuevo Ramon de Carranza', N'cadiz.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (27, N'Real Betis', N'Benito Villamarín Stadium', N'betis.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (28, N'Elche', N'Estadio Martinez Valero', N'elche.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (29, N'Getafe', N'	Coliseum Alfonso Perez', N'getafe.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (30, N'Rayo Vallecano', N'Estadio de Vallecas', N'rayo.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (31, N'Villarreal', N'Estadio de la Cerámica', N'villarreal.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (32, N'Osasuna', N'El Sadar Stadium', N'osasuna.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (33, N'Mallorca', N'Visit Mallorca Estadi', N'mallorca.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (34, N'Celta Vigo', N'Estadio de Balaídos', N'velta.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (35, N'Girona', N'Estadi Montilivi', N'girona.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (36, N'Sevilla', N'Ramon Sanchez-Pizjuan Stadium', N'sevilla.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (37, N'Valladolid', N'José Zorrilla Stadium', N'valladolid.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (38, N'Espanyol', N'RCDE Stadium', N'espanyol.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (39, N'Valencia', N'Mestalla Stadium', N'valencia.png', NULL, NULL, 9)
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo], [location], [site], [tournament_id]) VALUES (40, N'Almeria', N'Municipal Stadium of the Mediterranean Games', N'almeria.png', NULL, NULL, 9)
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET IDENTITY_INSERT [dbo].[Tournament] ON 

INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (4, N'Premier League', N'highest division of the football league system in England')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (9, N'Laliga', N'Spain Football Leagh')
SET IDENTITY_INSERT [dbo].[Tournament] OFF
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_role_id]  DEFAULT ((2)) FOR [role_id]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_status_id]  DEFAULT ((1)) FOR [status_id]
GO
ALTER TABLE [dbo].[Match_Scorers] ADD  CONSTRAINT [DF_Match_Scorers_isOwnGoal]  DEFAULT ((0)) FOR [isOwnGoal]
GO
ALTER TABLE [dbo].[Players] ADD  CONSTRAINT [DF_Players_img]  DEFAULT ('unknownPlayer.png') FOR [img]
GO
ALTER TABLE [dbo].[Team] ADD  CONSTRAINT [DF_Team_logo]  DEFAULT (N'unknownClub.png') FOR [logo]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK__Account___role_i__2C3393D0] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK__Account___role_i__2C3393D0]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK__Account___status__2D27B809] FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([status_id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK__Account___status__2D27B809]
GO
ALTER TABLE [dbo].[Match_Scorers]  WITH CHECK ADD  CONSTRAINT [FK_Match_Scorers_Players] FOREIGN KEY([player_id])
REFERENCES [dbo].[Players] ([player_id])
GO
ALTER TABLE [dbo].[Match_Scorers] CHECK CONSTRAINT [FK_Match_Scorers_Players]
GO
ALTER TABLE [dbo].[Match_Scorers]  WITH CHECK ADD  CONSTRAINT [FK_Match_Scorers_Statistics] FOREIGN KEY([statistic_id])
REFERENCES [dbo].[Statistics] ([statistic_id])
GO
ALTER TABLE [dbo].[Match_Scorers] CHECK CONSTRAINT [FK_Match_Scorers_Statistics]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK__Matches__team_id__31EC6D26] FOREIGN KEY([team1_id])
REFERENCES [dbo].[Team] ([team_id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK__Matches__team_id__31EC6D26]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK__Matches__team2_i__32E0915F] FOREIGN KEY([team2_id])
REFERENCES [dbo].[Team] ([team_id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK__Matches__team2_i__32E0915F]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK__Matches__tournam__30F848ED] FOREIGN KEY([tournament_id])
REFERENCES [dbo].[Tournament] ([tournament_id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK__Matches__tournam__30F848ED]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Team] FOREIGN KEY([team1_id])
REFERENCES [dbo].[Team] ([team_id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Team]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Team] FOREIGN KEY([team_id])
REFERENCES [dbo].[Team] ([team_id])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Team]
GO
ALTER TABLE [dbo].[Statistics]  WITH CHECK ADD  CONSTRAINT [FK__Match_Sta__match__33D4B598] FOREIGN KEY([matches_id])
REFERENCES [dbo].[Matches] ([matches_id])
GO
ALTER TABLE [dbo].[Statistics] CHECK CONSTRAINT [FK__Match_Sta__match__33D4B598]
GO
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Tournament] FOREIGN KEY([tournament_id])
REFERENCES [dbo].[Tournament] ([tournament_id])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Tournament]
GO
USE [master]
GO
ALTER DATABASE [ProjectPRN231] SET  READ_WRITE 
GO
