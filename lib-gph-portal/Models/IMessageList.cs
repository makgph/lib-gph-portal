using System.Collections;
using System.Collections.Generic;

namespace sa.gov.libgph.Models
{
    public interface IMessageList : IEnumerable, IEnumerable<IMessage>
    {
        MessageEnum Type { get; set; }
        int Count { get; }
        void Add(IMessage message);
        void Remove(IMessage message);
        int ErrorMessagesCount { get; }
        int InfoMessagesCount { get; }
        int WarnnigMessagesCount { get; }
        int SuccessMessagesCount { get; }
        IEnumerable<IMessage> ErrorMessages { get; }
        IEnumerable<IMessage> InfoMessages { get; }
        IEnumerable<IMessage> WarnnigMessages { get; }
        IEnumerable<IMessage> SuccessMessages { get; }

    }
}