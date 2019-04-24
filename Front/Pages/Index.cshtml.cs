using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Front.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _appConfiguration;

        public string ApiUrl => _appConfiguration["API_URL"];

        public IndexModel(IConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public void OnGet()
        { }
    }
}