USE SPMedicalGroup;
GO

INSERT INTO UserType (UserType)
VALUES ('Administrador'), 
	   ('Médico'), 
	   ('Paciente');
GO
SELECT * FROM UserType;
GO

INSERT INTO Userr (idUserType, emailUser, passwordUser)
VALUES (1, 'adm@spmedicalgroup.com', 'adm123'),
	   (1, 'luanafigureido@gmail.com', 'luanafiguereido123'),
	   (2, 'enricogomes@hotmail.com', 'enricogomes123'),
	   (2, 'marciobarbosa@yahoo.com.br', 'marciobarbosa123'),
	   (2, 'raquelsilva@outlook.com', 'raquelsilva123'),
	   (3, 'julianapereira@gmail.com', 'julianapereira123'),
	   (3, 'sofiarodrigues@hotmail.com', 'sofiarodrigues123'),
	   (3, 'rosamariaoliveira@outlook.com', 'rosamariaoliveira123'),
	   (3, 'lucasmedeiros@yahoo.com.br', 'lucasmedeiros123'),
	   (3, 'pedrosantana@gmail.com', 'pedrosantana123'),
	   (3, 'amandagomes@outlook.com', 'amandagomes123');
GO
SELECT * FROM Userr;
GO

INSERT INTO Patient (idUser, namePatient, dobPatient, phonePatient, rgPatient, cpfPatient, addressPatient)
VALUES (2, 'Juliana Pereira', '24/07/1966', '11 985761320', '34774903-3', '34870691990', 'Rua 8, 331 - Gilberto Mestrinho, São Paulo - SP, 69086-470'),
	   (3, 'Sofia Rodrigues', '22/07/1947', '11 997795897', '15685073-4', '62338470524', 'Rua Salinopólis, 134 - Vila Permanente, São Paulo - SP, 68455-741'),
	   (4, 'Rosamaria Oliveria', '09/02/1995', '11 989678879', '28423052-2', '29709388045', 'Rua Lageado, 495 - Vila Seabra, São Paulo - SP, 08180-180'),
	   (5, 'Lucas Medeiros', '01/05/1973', '11 28259897', '26654726-6', '64448825833', 'Praça da Bandeira, 348 - Centro, São Paulo - SP, 01007-020'),
	   (6, 'Pedro Santana', '04/03/1988', '11 994139620', '32144309-3', '12409171800', 'Rua Paulino Alves Escudeiro, 325 - Guacuri, São Paulo - SP, 04475-350'),
	   (7, 'Amanda Gomes', '11/12/2000', '11 98443-2251', '32429414-1', '28342304809', 'Rua Raimundo Mattiuzo, 187 - Vila Araguaia, São Paulo - SP, 03735-000');
GO
SELECT * FROM Patient;
GO

INSERT INTO DoctorJob (nameDoctorJob)
VALUES ('Exames Laboratoriais'),
	   ('Checkup'),
	   ('Odontologia'),
	   ('Internação'),
	   ('Espirometria'),
	   ('Cirurgias'),
	   ('Vacinação'),
	   ('Fisioterapia');
GO
SELECT * FROM DoctorJob;
GO

INSERT INTO Clinic (addressClinic, openClinic, closeClinic, cnpjClinic, nameClinic, socialReason)
VALUES ('Rua Alameda Barão de Limeira, 537 - Santa Cecília, São Paulo - SP, 01202-001', '07:00', '19:00', '03.774.819/0001-02', 'Clínica SENAI de Informática', 'SP Medical Group'),
	   ('Rua Monsenhor Andrade, 298 - Brás, São Paulo - SP, 03008-000', '07:00', '19:00', '03.774.819/0001-03', 'Clínica SENAI Roberto Simonsen', 'SP Medical Group');
GO
SELECT * FROM Clinic;
GO

INSERT INTO Doctor (idUser, idDoctorJob, idClinic, crmDoctor, nameDoctor)
VALUES (8, 3, 1, '23875-SP', 'Enrico Gomes'),
	   (9, 7, 1, '56123-SP', 'Marcio Barbosa'),
	   (10, 8, 1, '54321-SP', 'Raquel Silva');
GO
SELECT * FROM Doctor;
GO

INSERT INTO Situation(typeSituation)
VALUES ('Realizada'),
	   ('Agendada'),
	   ('Cancelada');
GO
SELECT * FROM Situation;
GO

INSERT INTO Appointment (idPatient, idDoctor, idSituation, dateAppointment)
VALUES (2, 1, 1, '15/06/2021'),
	   (5, 2, 2, '14/12/2021'),
	   (3, 3, 3, '18/11/2021'),
	   (4, 1, 1, '17/12/2021'),
	   (6, 2, 1, '31/10/2021'),
	   (1, 3, 1, '02/11/2021');
GO
SELECT * FROM Appointment;
GO