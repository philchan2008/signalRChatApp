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
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int p = 1)
        {
            const int pageSize = 10;
            int page = p;
            CurrentPage = page;

            var totalMessages = await _context.Messages.CountAsync();
            TotalPages = (int)Math.Ceiling(totalMessages / (double)pageSize);

            Messages = await _context.Messages
                .OrderByDescending(m => m.Timestamp)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

    }
}
