using System.Collections;
using System.Collections.Generic;
using PJ.Native.Messenger;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public interface MessageMediator
    {
        void Register(MessageNode node);
        void RegisterType(MessageNode node, string messageType);
        void Notify(Message message, Notifier notifier);
        void Notify(Message message, Notifier notifier, Receivable receiver);
        void GiveBack(Message message, Receivable giveBacked);
    }

}
