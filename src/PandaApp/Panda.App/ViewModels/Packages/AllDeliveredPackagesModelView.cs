using Panda.Models;
using Panda.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.App.ViewModels.Packages
{
    public class AllDeliveredPackagesModelView
    {
       
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string Status { get; set; }

        public string RecipientName { get; set; }
    }
}
