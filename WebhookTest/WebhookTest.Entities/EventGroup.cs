namespace WebhookTest.Entities
{
    public class EventGroup : BaseEntity
    {
        public string Name { get; set; }

        public List<Event> Events { get; set; }
    }
}
