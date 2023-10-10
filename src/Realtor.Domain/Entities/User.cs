using System.ComponentModel.DataAnnotations;
using Realtor.Domain.Commons;
using Realtor.Domain.Enums;

namespace Realtor.Domain.Entities;

public class User:Auditable
{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Password { get; set; }
        public Role Role { get; set; }

        public long UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
}