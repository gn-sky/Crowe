using Crowe.Core.Interfaces;

namespace Crowe.Domain
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepo;
        public MessageService(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }
        public string GetMessage()
        {
            return _messageRepo.GetMessage();
        }
    }
}
