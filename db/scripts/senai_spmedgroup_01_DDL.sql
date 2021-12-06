CREATE DATABASE SPMedicalGroup;
GO

USE SPMedicalGroup;
GO

CREATE TABLE UserType(
	idUserType smallint PRIMARY KEY IDENTITY(1,1),
	UserType varchar(20) unique,
);
GO

CREATE TABLE Userr(
	idUser smallint PRIMARY KEY IDENTITY(1,1),
	idUserType smallint FOREIGN KEY REFERENCES UserType(idUserType) not null,
	emailUser varchar(100) unique not null,
	passwordUser varchar(50) not null,
);
GO

CREATE TABLE Patient (
	idPatient smallint PRIMARY KEY IDENTITY(1,1),
	idUser smallint FOREIGN KEY REFERENCES Userr(idUser) unique not null,
	namePatient varchar(75) not null,
	dobPatient date not null,
	phonePatient varchar(15),
	rgPatient varchar(10) unique not null,
	cpfPatient varchar(14) unique not null,
	addressPatient varchar(100),
);
GO

CREATE TABLE DoctorJob (
	idDoctorJob smallint PRIMARY KEY IDENTITY(1,1),
	nameDoctorJob varchar(100) unique not null,
);
GO

CREATE TABLE Clinic (
	idClinic smallint PRIMARY KEY IDENTITY(1,1),
	addressClinic varchar(100) not null,
	openClinic time,
	closeClinic time,
	cnpjClinic char(20) unique not null,
	nameClinic varchar(100) not null,
	socialReason varchar(50) not null,
);
GO

CREATE TABLE Doctor (
	idDoctor smallint PRIMARY KEY IDENTITY(1,1),
	idUser smallint FOREIGN KEY REFERENCES Userr(idUser) unique not null,
	idDoctorJob smallint FOREIGN KEY REFERENCES DoctorJob(idDoctorJob) not null,
	idClinic smallint FOREIGN KEY REFERENCES Clinic(idCLinic) not null,
	crmDoctor varchar(10) unique not null,
    nameDoctor varchar(75) not null,
);
GO

CREATE TABLE Situation (
	idSituation smallint PRIMARY KEY IDENTITY(1,1),
	typeSituation varchar(50) not null,
);
GO

CREATE TABLE Appointment (
	idAppointment smallint PRIMARY KEY IDENTITY(1,1), 
	idPatient smallint FOREIGN KEY REFERENCES Patient(idPatient) not null,
	idDoctor smallint FOREIGN KEY REFERENCES Doctor(idDoctor) not null,
	idSituation smallint FOREIGN KEY REFERENCES Situation(idSituation) not null,
	dateAppointment date not null,
	descriptionAppointment varchar(1000),
);
GO

