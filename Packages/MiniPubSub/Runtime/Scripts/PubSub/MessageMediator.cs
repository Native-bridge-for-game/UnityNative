using System.Collections;
using System.Collections.Generic;
using MiniSDK.PubSub.Data;


namespace MiniSDK.PubSub
{
    public interface MessageMediator
    {
        void Register(Receiver receiver);
        void Unregister(int id, string key);

        void Watch(Receiver receiver);
        void Unwatch(int id);
        
        
        void Publish(Message message, int publisherID);

    }

}
