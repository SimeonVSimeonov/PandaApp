using Panda.App.ViewModels.Receipts;
using Panda.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Linq;

namespace Panda.App.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly IReceiptServices receiptsService;

        public ReceiptsController(IReceiptServices receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var viewModel = this.receiptsService.GetAll().Select(
                x => new ReceiptViewModel
                {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.Issued,
                    RecipientName = x.Recipient.Username
                }).ToList();

            return this.View(viewModel);
        }
    }
}
