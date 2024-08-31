using System.Collections.Concurrent;
using System.Collections.Generic;
using MiniSDK.PubSub.Data;

namespace MiniSDK.PubSub
{
    internal class MessageMediatorImpl : MessageMediator
    {
        // private Dictionary<int, Subscribable>
        private readonly ConcurrentDictionary<string, List<Receiver>> receiverDic = new ConcurrentDictionary<string, List<Receiver>>();
        private readonly ConcurrentDictionary<int, Receiver> watcherDic = new ConcurrentDictionary<int, Receiver>();
        
        public void Register(string key, Receiver receiver)
        {
            if (receiverDic.ContainsKey(key))
            {
                receiverDic[key].Add(receiver);
            }
            else
            {
                receiverDic[key] = new List<Receiver> {receiver};
            }
        }

        public void Register(Receiver receiver)
        {
            string key = receiver.Key;
            if (receiverDic.ContainsKey(key))
            {
                receiverDic[key].Add(receiver);
            }
            else
            {
                receiverDic[key] = new List<Receiver> {receiver};
            }
        }

        public void Unregister(int id, string key)
        {
            if (receiverDic.TryGetValue(key, out List<Receiver> receivers))
            {
                receivers.RemoveAll(receiver => receiver.NodeId == id);
            }
        }

        public void Watch(Receiver receiver)
        {
            watcherDic[receiver.NodeId] = receiver;
        }

        public void Unwatch(int id)
        {
            watcherDic.Remove(id, out var receiver);
        }

        public void Publish(Message message, int publisherID)
        {
            if (receiverDic.TryGetValue(message.Key, out var receivers))
            {
                foreach (var receiver in receivers)
                {
                    if(receiver.NodeId == publisherID) 
                        continue;
                    receiver.ReceiverDelegate?.Invoke(message);
                }
            }

            foreach (var watcher in watcherDic.Values)
            {
                if(watcher.NodeId == publisherID) 
                    continue;
                watcher.ReceiverDelegate?.Invoke(message);
            }
        }

    }
}