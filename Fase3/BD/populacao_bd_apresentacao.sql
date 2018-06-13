USE [BreadSpread]
GO

-- CRIA��O DE CLIENTES

USE [BreadSpread]
GO

INSERT INTO [dbo].[Cliente]
           ([nome]
           ,[dataNasc]
           ,[NIF]
           ,[sexo]
           ,[email]
           ,[rua]
           ,[numPorta]
           ,[codPostal]
           ,[cidade]
           ,[ratingServico]
           ,[contacto]
           ,[freguesia]
           ,[password]
           ,[estadoConta]
           ,[idSub])
     VALUES
           ('cliente1'
           ,'20001021'
           ,123123123
           ,'Masculino'
           ,'a79607@alunos.uminho.pt'
           ,'Rua do Monte de Baixo'
           ,116
           ,'4710-070'
           ,'Braga'
           ,null
           ,'911111111'
           ,'Gualtar'
           ,'202cb962ac59075b964b07152d234b70'
           ,'ativo'
           ,NULL),

		   ('cliente2'
           ,'20001022'
           ,123123123
           ,'Masculino'
           ,'email2'
           ,'Rua do Monte de Baixo'
           ,106
           ,'4710-070'
           ,'Braga'
           ,null
           ,'922222222'
           ,'Gualtar'
           ,'202cb962ac59075b964b07152d234b70'
           ,'ativo'
           ,NULL),

		   ('cliente3'
           ,'20001023'
           ,123123123
           ,'Masculino'
           ,'email3'
           ,'Rua do Monte de Baixo'
           ,133
           ,'4710-070'
           ,'Braga'
           ,null
           ,'933333333'
           ,'Gualtar'
           ,'202cb962ac59075b964b07152d234b70'
           ,'ativo'
           ,NULL),

		   ('cliente4'
           ,'20001024'
           ,123123123
           ,'Masculino'
           ,'email4'
           ,'Rua Padre Casimiro'
           ,30
           ,'4710-070'
           ,'Braga'
           ,null
           ,'944444444'
           ,'Gualtar'
           ,'202cb962ac59075b964b07152d234b70'
           ,'ativo'
           ,NULL)
GO


-- CRIA��O DE FUNCION�RIOS
INSERT INTO [dbo].[Funcionario]
           ([idFunc]
           ,[nome]
           ,[dataNasc]
           ,[contacto]
           ,[rua]
           ,[numPorta]
           ,[codPostal]
           ,[cidade]
           ,[password]
           ,[freguesia]
           ,[estadoConta]
           ,[distribuicao])
     VALUES
           ('A001'
           ,'Francisca Faria'
           ,'19740425'
           ,912345678
           ,'Rua da Padaria'
           ,12
           ,'4710-105'
           ,'Braga'
           ,'202cb962ac59075b964b07152d234b70'
           ,'Gualtar'
           ,'ativo'
           ,0),

		   ('P001'
           ,'Paulo Arag�o'
           ,'19740425'
           ,912345678
           ,'Rua da Padaria'
           ,12
           ,'4710-105'
           ,'Braga'
           ,'202cb962ac59075b964b07152d234b70'
           ,'Gualtar'
           ,'ativo'
           ,0),

		   ('P002'
           ,'Francisco Costa'
           ,'19740425'
           ,912345678
           ,'Rua da Padaria'
           ,12
           ,'4710-105'
           ,'Braga'
           ,'202cb962ac59075b964b07152d234b70'
           ,'Gualtar'
           ,'desativado'
           ,0),

		   ('E001'
           ,'S�rgio Costa'
           ,'19740425'
           ,912345678
           ,'Rua da Padaria'
           ,12
           ,'4710-105'
           ,'Braga'
           ,'202cb962ac59075b964b07152d234b70'
           ,'Gualtar'
           ,'ativo'
           ,1)
GO

-- CRIA��O DE PRODUTOS

INSERT INTO [dbo].[Produto]
           ([designacao]
           ,[ingredientes]
           ,[infoNutricional]
           ,[preco]
           ,[imagem]
           ,[peso])
     VALUES
           ('Bijou de Mistura'
           ,'Farinha'
           ,'2 kcal'
           ,0.18
           ,NULL
           ,20),

		   ('Bola de �gua'
           ,'Farinha'
           ,'2 kcal'
           ,0.28
           ,NULL
           ,20),

		   ('Bola de Centeio'
           ,'Farinha'
           ,'2 kcal'
           ,0.43
           ,NULL
           ,20),

		   ('Bijou de Centeio c/ sementes'
           ,'Farinha'
           ,'2 kcal'
           ,0.50
           ,NULL
           ,20),

		   ('Bola de Mafra'
           ,'Farinha'
           ,'2 kcal'
           ,0.22
           ,NULL
           ,20),

		   ('Bola de Trigo Fino'
           ,'Farinha'
           ,'2 kcal'
           ,0.24
           ,NULL
           ,20),

		   ('Bola R�stica'
           ,'Farinha'
           ,'2 kcal'
           ,0.33
           ,NULL
           ,20),

		   ('Cacete de Massa Fina'
           ,'Farinha'
           ,'2 kcal'
           ,0.28
           ,NULL
           ,20),

		   ('Carca�a'
           ,'Farinha'
           ,'2 kcal'
           ,0.20
           ,NULL
           ,20),

		   ('Carca�a Integral'
           ,'Farinha'
           ,'2 kcal'
           ,0.40
           ,NULL
           ,20),

		   ('P�o Beb�'
           ,'Farinha'
           ,'2 kcal'
           ,0.24
           ,NULL
           ,20)
GO