using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None,
        NoStore = true)]
    /// <summary>
    /// This method is to check if the request object Id is matching
    /// the one we see on the webpage
    /// </summary>
    public class ErrorModel : PageModel
    {
        // Setting all the basic template for error checking
        // of the function call request
        public string? RequestId { get; set; }

        public static string? error_str { get; set; } = "default";

        public static void func_error(string error_var)
        {
            error_str = error_var;
        }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger) => _logger = logger;

        // if the Activity.current is null use HttpContext.TraceIdentifier
        // to set the trace id, vice versa
        public void OnGet() =>
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        
    }
}
