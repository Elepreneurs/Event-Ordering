using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Elevacity.Applications.EventOrdering.Pages.Ordering
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {

        }

        [BindProperty]
        public OrderEventModel OrderEvent { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync()
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }

    public class OrderEventModel
    {
        public OrderEventModel()
        {
            CreditCardModel = new OrderEventCreditCardModel();
        }

        public OrderEventCreditCardModel CreditCardModel { get; set; }
    }

    public class OrderEventCreditCardModel
    {
        [Required]
        [StringLength(16, MinimumLength = 14, ErrorMessage = "Valid Credit Card Required")]
        [DataType(DataType.CreditCard)]
        public string CreditCardNumber { get; set; }
    }
}