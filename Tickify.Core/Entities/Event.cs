using System;
using System.Collections.Generic;

namespace Tickify.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = null!;
        public int Capacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int OrganizerId { get; set; }
        public virtual ApplicationUser Organizer { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
    }
}
