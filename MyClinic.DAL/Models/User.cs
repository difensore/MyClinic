using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinic.DAL.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }
        public double Rating { get; set; }
        public virtual ICollection<Appointment> AppointmentDoctorNavigations { get; } = new List<Appointment>();
        public virtual ICollection<Appointment> AppointmentPatientNavigations { get; } = new List<Appointment>();
    }
}
