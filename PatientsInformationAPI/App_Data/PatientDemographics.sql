--Step1 -- Create Database
CREATE DATABASE PatientsDemographics;

--Step2 -- Create table
IF object_id('Patient', 'U') is null
BEGIN
USE PatientsDemographics
CREATE TABLE Patient (
    ID int IDENTITY(1,1) NOT NULL,
    ForeName varchar(255) NOT NULL,
    SurName varchar(255) NOT NULL,
    DateOfBirth varchar(255) null,
	Gender varchar(10) NOT NULL,
	HomeNumber varchar(255) NULL,
	WorkNumber varchar(255) NULL,
	MobileNumber varchar(255) NULL,
    PRIMARY KEY (ID)
);
END

--Step2 -- Create table
IF object_id('PatientsInformation', 'U') is null
BEGIN
USE PatientsDemographics
CREATE TABLE PatientsInformation (
    ID int IDENTITY(1,1) NOT NULL,
    PatientsInformationXML nvarchar(MAX) NOT NULL,    
    PRIMARY KEY (ID)
);
END

--select * from Patient

--insert into Patient
--select 'ABC', 'CBA', '10/01/1950', 'Male', NULL, NULL, NULL

--delete from Patient

--select * from PatientsInformation

--insert into PatientsInformation
--select '<?xml version="1.0" encoding="utf-16"?>
--<PatientDataModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
--  <ForeName>uuopuou</ForeName>
--  <SurName>rwtrw</SurName>
--  <DateOfBirth>10/10/1998</DateOfBirth>
--  <Gender>Male</Gender>
--  <HomeNumber>5356353</HomeNumber>
--  <WorkNumber>5635</WorkNumber>
--  <MobileNumber>65353</MobileNumber>
--</PatientDataModel>'