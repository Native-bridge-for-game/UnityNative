using System.Collections;
using System.Collections.Generic;
using PJ.Native.Messenger;
using UnityEngine;

namespace PJ.Native.Bridge
{
    public class NativeNode : AnyNode
    {
        public NativeNode()
        {
            NativeBridge.Instance.AddNativeMessageListener(OnReceiveFromNative);
        }

        private void OnReceiveFromNative(string rawData)
        {
            this.Notify(ToMessage(rawData));
        }

        private string ToRawData(Message message)
        {
            return $"{message.Type}|{message.Data}";
        }

        private Message ToMessage(string rawData)
        {
            var splited = rawData.Split('|');
            Message message = new Message
            {
                Type = splited[0], 
                Data = splited[1]
            };
            return message;
        }

        public override void OnReceiveAny(MessageHolder messageHolder)
        {
            this.SendToNative(messageHolder.Message);
        }

        private void SendToNative(Message message)
        {
            NativeBridge.Instance.Send(ToRawData(message));
        }

        
        
    }

}

