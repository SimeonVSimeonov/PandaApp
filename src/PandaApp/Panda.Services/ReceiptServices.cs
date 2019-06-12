using Panda.Data;
using Panda.Models;
using System;
using System.Linq;

namespace Panda.Services
{
    public class ReceiptServices : IReceiptServices
    {
        private readonly PandaAppDBContext context;

        public ReceiptServices(PandaAppDBContext context)
        {
            this.context = context;
        }

        public void CreateFormReceipt(decimal weight, string packageId, string recipientId)
        {
            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recipientId,
                Fee = weight * 2.67M,
                Issued = DateTime.UtcNow,
            };

            this.context.Receipts.Add(receipt);
            this.context.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            return this.context.Receipts;
        }
    }
}
