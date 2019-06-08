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

        /*
         Failed executing DbCommand (19ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
CREATE TABLE [Receipts] (
    [RecipientId] nvarchar(450) NOT NULL,
    [PackageId] nvarchar(450) NOT NULL,
    [Id] nvarchar(max) NULL,
    [Fee] decimal(18,2) NOT NULL,
    [Issued] datetime2 NOT NULL,
    CONSTRAINT [PK_Receipts] PRIMARY KEY ([PackageId], [RecipientId]),
    CONSTRAINT [FK_Receipts_Packages_PackageId] FOREIGN KEY ([PackageId]) REFERENCES [Packages] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Receipts_Users_RecipientId] FOREIGN KEY ([RecipientId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
         */
    }
}
