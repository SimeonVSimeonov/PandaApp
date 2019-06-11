using Panda.Data;
using Panda.Models;
using Panda.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Panda.Services
{
    public class PackageService : IPackageService
    {
        private readonly PandaAppDBContext context;
        private readonly IReceiptServices receiptServices;

        public PackageService(PandaAppDBContext pandaAppDBContext, IReceiptServices receiptServices)
        {
            this.context = pandaAppDBContext;
            this.receiptServices = receiptServices;
        }

        public void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.context.Users.Where(x => x.Username == recipientName).Select(x => x.Id).FirstOrDefault();
            if (userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = Status.Pending,
                ShippingAddress = shippingAddress,
                RecipientId = userId,
            };

            this.context.Packages.Add(package);
            this.context.SaveChanges();
        }

        public ICollection<Package> GetAllDeliveredPackages()
        {
            return context.Packages.Where(x => x.Status == Status.Delivered).ToList();
        }

        public ICollection<Package> GetAllPendingPackages()
        {
            return context.Packages.Where(x => x.Status == Status.Pending).ToList();
        }

        public ICollection<User> GetAllRecipients()
        {
            return context.Users.ToList();
        }

        public void Deliver(string id)
        {
            var package = this.context.Packages.FirstOrDefault(x => x.Id == id);
            if (package == null)
            {
                return;
            }

            package.Status = Status.Delivered;
            this.context.SaveChanges();

            this.receiptServices.CreateFormReceipt(package.Weight, package.Id, package.RecipientId);
        }

    }
}
