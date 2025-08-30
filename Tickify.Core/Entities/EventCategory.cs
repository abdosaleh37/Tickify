namespace Tickify.Core.Entities
{
    public class EventCategory
    {
        public int EventId { get; set; }
        public virtual Event Event { get; set; } = null!;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}