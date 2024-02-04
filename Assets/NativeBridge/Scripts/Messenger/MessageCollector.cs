using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public sealed class MessageCollector : MessageNode
    {
        private static string ReceiveAny = "$.ReceiveAny";
        private Action<MessageHolder> handler;

        public MessageCollector()
        {
            MessageManager.Instance.Mediator.Register(this);
            MessageManager.Instance.Mediator.RegisterType(this, ReceiveAny);
        }

        public override void OnReceive(MessageHolder messageHolder)
        {
            this.handler?.Invoke(messageHolder);
        }

        public void SetHandler(Action<MessageHolder> handler)
        {
            this.handler = handler;
        }
    }
}