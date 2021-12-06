using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedicalGroup.Domains
{
    public partial class Situation
    {
        public Situation()
        {
            Appointments = new HashSet<Appointment>();
        }

        public short IdSituation { get; set; }
        public string TypeSituation { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
