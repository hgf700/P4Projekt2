namespace AuthorizationServer.chatbot
{
    public class ChatbotService : IChatbotService
    {
        public async Task<string> GetChatbotResponse(string message)
        {
            // Logika komunikacji z chatbotem
            return await Task.FromResult("Odpowiedź z chatbota");
        }
    }
}
