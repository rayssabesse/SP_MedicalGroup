using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedicalGroup.Domains
{
    public partial class Userr
    {
        public short IdUser { get; set; }
        public short IdUserType { get; set; }
        public string EmailUser { get; set; }
        public string PasswordUser { get; set; }

        public virtual UserType IdUserTypeNavigation { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
