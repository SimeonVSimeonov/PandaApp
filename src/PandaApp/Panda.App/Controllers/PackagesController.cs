using Panda.App.ViewModels.Packages;
using Panda.Data;
using Panda.Models;
using Panda.Models.Enums;
using Panda.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Collections.Generic;
using System.Linq;

namespace Panda.App.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackageService packageService;
        private readonly PandaAppDBContext context;

        public PackagesController(IPackageService packageService, PandaAppDBContext context)
        {
            this.packageService = packageService;
            this.context = context;
        }

        [Authorize]
        public IActionResult Create()
        {
            ICollection<User> allRecipients = this.packageService.GetAllRecipients();

            if (allRecipients.Count != 0)
            {
                return this.View(allRecipients.Select(x => x.Username).ToList());
            }

            return this.View(new List<string>());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(PackageCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            this.packageService.Create(model.Description, model.Weight, model.ShippingAddress, model.RecipientName);
            return this.Redirect("/Packages/Pending");
        }


        [Authorize]
        public IActionResult Delivered()
        {
            ICollection<Package> allDeliveredPackages = this.packageService.GetAllDeliveredPackages();


            if (allDeliveredPackages.Count != 0)
            {
                var deliveredView = this.context.Packages.Select(x =>
                new AllDeliveredPackagesModelView
                {
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    Status = Status.Delivered.ToString(),
                    RecipientName = x.Recipient.Username,
                    Weight = x.Weight
                }).ToList();

                return this.View(deliveredView);
            }

            return this.View(new List<AllDeliveredPackagesModelView>());
        }

        [Authorize]
        public IActionResult Pending()
        {
            var packages = this.packageService.GetAllPendingPackages()
                .Select(x => new AllPendingPackagesViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username,
                }).ToList();
            return this.View(packages);
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            this.packageService.Deliver(id);
            return this.Redirect("/Receipts/Index");
        }
    }
}
