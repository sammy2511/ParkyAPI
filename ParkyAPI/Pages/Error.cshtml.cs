using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ErrorModel : PageModel
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string RequestId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        private readonly ILogger<ErrorModel> _logger;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ErrorModel(ILogger<ErrorModel> logger)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _logger = logger;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public void OnGet()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
