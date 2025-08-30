using System;
using Tickify.Core.Entities.Enums;

namespace Tickify.Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; } = null!;
        public string? FailureReason { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        public int UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
