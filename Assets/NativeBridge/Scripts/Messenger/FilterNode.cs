using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public abstract class FilterNode : PublishingNode
    {
        private Dictionary<string, Action<MessageHolder>> handlerMap;

        protected abstract Dictionary<string, Action<MessageHolder>> OnInitialize();

        public FilterNode()
        {
            handlerMap = this.OnInitialize();
        }

        public override List<string> GetReceivingMessageTypes()
        {
            return this.handlerMap.Keys.ToList<string>();
        }

        public override void OnReceive(MessageHolder messageHolder)
        {
            if(handlerMap.TryGetValue(messageHolder.Message.Type, out Action<MessageHolder> handler))
            {
                handler.Invoke(messageHolder);
            }
        }
    }
}