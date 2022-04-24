using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// This class is the pgae model class for ContactUs.cshtml 
    /// </summary>
    public class ContactUsModel : PageModel
    {
        // logger object
        private readonly ILogger<ContactUsModel> _logger;

        /// <summary>
        /// Constructor for ContactUsModel class
        /// </summary>
        /// <param name="logger">logger object</param>
        public ContactUsModel(ILogger<ContactUsModel> logger) => _logger = logger;

        /// <summary>
        /// Whenever a user makes a GET request to a page, this method is invoked
        /// </summary>
        public void OnGet()
        {
        }
    }
}

