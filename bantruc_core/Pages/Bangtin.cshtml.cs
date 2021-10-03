using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bantruc_core.Pages
{
    public class BangtinModel : PageModel
    {
        public void OnGet(String id)
        {

        }

        public IActionResult OnGetPartial() =>
            Partial("Bangtin");

    }
}
