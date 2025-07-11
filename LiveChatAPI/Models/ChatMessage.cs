namespace LiveChatAPI.Models
{
    public class ChatMessage
    {
        public ChatMessage()
        {
            SentAt = DateTime.UtcNow;
        }
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
