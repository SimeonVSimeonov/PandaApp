using SIS.MvcFramework.Attributes.Validation;

namespace Panda.App.ViewModels.Packages
{
    public class PackageCreateInputModel
    {
        private const string NameErrorMessage = "Invalid length! Name must be between 5 and 20 symbols!";

        [RequiredSis]
        [StringLengthSis(3, 30, NameErrorMessage)]
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string RecipientName { get; set; }

    }
}
