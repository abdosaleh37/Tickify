using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Tickify.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public DateTime? RegistrationDate { get; set; }

        public ICollection<Event> OrganizedEvents { get; set; } = new List<Event>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
