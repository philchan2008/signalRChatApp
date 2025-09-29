using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRChatApp.Models;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Threading;
using SignalRChatApp.Helpers;

namespace SignalRChatApp.Pages
{
    public class HistoryModel : PageModel
    {
        //public readonly INavigationState navState;
        private readonly ChatDbContext _context;

        private readonly IStringLocalizer<SharedResources> _localizer;

        public HistoryModel(ChatDbContext context, IStringLocalizer<SharedResources> localizer)
        {
            _context = context;
            _localizer = localizer;
            //navState = navState;
        }

        public List<ChatMessage> Messages { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        //FIXME: It is required to move it into nav service or desc service
        public string navChat;
        public string navHistory;

        public async Task OnGetAsync(int p = 1)
        {
            const int pageSize = 10;
            CurrentPage = p;

            var query = _context.Messages.AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(m =>
                    m.User.Contains(SearchTerm) ||
                    m.Message.Contains(SearchTerm));
            }


            var totalMessages = await query.CountAsync();
            TotalPages = (int)Math.Ceiling(totalMessages / (double)pageSize);

            Messages = await query
                .OrderByDescending(m => m.Timestamp)
                .Skip((p - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            //FIXME: It is required to move it into nav service or desc service
            navChat = LocalizationHelper.Get(_localizer, "Chat", "Chat");
            navHistory = LocalizationHelper.Get(_localizer, "History", "History");
        }

    }
}
