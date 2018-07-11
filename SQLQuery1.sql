USE MASTER
GO

DROP DATABASE ITBAM
GO

create database itbam
go

use itbam 
go

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produto](
    [Id] [int] IDENTITY,
    [Nome] [nvarchar](50) NULL,
	[Preco] [nvarchar](50) NULL,
    [Categoria] [nvarchar](50) NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
 (
    [Id] ASC
 )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = 
 ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 ) ON [PRIMARY]

 GO

 --CREATE TABLE [dbo].[Categoria](
 --   [Id] [int],
 --   [Nome] [nvarchar](50) NULL,
 --CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
 --(
 --   [Id] ASC
 --)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = 
 --ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
 --) ON [PRIMARY]

 --GO

--ALTER TABLE Produto
--ADD FOREIGN KEY (IdCategoria) REFERENCES Categoria(Id)

--GO

--insert into Categoria Values (1, 'Esporte')

--insert into Categoria Values (2, 'Casual')

--insert into Categoria Values (3, 'Social')

--insert into Categoria Values (4, 'Gala')

--insert into Categoria Values (5, 'Lazer')

--select * from categoria;


USE itbam
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE SP_InserirProduto
    @Nome Varchar(50),
    @Preco Varchar(50),
	@Categoria Varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
    Insert into Produto(
           [Nome]
           ,[Preco]
		   ,[Categoria]
           )
 Values (@Nome, @Preco, @Categoria)
END
GO

exec SP_InserirProduto 'Helisam', '2,50', 'Esporte'

--insert into produto(Nome, Preco, Categoria) values('Helisam', '2,50', 'Esporte')

select * from Produto