using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace SignalRChatApp.Helpers
{
    public static class LocalizationHelper
    {
        public static string Get(IStringLocalizer localizer, string key, string fallback, ILogger logger = null)
        {
            var result = localizer[key];
            if (result.ResourceNotFound && logger != null)
            {
                logger.LogWarning("Missing localization key: {Key}", key);
            }
            return result.ResourceNotFound ? fallback ?? key : result.Value;
        }
    }
}