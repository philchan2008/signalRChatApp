using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRChatApp.Models;

namespace SignalRChatApp.Pages
{
   public class HistoryModel : PageModel
    {
        private readonly ChatDbContext _context;

        public HistoryModel(ChatDbContext context)
        {
            _context = context;
        }

        public List<ChatMessage> Messages { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

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
        }

    }
}
