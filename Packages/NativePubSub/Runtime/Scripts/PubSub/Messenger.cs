using System;
using System.Collections.Generic;
using PJ.Native.Data;

namespace PJ.Native.PubSub
{
    public sealed class Messenger : Subscribable
    {
        private readonly Publisher publisher = new Publisher();
        
        public int Id => publisher.Id;

        public void Subscribe(string key, ReceiveDelegate receiveDelegate)
        {
            Receiver receiver = new Receiver(this.Id, key, receiveDelegate);
            MessageManager.Instance.Mediator.Register(receiver);
        }

        public void Unsubscribe(string key)
        {
            MessageManager.Instance.Mediator.Unregister(Id, key);   
        }
        
        public void Publish(Message message)
        {
            publisher.Publish(message);
        }

    }
}