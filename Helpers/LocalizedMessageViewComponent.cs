using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

public class LocalizedMessageViewComponent : ViewComponent
{
    private readonly IStringLocalizer<SharedResources> _localizer;

    public LocalizedMessageViewComponent(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
    }

    public IViewComponentResult Invoke(string key)
    {
        var message = _localizer[key];
        return View("Default", message);
    }
}
