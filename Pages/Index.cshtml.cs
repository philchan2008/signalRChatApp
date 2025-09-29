using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Threading;
using SignalRChatApp.Helpers;


namespace SignalRChatApp.Pages;

public class IndexModel : PageModel
{
    public string CurrentCulture => CultureInfo.CurrentCulture.Name;

    //FIXME: It is required to move it into nav service or desc service
    public string navChat;
    public string navHistory;

    private readonly IStringLocalizer<SharedResources> _localizer;

    public IndexModel(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
    }

    public void OnGet(string culture)
    {
        if (!string.IsNullOrEmpty(culture))
        {
            var selectedCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = selectedCulture;
            Thread.CurrentThread.CurrentUICulture = selectedCulture;
        }

        //FIXME: It is required to move it into nav service or desc service
        navChat = LocalizationHelper.Get(_localizer, "Chat", "Chat");
        navHistory = LocalizationHelper.Get(_localizer, "History", "History");

    }

}
