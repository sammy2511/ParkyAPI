using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Pages
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class IndexModel : PageModel
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private readonly ILogger<IndexModel> _logger;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public IndexModel(ILogger<IndexModel> logger)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _logger = logger;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void OnGet()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {

        }
    }
}
