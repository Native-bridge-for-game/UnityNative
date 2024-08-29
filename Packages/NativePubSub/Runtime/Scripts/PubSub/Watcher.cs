using PJ.Native.Data;
using UnityEngine;

namespace PJ.Native.PubSub
{
    public class Watcher : Watchable
    {
        private readonly Publisher publisher = new Publisher();
        public int Id => publisher.Id;

        public void Watch(ReceiveDelegate receiverDelegate)
        {
            Receiver receiver = new Receiver(Id, "", receiverDelegate);
            MessageManager.Instance.Mediator.Watch(receiver);
        }

        public void Unwatch()
        {
            MessageManager.Instance.Mediator.Unwatch(Id);
        }

        public void Publish(Message message)
        {
            publisher.Publish(message);
        }

    }
}