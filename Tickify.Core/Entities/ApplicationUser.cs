using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Tickify.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; } = null!;
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Event> OrganizedEvents { get; set; } = new List<Event>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
