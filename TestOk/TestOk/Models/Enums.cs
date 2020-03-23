using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestOk.Models
{
    public enum RolesEnum
    {
        [Display(Name = "Student")]
        Student = 0,

        [Display(Name = "Teacher")]
        Teacher = 1
    }
}
