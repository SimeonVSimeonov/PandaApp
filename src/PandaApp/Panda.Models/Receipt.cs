using System;

namespace Panda.Models
{
    public class Receipt
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public decimal Fee { get; set; }

        public DateTime Issued { get; set; }

        public string RecipientId { get; set; } = Guid.NewGuid().ToString();
        public User Recipient { get; set; }

        public string PackageId { get; set; } = Guid.NewGuid().ToString();
        public Package Package { get; set; }
    }
}
