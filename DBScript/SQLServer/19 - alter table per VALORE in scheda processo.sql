USE MPI

alter table SPVALORISCHEDE ALTER COLUMN VALORET NVARCHAR(60) NULL
alter table SPVALORISCHEDE_LOG ALTER COLUMN VALORET NVARCHAR(60) NULL

USE MPI_TEST

alter table SPVALORISCHEDE ALTER COLUMN VALORET NVARCHAR(60) NULL
alter table SPVALORISCHEDE_LOG ALTER COLUMN VALORET NVARCHAR(60) NULL

