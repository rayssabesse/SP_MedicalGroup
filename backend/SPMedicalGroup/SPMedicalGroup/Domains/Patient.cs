using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedicalGroup.Domains
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public short IdPatient { get; set; }
        public short IdUser { get; set; }
        public string NamePatient { get; set; }
        public DateTime DobPatient { get; set; }
        public string PhonePatient { get; set; }
        public string RgPatient { get; set; }
        public string CpfPatient { get; set; }
        public string AddressPatient { get; set; }

        public virtual Userr IdUserNavigation { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
