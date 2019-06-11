using System.Collections.Generic;
using System.Linq;
using Panda.App.ViewModels.Packages;
using Panda.Models;
using Panda.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace Panda.App.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackageService packageService;

        public PackagesController(IPackageService packageService)
        {
            this.packageService = packageService;
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
                return this.View(allDeliveredPackages.Select(ModelMapper.ProjectTo<AllDeliveredPackagesModelView>).ToList());
            }

            return this.View(new List<AllDeliveredPackagesModelView>());
        }

        [Authorize]
        public IActionResult Pending()
        {
            ICollection<Package> allPendingPackages = this.packageService.GetAllPendingPackages();
            if (allPendingPackages.Count != 0)
            {
                return this.View(allPendingPackages.Select(ModelMapper.ProjectTo<AllPendingPackagesViewModel>).ToList());
            }

            return this.View(new List<AllPendingPackagesViewModel>());
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            this.packageService.Deliver(id);
            return this.Redirect("/Receipts/Index");
        }
    }
}
