USE [Backup]
GO

/****** Object:  Table [dbo].[adrian_testitem]    Script Date: 13/10/2020 11:54:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[adrian_testitem](
	[rowNum] [int] IDENTITY(1,1) NOT NULL,
	[Item_code] [nvarchar](255) NULL,
	[qty] [int] NOT NULL
) ON [PRIMARY]

GO



 begin tran

 begin try  
    
    insert into [Backup].[dbo].[adrian_testitem] (Item_code, qty) values ('COSPADSS',1)
    --qty should be int, this is error
    insert into [Backup].[dbo].[adrian_testitem] (Name,CreateTime,CreatorId) values ('TTHLDR28','2019-03-20','Test')

    insert into [Backup].[dbo].[adrian_testitem] (Name,CreateTime,CreatorId) values ('TTRL12X075','2019-03-20',6)
 end try
 begin catch
    select Error_number() as ErrorNumber,  
           Error_severity() as ErrorSeverity,  
           Error_state() as ErrorState , 
           Error_Procedure() as ErrorProcedure ,
           Error_line() as ErrorLine,  
           Error_message() as ErrorMessage  
    if(@@trancount>0) -- the number of BEGIN TRANSACTION statements that have occurred on the current connection, how many trans now.
       rollback tran  ---rollback all trans, including the first one
 end catch

 if(@@trancount>0)
 commit tran  
 

 select * from [Backup].[dbo].[adrian_testitem]


 /*
 Dirty reads: occurs when a transaction is allowed to read data from a row that has been modified by another running transaction and not yet committed.

 Non-repeatable reads: occurs when, during the course of a transaction, a row is retrieved twice and the values within the row differ between reads.(should be same in one tran)
 
 Phantom reads:occurs when, in the course of a transaction, new rows are added or removed by another transaction to the records being read.(a special case of Non-repeatable reads)
 
 */
 /*
 SET LOCK_TIMEOUT 2000

 set the value of the SET LOCK_TIMEOUT to 2000 milliseconds. 
 This query will wait for 2 seconds to another query to release the lock
 if set to -1, the query has to wait for infinite time for the lock to be released on another query.

 */




