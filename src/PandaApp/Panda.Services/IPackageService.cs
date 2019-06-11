using Panda.Models;
using System.Collections.Generic;

namespace Panda.Services
{
    public interface IPackageService
    {
        ICollection<User> GetAllRecipients();

        ICollection<Package> GetAllDeliveredPackages();

        ICollection<Package> GetAllPendingPackages();

        void Create(string description, decimal weight, string shippingAddress, string recipientName);

        void Deliver(string id);
    }
}
