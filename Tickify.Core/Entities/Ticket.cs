using System;
using System.Collections.Generic;
using Tickify.Core.Entities.Enums;

namespace Tickify.Core.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; } = null!;
        public decimal Price { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UsedAt { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; } = null!;

        public int? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public int? PaymentId { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}
