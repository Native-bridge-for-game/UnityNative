using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public class MessagePostman : MessageHolder
    {
        private MessageNode notifier;
        public Message Message 
        {
            get;
            private set;
        }
        public MessagePostman(Message message)
        {
            this.Message = message;
            this.notifier = null;
        }
        public MessagePostman(Message message, MessageNode notifier)
        {
            this.Message = message;
            this.notifier = notifier;
        }

        public void GiveBack(Message message)
        {
            MessageManager.Instance.Mediator.GiveBack(message, notifier);
        }
    }
}