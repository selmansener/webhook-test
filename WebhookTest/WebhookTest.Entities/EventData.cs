namespace WebhookTest.Entities
{
    public class EventData : BaseEntity
    {
        public string Data { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public int? WebhookStateId { get; set; }

        public WebhookState WebhookState { get; set; }

    }
}
