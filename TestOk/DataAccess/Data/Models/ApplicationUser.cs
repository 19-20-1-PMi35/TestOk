using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Faculty { get; set; }

        public string Group { get; set; }

        public string GradebookNumber { get; set; }        
    }
}
