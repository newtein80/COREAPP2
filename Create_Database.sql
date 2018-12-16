/*
USE master;
GO
DROP DATABASE SMVN3
*/

/*
0.데이터베이스 생성
*/
USE master;
GO

CREATE DATABASE COREAPP2
ON PRIMARY    /* 기본 파일 그룹(Primary Filegroup) */
    (NAME = 'COREAPP2',
        FILENAME = 'D:\COREAPP_test_db\COREAPP2.mdf',
        SIZE = 25MB,
        FILEGROWTH = 1MB),--FILEGROWTH = 1%),
        
FILEGROUP SMVN3_DATA    /* 사용자 정의 파일 그룹(MyNewFileGroup Filegroup) */
    (NAME = 'COREAPP2_DATA',
        FILENAME = 'D:\COREAPP_test_db\COREAPP_DATA2.ndf',
        SIZE = 500MB,
        FILEGROWTH = 1MB)

LOG ON    /* 트랜잭션 로그 파일(Transction Log File) */
    (NAME = 'COREAPP2_LOG',
        FILENAME = 'D:\COREAPP_test_db\COREAPP_LOG2.ldf',
        SIZE = 25MB,
        MAXSIZE = 2048MB,
        FILEGROWTH = 10MB);
