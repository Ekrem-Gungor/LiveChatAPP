using DevBudy.DOMAIN.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevBudy.DOMAIN.Entities.Concretes
{
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public Gender Gender { get; set; }

        // Relational Properties

        public virtual AppUser AppUser { get; set; }
    }
}
