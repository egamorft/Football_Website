USE [master]
GO
/****** Object:  Database [ProjectPRN231]    Script Date: 2023-03-19 16:07:00 ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 2023-03-19 16:07:00 ******/
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
/****** Object:  Table [dbo].[Matches]    Script Date: 2023-03-19 16:07:00 ******/
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
/****** Object:  Table [dbo].[Players]    Script Date: 2023-03-19 16:07:00 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 2023-03-19 16:07:00 ******/
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
/****** Object:  Table [dbo].[Statistics]    Script Date: 2023-03-19 16:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statistics](
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
	[player_goal_team1] [int] NOT NULL,
	[player_goal_team2] [int] NOT NULL,
	[matches_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 2023-03-19 16:07:00 ******/
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
/****** Object:  Table [dbo].[Team]    Script Date: 2023-03-19 16:07:00 ******/
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
/****** Object:  Table [dbo].[Tournament]    Script Date: 2023-03-19 16:07:00 ******/
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
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (2, N'tung', N'123', N'tung huy ', CAST(N'2023-03-16T16:03:32.790' AS DateTime), 1, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (3, N'duc', N'123', N'minh', CAST(N'2023-03-16T16:03:54.150' AS DateTime), 1, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (5, N'minhduc', N'123', N'minh duc', CAST(N'2023-03-16T16:04:21.443' AS DateTime), 1, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (7, N'tung1', N'123', N'tung1111', CAST(N'2023-03-16T16:07:15.270' AS DateTime), 2, 2)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (8, N'duc1', N'123', N'duc1111', CAST(N'2023-03-16T16:07:26.363' AS DateTime), 2, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (9, N'admin', N'123', N'admin', CAST(N'2023-03-16T16:07:37.600' AS DateTime), 2, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (10, N'testPost', N'123', N'hehe', CAST(N'2023-03-17T09:07:01.673' AS DateTime), 1, 1)
INSERT [dbo].[Account] ([account_id], [user_name], [password], [full_name], [created_date], [role_id], [status_id]) VALUES (11, N'hahaa', N'123', N'hehee', CAST(N'2023-03-17T09:08:58.647' AS DateTime), 1, 2)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Matches] ON 

INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (1, CAST(N'2023-03-07T00:00:00.000' AS DateTime), 4, 1, 3)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (3, CAST(N'2023-03-30T23:30:00.000' AS DateTime), 4, 4, 5)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (5, CAST(N'2023-03-31T21:00:00.000' AS DateTime), 4, 6, 7)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (6, CAST(N'2023-03-31T21:00:00.000' AS DateTime), 4, 8, 9)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (7, CAST(N'2023-03-31T21:00:00.000' AS DateTime), 4, 10, 11)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (8, CAST(N'2023-03-31T21:00:00.000' AS DateTime), 4, 12, 13)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (9, CAST(N'2023-03-31T21:00:00.000' AS DateTime), 4, 14, 15)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (10, CAST(N'2023-03-31T21:00:00.000' AS DateTime), 4, 16, 17)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (11, CAST(N'2023-03-31T21:00:00.000' AS DateTime), 4, 18, 19)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (12, CAST(N'2023-03-31T21:00:00.000' AS DateTime), 4, 20, 21)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (13, CAST(N'2023-03-19T00:00:00.000' AS DateTime), 9, 2, 22)
INSERT [dbo].[Matches] ([matches_id], [datetime], [tournament_id], [team1_id], [team2_id]) VALUES (14, CAST(N'2023-03-19T00:00:00.000' AS DateTime), 4, 1, 4)
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
SET IDENTITY_INSERT [dbo].[Players] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([role_id], [role_description]) VALUES (1, N'User')
INSERT [dbo].[Role] ([role_id], [role_description]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[Role] OFF
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
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_role_id]  DEFAULT ((1)) FOR [role_id]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_status_id]  DEFAULT ((1)) FOR [status_id]
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
