using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public abstract class AnyNode : PublishingNode
    {
        public override List<string> GetReceivingMessageTypes()
        {
            return null;
        }

        public override void OnReceive(MessageHolder messageHolder)
        {
            this.OnReceiveAny(messageHolder);
        }

        public abstract void OnReceiveAny(MessageHolder messageHolder);
    }
}