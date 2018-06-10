USE [BreadSpread]
GO

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
           ,'Martinho Aragão'
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
           ,'Sérgio Costa'
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


