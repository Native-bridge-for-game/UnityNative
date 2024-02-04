using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public sealed class MessageHandler : MessageNode
    {
        private Dictionary<string, Action<MessageHolder>> handlerMap;

        public MessageHandler()
        {
            MessageManager.Instance.Mediator.Register(this);
            handlerMap = new Dictionary<string, Action<MessageHolder>>();
        }

        public override void OnReceive(MessageHolder messageHolder)
        {
            if(handlerMap.TryGetValue(messageHolder.Message.Type, out Action<MessageHolder> handler))
            {
                handler.Invoke(messageHolder);
            }
        }

        public void SetHandler(string messageType, Action<MessageHolder> handler)
        {
            if(handlerMap.ContainsKey(messageType))
            {
                handlerMap[messageType] += handler;
            }
            else
            {
                handlerMap.Add(messageType, handler);
            }
            MessageManager.Instance.Mediator.RegisterType(this, messageType);
        }
    }
}