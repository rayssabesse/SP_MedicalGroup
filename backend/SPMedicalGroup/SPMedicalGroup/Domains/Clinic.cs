using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedicalGroup.Domains
{
    public partial class Clinic
    {
        public Clinic()
        {
            Doctors = new HashSet<Doctor>();
        }

        public short IdClinic { get; set; }
        public string AddressClinic { get; set; }
        public TimeSpan? OpenClinic { get; set; }
        public TimeSpan? CloseClinic { get; set; }
        public string CnpjClinic { get; set; }
        public string NameClinic { get; set; }
        public string SocialReason { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
