/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[first_name]
      ,[last_name]
      ,[NIC]
      ,[cource_id]
      ,[batch_id]
      ,[phone]
  FROM [SystemManage].[dbo].[Registration]