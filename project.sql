USE [master]
GO
/****** Object:  Database [ProjectPRN231]    Script Date: 3/14/2023 11:17:00 PM ******/
CREATE DATABASE [ProjectPRN231]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectPRN231', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectPRN231.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectPRN231_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ProjectPRN231_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[Account_]    Script Date: 3/14/2023 11:17:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account_](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](30) NOT NULL,
	[password] [varchar](18) NOT NULL,
	[full_name] [varchar](30) NOT NULL,
	[position] [varchar](40) NOT NULL,
	[created_date] [date] NULL,
	[goal_number] [int] NULL,
	[role_id] [int] NULL,
	[status_id] [int] NULL,
	[team_id] [int] NULL,
 CONSTRAINT [PK__Account___46A222CD2E6F8ACD] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 3/14/2023 11:17:00 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 3/14/2023 11:17:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statistics]    Script Date: 3/14/2023 11:17:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statistics](
	[team1_goal] [int] NOT NULL,
	[team2_goal] [int] NOT NULL,
	[team1_shoot] [int] NOT NULL,
	[team2_shoot] [int] NOT NULL,
	[team1_ontarget] [float] NOT NULL,
	[team2_ontarget] [float] NOT NULL,
	[team1_possession] [float] NOT NULL,
	[team2_possession] [float] NOT NULL,
	[team1_corner] [int] NOT NULL,
	[team2_corner] [int] NOT NULL,
	[player_goal_team1] [int] NULL,
	[player_goal_team2] [int] NULL,
	[matches_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 3/14/2023 11:17:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[status_description] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 3/14/2023 11:17:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[team_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[stadium] [varchar](50) NOT NULL,
	[logo] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[team_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournament]    Script Date: 3/14/2023 11:17:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournament](
	[tournament_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[description] [varchar](70) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tournament_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account_] ON 

INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (1, N'ducpham', N'123', N'Ducky Pham', N'Midfielder', NULL, 1, 1, 1, 2)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (2, N'huytung', N'123', N'Tung Nguyen', N'Head Coach', NULL, NULL, 2, 1, 2)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (3, N'10hag', N'123', N'Eric Ten Hag', N'Head Coach', NULL, NULL, 2, 1, 1)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (4, N'Harry ', N'123', N'Harry Marguie', N'Defenders', NULL, 2, 1, 1, 1)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (5, N'Nunez', N'123', N'Darwin Nunez', N'Forwards', NULL, 1, 1, 1, 3)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (6, N'Klopp', N'123', N'Jurgen Klopp', N'Head Coach', NULL, NULL, 2, 1, 3)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (7, N'kay123', N'123', N'Kay Tran', N'Admin', NULL, NULL, 3, 1, NULL)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (8, N'richa', N'123', N'Cristiano Ronaldo', N'Midfielder', NULL, 4, 1, 1, 11)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (9, N'messi30', N'123', N'Leo Messi', N'Midfielder', NULL, 4, 1, 1, 9)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (13, N'Haaland9', N'123', N'Erling Haaland', N'Midfielder', NULL, 4, 1, 1, 9)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (14, N'kane123', N'123', N'Harry Kane', N'Midfielder', NULL, 3, 1, 1, 5)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (16, N'Osus', N'123', N'Osus Delibra', N'Forwards', NULL, 2, 1, 1, 8)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (18, N'Muller249', N'123', N'Thomas Muller', N'Midfielder', NULL, 4, 1, 1, 7)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (20, N'Ben10', N'123', N'Karim Benzema', N'Midfielder', NULL, 4, 1, 1, 4)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (21, N'Angel11', N'123', N'Angel DiMaria', N'Forwards', NULL, 4, 1, 1, 6)
INSERT [dbo].[Account_] ([account_id], [user_name], [password], [full_name], [position], [created_date], [goal_number], [role_id], [status_id], [team_id]) VALUES (22, N'case19', N'123', N'Casemiro', N'Forwards', NULL, 2, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Account_] OFF
GO
SET IDENTITY_INSERT [dbo].[Matches] ON 

INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (1, CAST(N'2023-03-07T00:00:00.000' AS DateTime), 4, 1, 3)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (2, CAST(N'2023-03-15T00:00:00.000' AS DateTime), 13, 2, 1)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (3, CAST(N'2023-03-10T00:00:00.000' AS DateTime), 9, 2, 4)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (4, CAST(N'2023-03-03T00:00:00.000' AS DateTime), 14, 6, 8)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (5, CAST(N'2023-04-05T00:00:00.000' AS DateTime), 13, 7, 9)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (6, CAST(N'2023-04-12T00:00:00.000' AS DateTime), 13, 5, 8)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (7, CAST(N'2023-04-22T00:00:00.000' AS DateTime), 13, 4, 9)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (8, CAST(N'2023-05-16T00:00:00.000' AS DateTime), 4, 1, 5)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (9, CAST(N'2023-05-25T00:00:00.000' AS DateTime), 4, 3, 5)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (10, CAST(N'2023-05-19T00:00:00.000' AS DateTime), 20, 11, 12)
SET IDENTITY_INSERT [dbo].[Matches] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([role_id], [role_description]) VALUES (1, N'Player')
INSERT [dbo].[Role] ([role_id], [role_description]) VALUES (2, N'Coach')
INSERT [dbo].[Role] ([role_id], [role_description]) VALUES (3, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[Statistics] ([team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [player_goal_team1], [player_goal_team2], [matches_id]) VALUES (1, 2, 12, 14, 30, 76, 50, 70, 3, 2, 1, 4, 2)
INSERT [dbo].[Statistics] ([team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [player_goal_team1], [player_goal_team2], [matches_id]) VALUES (0, 7, 10, 20, 32, 80, 40, 80, 5, 6, NULL, 5, 1)
INSERT [dbo].[Statistics] ([team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [player_goal_team1], [player_goal_team2], [matches_id]) VALUES (5, 4, 24, 17, 40, 24, 52, 37, 4, 8, 1, 20, 3)
INSERT [dbo].[Statistics] ([team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [player_goal_team1], [player_goal_team2], [matches_id]) VALUES (4, 2, 26, 12, 77, 50, 57, 39, 3, 2, 21, 16, 4)
INSERT [dbo].[Statistics] ([team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [player_goal_team1], [player_goal_team2], [matches_id]) VALUES (2, 1, 50, 40, 40, 26, 52, 42, 5, 7, 18, 9, 5)
INSERT [dbo].[Statistics] ([team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [player_goal_team1], [player_goal_team2], [matches_id]) VALUES (0, 0, 40, 60, 70, 68, 50, 48, 8, 5, NULL, NULL, 6)
INSERT [dbo].[Statistics] ([team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [player_goal_team1], [player_goal_team2], [matches_id]) VALUES (4, 2, 50, 30, 50, 40, 67, 59, 5, 3, 20, 9, 7)
INSERT [dbo].[Statistics] ([team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [player_goal_team1], [player_goal_team2], [matches_id]) VALUES (2, 0, 60, 30, 40, 20, 45, 30, 6, 8, 22, NULL, 8)
INSERT [dbo].[Statistics] ([team1_goal], [team2_goal], [team1_shoot], [team2_shoot], [team1_ontarget], [team2_ontarget], [team1_possession], [team2_possession], [team1_corner], [team2_corner], [player_goal_team1], [player_goal_team2], [matches_id]) VALUES (0, 3, 34, 49, 50, 67, 39, 49, 7, 5, NULL, 14, 9)
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([status_id], [status_description]) VALUES (1, N'active')
INSERT [dbo].[Status] ([status_id], [status_description]) VALUES (2, N'inactive')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (1, N'Manchester United', N'Old Trafford', N'ManUTD.jpg')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (2, N'Barcelona', N'Nou Camp', N'Barcelona.png')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (3, N'Liverpool', N'Anfield', N'Liverpool.png')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (4, N'RealMadrid', N'Bernabeu', N'RealMadrid.png')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (5, N'Tottenham', N'Tottenham Hotspur Stadium', N'Tottenham.png')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (6, N'Juventus', N'Juventus Stadium', N'Juventus.png')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (7, N'BayernMunich', N'Allianz Arena', N'BayerMunich.png')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (8, N'Napoli', N'Diego Armando Maradona', N'Napoli.png')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (9, N'ParisSaintGermain', N'Parc des Princes', N'ParisSaintGermain.png')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (11, N'Al Nassr', N'Mrsool Park', N'AlNassr.png')
INSERT [dbo].[Team] ([team_id], [name], [stadium], [logo]) VALUES (12, N'HanoiFC', N'Hang Day Stadium', N'HanoiFC.png')
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET IDENTITY_INSERT [dbo].[Tournament] ON 

INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (4, N'Premier League', N'highest division of the football league system in England')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (9, N'Laliga', N'Spain Football Leagh')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (13, N'ChampionLeague', N'European Football Federation (UEFA) for the top-ranked clubs')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (14, N'Serie A', N'Italia National Football League')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (15, N'Ligue 1', N'France National Football League')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (16, N'Bundesliga', N'German National Football Championship')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (17, N'Roshn Saudi League', N'Saudi Arabia Professional Football League')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (18, N'V-League', N'Vietnam Professional Football League ')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (19, N'Primeira Liga ', N'Portugal Professtional Football League')
INSERT [dbo].[Tournament] ([tournament_id], [name], [description]) VALUES (20, N'AFF Championship', N'Southeast Asian Football Championship')
SET IDENTITY_INSERT [dbo].[Tournament] OFF
GO
ALTER TABLE [dbo].[Account_]  WITH CHECK ADD  CONSTRAINT [FK__Account___role_i__2C3393D0] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([role_id])
GO
ALTER TABLE [dbo].[Account_] CHECK CONSTRAINT [FK__Account___role_i__2C3393D0]
GO
ALTER TABLE [dbo].[Account_]  WITH CHECK ADD  CONSTRAINT [FK__Account___status__2D27B809] FOREIGN KEY([status_id])
REFERENCES [dbo].[Status] ([status_id])
GO
ALTER TABLE [dbo].[Account_] CHECK CONSTRAINT [FK__Account___status__2D27B809]
GO
ALTER TABLE [dbo].[Account_]  WITH CHECK ADD  CONSTRAINT [FK__Account___team_i__2E1BDC42] FOREIGN KEY([team_id])
REFERENCES [dbo].[Team] ([team_id])
GO
ALTER TABLE [dbo].[Account_] CHECK CONSTRAINT [FK__Account___team_i__2E1BDC42]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK__Matches__team_id__31EC6D26] FOREIGN KEY([team1_id])
REFERENCES [dbo].[Team] ([team_id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK__Matches__team_id__31EC6D26]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK__Matches__team2_i__398D8EEE] FOREIGN KEY([team2_id])
REFERENCES [dbo].[Team] ([team_id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK__Matches__team2_i__398D8EEE]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK__Matches__tournam__30F848ED] FOREIGN KEY([tournament_id])
REFERENCES [dbo].[Tournament] ([tournament_id])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK__Matches__tournam__30F848ED]
GO
ALTER TABLE [dbo].[Statistics]  WITH CHECK ADD  CONSTRAINT [FK__Match_Sta__match__33D4B598] FOREIGN KEY([matches_id])
REFERENCES [dbo].[Matches] ([matches_id])
GO
ALTER TABLE [dbo].[Statistics] CHECK CONSTRAINT [FK__Match_Sta__match__33D4B598]
GO
USE [master]
GO
ALTER DATABASE [ProjectPRN231] SET  READ_WRITE 
GO
