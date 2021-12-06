using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedicalGroup.Domains
{
    public partial class UserType
    {
        public UserType()
        {
            Userrs = new HashSet<Userr>();
        }

        public short IdUserType { get; set; }
        public string UserType1 { get; set; }

        public virtual ICollection<Userr> Userrs { get; set; }
    }
}
