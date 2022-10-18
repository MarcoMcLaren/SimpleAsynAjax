Use [Master] 
GO 
If Exists (Select * from sys.databases where name = 'ExampleDatabase') 
DROP DATABASE [ExampleDatabase] 
GO 
Create Database [ExampleDatabase] 
GO
Use [ExampleDatabase] 
GO

CREATE TABLE [dbo].[ExampleTable]
( 
[SimpleID] [int] Identity (1,1) Primary Key Not Null,
[SimpleAttribute] [nvarchar] (MAX) not null,) 
GO

SET IDENTITY_INSERT [dbo].[ExampleTable]  ON

insert [dbo].[ExampleTable] ([SimpleID], [SimpleAttribute]) VALUES (1, 'Attribute Data 01')
insert [dbo].[ExampleTable] ([SimpleID], [SimpleAttribute]) VALUES (2, 'Attribute Data 02')
insert [dbo].[ExampleTable] ([SimpleID], [SimpleAttribute]) VALUES (3, 'Attribute Data 03')
insert [dbo].[ExampleTable] ([SimpleID], [SimpleAttribute]) VALUES (4, 'Attribute Data 04')

SET IDENTITY_INSERT [dbo].[ExampleTable]  OFF