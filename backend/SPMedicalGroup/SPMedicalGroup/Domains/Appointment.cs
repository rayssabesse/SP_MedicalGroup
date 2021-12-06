using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedicalGroup.Domains
{
    public partial class Appointment
    {
        public short IdAppointment { get; set; }
        public short IdPatient { get; set; }
        public short IdDoctor { get; set; }
        public short IdSituation { get; set; }
        public DateTime DateAppointment { get; set; }
        public string DescriptionAppointment { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Patient IdPatientNavigation { get; set; }
        public virtual Situation IdSituationNavigation { get; set; }
    }
}
