USE [master]
GO
/****** Object:  Database [FitnessTracker]    Script Date: 4/18/2014 3:36:25 PM ******/
CREATE DATABASE [FitnessTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FitnessTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\FitnessTracker.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FitnessTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\FitnessTracker_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FitnessTracker] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FitnessTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FitnessTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FitnessTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FitnessTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FitnessTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FitnessTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [FitnessTracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FitnessTracker] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FitnessTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FitnessTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FitnessTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FitnessTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FitnessTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FitnessTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FitnessTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FitnessTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FitnessTracker] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FitnessTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FitnessTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FitnessTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FitnessTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FitnessTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FitnessTracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FitnessTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FitnessTracker] SET RECOVERY FULL 
GO
ALTER DATABASE [FitnessTracker] SET  MULTI_USER 
GO
ALTER DATABASE [FitnessTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FitnessTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FitnessTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FitnessTracker] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'FitnessTracker', N'ON'
GO
USE [FitnessTracker]
GO
/****** Object:  StoredProcedure [dbo].[AddExercise]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddExercise] 
	@ExerciseName VARCHAR(25)
AS
BEGIN
	INSERT INTO Exercises
	VALUES(@ExerciseName)
	SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [dbo].[AddWorkout]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddWorkout]
	@UserID INT,
	@Date DATETIME,
	@ExerciseID INT,
	@NumberSets INT,
	@Amount INT
AS
BEGIN
	INSERT INTO Workout
	VALUES(@UserID, @ExerciseID, @NumberSets, @Amount, @Date, 0)
	SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUser]
	@Email VARCHAR(256),
	@Password VARCHAR (50),
	@FirstName VARCHAR (25),
	@LastName VARCHAR (25)
AS
BEGIN
	INSERT INTO Users
	VALUES (@Email, @Password, @FirstName, @LastName)
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteWorkout]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteWorkout]
	@ID INT
AS
BEGIN
	DELETE FROM Workout
	WHERE ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[ExistingUser]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ExistingUser]
	@Email VARCHAR(256)
AS
BEGIN
	SELECT ID FROM Users
	Where Email = @Email
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllExercises]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllExercises] 

AS
BEGIN
	SELECT * FROM Exercises
END


GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllUsers]

AS
BEGIN
	SELECT * FROM Users
END

GO
/****** Object:  StoredProcedure [dbo].[GetExerciseByID]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetExerciseByID]
	@ID INT
AS
BEGIN
	SELECT * FROM Exercises
	WHERE ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUser]
	@Email VARCHAR(256)
AS
BEGIN
	SELECT * FROM Users
	WHERE Email = @Email
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByID]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserByID]
	@ID INT 
AS
BEGIN
	SELECT * FROM Users
	WHERE ID = @ID
END


GO
/****** Object:  StoredProcedure [dbo].[GetUserID]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserID]
	@Email VARCHAR(256),
	@Password VARCHAR(25)
AS
BEGIN
	SELECT ID FROM Users
	WHERE Email = @Email
	AND Password = @Password
END


GO
/****** Object:  StoredProcedure [dbo].[GetUserMaxPullups]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserMaxPullups]
	@UserID INT
AS
BEGIN
	SELECT Pullups.PullupMax, Pullups.Date FROM Pullups
	JOIN Stats ON Pullups.ID = Stats.Pullups
	WHERE Stats.UserID = @UserID
	ORDER BY Pullups.Date
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserMaxPushups]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserMaxPushups]
	@UserID INT
AS
BEGIN
	SELECT PushUps.PushUpMax, PushUps.Date FROM PushUps
	JOIN Stats ON PushUps.ID = Stats.PushUps
	WHERE Stats.UserID = @UserID
	ORDER BY PushUps.Date
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserMaxSitups]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserMaxSitups]
	@UserID INT
AS
BEGIN
	SELECT Situps.SitupMax, Situps.Date FROM Situps
	JOIN Stats ON Situps.ID = Stats.Situps
	WHERE Stats.UserID = @UserID
	ORDER BY Situps.Date
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserWeights]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserWeights]
	@UserID INT
AS
BEGIN
	SELECT Weight.Weight, Weight.Date FROM Weight
	JOIN Stats ON Weight.ID = Stats.Weight
	WHERE Stats.UserID = @UserID
	ORDER BY Weight.Date
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserWorkout]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUserWorkout]
	@UserID INT,
	@Date DATETIME
AS
BEGIN
	SELECT * FROM Workout
	WHERE UserID = @UserID
	AND PlanDate = @Date
END


GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Login]
	@Email VARCHAR(256),
	@Password VARCHAR (50)
AS
BEGIN
	SELECT ID FROM Users
	WHERE Email = @Email
	AND Password = @Password
END

GO
/****** Object:  StoredProcedure [dbo].[MarkWorkout]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MarkWorkout] 
	@ID INT,
	@Complete BIT
AS
BEGIN
	UPDATE Workout
	SET Complete = @Complete
	WHERE ID = @ID
END

GO
/****** Object:  Table [dbo].[Exercises]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Exercises](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Exercise] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PullUps]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PullUps](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PullUpMax] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PushUps]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PushUps](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PushUpMax] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SitUps]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SitUps](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SitUpMax] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stats]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stats](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Weight] [int] NULL,
	[PushUps] [int] NULL,
	[SitUps] [int] NULL,
	[PullUps] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Weight]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weight](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Weight] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Workout]    Script Date: 4/18/2014 3:36:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workout](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ExerciseID] [int] NOT NULL,
	[NumberSets] [int] NULL,
	[Amount] [int] NULL,
	[PlanDate] [datetime] NOT NULL,
	[Complete] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PullUps] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[PushUps] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[SitUps] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Weight] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Workout] ADD  CONSTRAINT [DF_Workout_Complete]  DEFAULT ((0)) FOR [Complete]
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([PullUps])
REFERENCES [dbo].[PullUps] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([PullUps])
REFERENCES [dbo].[PullUps] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([PushUps])
REFERENCES [dbo].[PushUps] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([PushUps])
REFERENCES [dbo].[PushUps] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([SitUps])
REFERENCES [dbo].[SitUps] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([SitUps])
REFERENCES [dbo].[SitUps] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([Weight])
REFERENCES [dbo].[Weight] ([ID])
GO
ALTER TABLE [dbo].[Stats]  WITH CHECK ADD FOREIGN KEY([Weight])
REFERENCES [dbo].[Weight] ([ID])
GO
ALTER TABLE [dbo].[Workout]  WITH CHECK ADD FOREIGN KEY([ExerciseID])
REFERENCES [dbo].[Exercises] ([ID])
GO
ALTER TABLE [dbo].[Workout]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
USE [master]
GO
ALTER DATABASE [FitnessTracker] SET  READ_WRITE 
GO
