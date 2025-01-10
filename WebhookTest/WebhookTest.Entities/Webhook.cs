using WebhookTest.Entities.Enums;

namespace WebhookTest.Entities
{
    public class Webhook : BaseEntity
    {
        public string Name { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public string Url { get; set; }

        public List<WebhookHeader> Headers { get; set; }

        public MethodType MethodType { get; set; }

        public bool IsActive { get; set; }

        public List<WebhookState> WebhookStates { get; set; }
    }
}
