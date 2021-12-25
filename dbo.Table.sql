CREATE TABLE [dbo].[Users]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Фамилия] NVARCHAR(50) NOT NULL, 
    [Имя] NVARCHAR(50) NOT NULL, 
    [Отчество] NVARCHAR(50) NULL, 
    [Телефон] NVARCHAR(50) NOT NULL 
)
