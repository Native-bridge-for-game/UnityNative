using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public interface Receivable
    {
        void OnReceive(MessageHolder messageHolder);
    }

    public class Notifier
    {
        private static class IDCounter
        {
            private static int id = 0;
            public static int GetID()
            {
                return id++;
            }
        }

        public int ID = IDCounter.GetID();

        public void Notify(Message message)
        {
            MessageManager.Instance.Mediator.Notify(message, this);
        }

        public void Notify(Message message, Receivable receiver)
        {
            MessageManager.Instance.Mediator.Notify(message, this, receiver);
        }
    }
    
    public abstract class MessageNode : Notifier, Receivable
    {
        public abstract void OnReceive(MessageHolder messageHolder);   
    }
}