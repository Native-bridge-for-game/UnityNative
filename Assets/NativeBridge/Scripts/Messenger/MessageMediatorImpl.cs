using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace PJ.Native.Messenger
{
    public class MessageMediatorImpl : MessageMediator
    {
        private Dictionary<string, List<MessageNode>> receiverDict = new Dictionary<string, List<MessageNode>>();
        private HashSet<MessageNode> receiverSet = new HashSet<MessageNode>();

        public void Add(MessageNode receiver)
        {
            List<string> messageTypes = receiver.GetReceivingMessageTypes();
            if(messageTypes == null)
            {
                receiverSet.Add(receiver);
            }
            else
            {
                foreach(var messageType in messageTypes)
                {
                    if(receiverDict.TryGetValue(messageType, out var list))
                    {
                        list.Add(receiver);
                    }
                    else
                    {
                        var newList = new List<MessageNode>();
                        newList.Add(receiver);
                        receiverDict[messageType] = newList;
                    }
                }
            }
        }

        public void Add(MessageNode receiver, string messageType)
        {
            if(receiverDict.TryGetValue(messageType, out var list)){
                list.Add(receiver);
            }
            else
            {
                var newList = new List<MessageNode>();
                newList.Add(receiver);
                receiverDict[messageType] = newList;
            }
        }

        public void Notify(Message message, MessageNode notifier)
        {
            MessageHolder holder = new MessagePostman(message, notifier);
            if(receiverDict.TryGetValue(message.Type, out List<MessageNode> receivers))
            {
                foreach(var receiver in receivers)
                {
                    receiver.OnReceive(holder);
                }
            }

            foreach(var receiver in receiverSet)
            {
                if(notifier != receiver)
                {
                    receiver.OnReceive(holder);
                }
            }
        }

        public void Notify(Message message, MessageNode notifier, MessageNode receiver)
        {
            MessageHolder holder = new MessagePostman(message, notifier);
            receiver.OnReceive(holder);
        }

        public void GiveBack(Message message, MessageNode giveBacked)
        {
            MessageHolder holder = new MessagePostman(message);
            giveBacked.OnReceive(holder);
        }
    }
}