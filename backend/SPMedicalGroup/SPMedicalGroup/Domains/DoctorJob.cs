using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedicalGroup.Domains
{
    public partial class DoctorJob
    {
        public DoctorJob()
        {
            Doctors = new HashSet<Doctor>();
        }

        public short IdDoctorJob { get; set; }
        public string NameDoctorJob { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
