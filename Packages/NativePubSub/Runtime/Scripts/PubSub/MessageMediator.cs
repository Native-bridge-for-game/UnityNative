using System.Collections;
using System.Collections.Generic;
using PJ.Native.Data;
using PJ.Native.PubSub;
using UnityEngine;

namespace PJ.Native.PubSub
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
