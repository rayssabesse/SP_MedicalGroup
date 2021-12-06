USE SPMedicalGroup;
GO

SELECT * FROM UserType;
GO

SELECT * FROM Userr;
GO

SELECT * FROM Patient;
GO

SELECT * FROM DoctorJob;
GO

SELECT * FROM Clinic;
GO

SELECT * FROM Doctor;
GO

SELECT * FROM Situation;
GO

SELECT * FROM Appointment;
GO

SELECT namePatient[Paciente], phonePatient[Telefone do Paciente], addressPatient [Endereço do Paciente], nameDoctor [Médico], nameDoctorJob [Especialidade] FROM Appointment
LEFT JOIN Patient
ON Patient.idPatient = Appointment.idPatient
LEFT JOIN Doctor
ON Doctor.idDoctor = Appointment.idDoctor
LEFT JOIN DoctorJob
ON DoctorJob.idDoctorJob = Doctor.idDoctorJob
GO

SELECT namePatient[Paciente], phonePatient[Telefone do Paciente], addressPatient [Endereço do Paciente], nameDoctor [Médico], nameDoctorJob [Especialidade] FROM Appointment
LEFT JOIN Patient
ON Patient.idPatient = Appointment.idPatient
LEFT JOIN Doctor
ON Doctor.idDoctor = Appointment.idDoctor
LEFT JOIN DoctorJob
ON DoctorJob.idDoctorJob = Doctor.idDoctorJob
WHERE Patient.idPatient = 6
GO





