namespace SignalRChatApp.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public required string User { get; set; }
        public required string Message { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}