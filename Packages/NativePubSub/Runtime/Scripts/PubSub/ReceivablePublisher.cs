using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using PJ.Native.Data;
using UnityEngine;

namespace PJ.Native.PubSub
{
    static class IDCounter
    {
        private static int id = (int) PublisherType.Game;
        public static int GetID()
        {
            return ++id;
        }
    }
    public delegate void ReceiveDelegate(Message message);

    public class Receiver
    {
        public readonly int NodeId;
        public readonly string Key;
        public readonly ReceiveDelegate ReceiverDelegate;
        
        public Receiver(int id, string key, ReceiveDelegate receiverDelegate)
        {
            NodeId = id;
            Key = key;
            ReceiverDelegate = receiverDelegate;
        }
    }

    public interface Node
    {
        int Id { get; }
    }

    public interface Subscribable : Node
    {
        void Subscribe(string key, ReceiveDelegate receiveDelegate);
        void Unsubscribe(string key);
    }

    public interface Watchable : Node
    {
        void Watch(ReceiveDelegate receiveDelegate);
        void Unwatch();
    }


    public enum PublisherType
    {
        Android     = 10000,
        IOS         = 20000,
        Game        = 30000
    }

    public class Publisher : Node
    {
        public int Id { get; } = IDCounter.GetID();

        public void Publish(Message message)
        {
            MessageManager.Instance.Mediator.Publish(message, Id);
        }

    }
    
}