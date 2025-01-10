using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebhookTest.Entities
{
    public class WebhookHeader : BaseEntity
    {
        public int WebhookId { get; set; }

        public Webhook Webhook { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
