using Microsoft.AspNetCore.SignalR;
using SignalRChatApp.Models;

namespace SignalRChatApp
{
    public class ChatHub : Hub
    {
        private readonly ChatDbContext _db;

        public ChatHub(ChatDbContext db) => _db = db;

        public async Task SendMessage(string user, string message)
        {
            var chat = new ChatMessage { User = user, Message = message, Timestamp = DateTime.UtcNow };
            _db.Messages.Add(chat);
            await _db.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", user, message, chat.Timestamp);
        }
    }
}