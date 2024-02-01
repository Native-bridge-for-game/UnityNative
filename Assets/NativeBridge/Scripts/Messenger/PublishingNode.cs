using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public abstract class PublishingNode : MessageNode
    {
        public abstract List<string> GetReceivingMessageTypes();

        public abstract void OnReceive(MessageHolder MessageHolder);

        public void Notify(Message message)
        {
            MessageManager.Instance.Mediator.Notify(message, this);
        }

        public void Notify(Message message, MessageNode receiver)
        {
            MessageManager.Instance.Mediator.Notify(message, this, receiver);
        }
    }
}