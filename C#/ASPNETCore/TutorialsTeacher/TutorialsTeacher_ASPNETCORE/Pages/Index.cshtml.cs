using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using TutorialsTeacher_ASPNETCORE.Config;

namespace TutorialsTeacher_ASPNETCORE.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;
        public string KeyValue = "";
        public string KeyValue2 = "";

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config, IOptions<MyCustomKey> appIdentitySettingsAccessor)
        {
            _logger = logger;
            _config = config;
            KeyValue = GetValue();
            KeyValue2 = appIdentitySettingsAccessor.Value.Key;
        }

        public string GetValue()
        {
            return _config.GetValue<string>("MyCustomKey:Key");
        }

        public void OnGet()
        {

        }
    }
}