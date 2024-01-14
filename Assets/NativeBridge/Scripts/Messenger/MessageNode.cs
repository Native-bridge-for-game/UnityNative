using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public interface MessageNode
    {
        void Notify(Message message);
        void Notify(Message message, MessageNode receiver);
        List<string> GetReceivingMessageTypes();
        void OnReceive(MessageHolder messageHolder);
        
    }
}