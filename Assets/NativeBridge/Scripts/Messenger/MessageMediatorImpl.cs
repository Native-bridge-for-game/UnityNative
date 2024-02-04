using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace PJ.Native.Messenger
{
    public class MessageMediatorImpl : MessageMediator
    {
        private static string ReceiveAny = "$.ReceiveAny";
        private Dictionary<string, List<MessageNode>> nodeFilter;
        private Dictionary<int, MessageNode> nodeMap;

        public MessageMediatorImpl()
        {
            nodeFilter = new Dictionary<string, List<MessageNode>>()
            {
                {ReceiveAny, new List<MessageNode>()}
            };
            nodeMap = new Dictionary<int, MessageNode>();
        }

        public void Register(MessageNode node)
        {
            nodeMap[node.ID] = node;
        }

        public void RegisterType(MessageNode node, string messageType)
        {
            if(nodeFilter.TryGetValue(messageType, out var list)){
                list.Add(node);
            }
            else
            { 
                var newList = new List<MessageNode>(){node};
                nodeFilter[messageType] = newList;
            }
        }

        public void Notify(Message message, Notifier notifier)
        {
            MessageHolder holder = new MessagePostman(message, linkReceiver(notifier));
            if(nodeFilter.TryGetValue(message.Type, out List<MessageNode> receivers))
            {
                foreach(var receiver in receivers)
                {
                    receiver.OnReceive(holder);
                }
            }

            foreach(var receiver in nodeFilter[ReceiveAny])
            {
                if(notifier != receiver)
                {
                    receiver.OnReceive(holder);
                }
            }
        }

        public void Notify(Message message, Notifier notifier, Receivable receiver)
        {
            MessageHolder holder = new MessagePostman(message, linkReceiver(notifier));
            receiver.OnReceive(holder);
        }

        private Receivable linkReceiver(Notifier publisher)
        {
            return nodeMap[publisher.ID];
        }

        public void GiveBack(Message message, Receivable giveBacked)
        {
            MessageHolder holder = new MessagePostman(message);
            giveBacked.OnReceive(holder);
        }
    }
}