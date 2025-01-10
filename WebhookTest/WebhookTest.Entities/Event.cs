namespace WebhookTest.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }

        public int GroupId { get; set; }

        public EventGroup Group { get; set; }

        public string Schema { get; set; }

        public string SampleData { get; set; }
    }
}
