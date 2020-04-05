using System.ComponentModel.DataAnnotations;

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
