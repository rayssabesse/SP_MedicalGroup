using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedicalGroup.Domains
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public short IdDoctor { get; set; }
        public short IdUser { get; set; }
        public short IdDoctorJob { get; set; }
        public short IdClinic { get; set; }
        public string CrmDoctor { get; set; }
        public string NameDoctor { get; set; }

        public virtual Clinic IdClinicNavigation { get; set; }
        public virtual DoctorJob IdDoctorJobNavigation { get; set; }
        public virtual Userr IdUserNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
