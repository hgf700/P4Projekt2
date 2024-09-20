namespace AuthorizationServer.chatbot
{
    public interface IChatbotService
    {
        Task<string> GetChatbotResponse(string message);
    }
}
