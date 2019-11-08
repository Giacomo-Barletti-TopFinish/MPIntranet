CREATE USER MPI IDENTIFIED BY MPI; -- create user with password
GRANT CONNECT,RESOURCE,DBA TO MPI; -- grant DBA,Connect and Resource permission to this user(not sure this is necessary if you give admin option)
GRANT CREATE SESSION TO MPI WITH ADMIN OPTION; --Give admin option to user
GRANT UNLIMITED TABLESPACE TO MPI; -- give unlimited tablespace grant
--GRANT SELECT, INSERT, UPDATE, DELETE ON schema.MPI TO MPI;