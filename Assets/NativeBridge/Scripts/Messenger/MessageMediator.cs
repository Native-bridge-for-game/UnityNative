using System.Collections;
using System.Collections.Generic;
using PJ.Native.Messenger;
using UnityEngine;

public interface MessageMediator
{
    void Add(MessageNode receiver);
    void Add(MessageNode receiver, string messageType);
    void Notify(Message message, MessageNode notifier);
    void Notify(Message message, MessageNode notifier, MessageNode receiver);
    void GiveBack(Message message, MessageNode giveBacked);
}
