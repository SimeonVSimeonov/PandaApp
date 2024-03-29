﻿using Panda.Models;
using System.Linq;

namespace Panda.Services
{
    public interface IReceiptServices
    {
        void CreateFormReceipt(decimal weight, string packageId, string recipientId);

        IQueryable<Receipt> GetAll();
    }
}
