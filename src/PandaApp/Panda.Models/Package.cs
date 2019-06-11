using Panda.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Panda.Models
{
    public class Package
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Range(5, 20)]
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        [Required]
        public string RecipientId { get; set; } = Guid.NewGuid().ToString();
        public User Recipient { get; set; } //virtual  ???
    }
}
