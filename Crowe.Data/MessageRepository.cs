using System;
using Crowe.Core.Interfaces;

namespace Crowe.Data
{
    public class MessageRepository : IMessageRepository
    {
        public string GetMessage()
        {
                return "Hello World!";
        }
    }
}
