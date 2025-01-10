using WebhookTest.Entities.Enums;

namespace WebhookTest.Entities
{
    public class WebhookState : BaseEntity
    {
        public WebhookDeliveryStatus DeliveryStatus { get; set; }

        public int EventDataId { get; set; }

        public EventData Data { get; set; }

        public int WebhookId { get; set; }

        public Webhook Webhook { get; set; }
    }
}
