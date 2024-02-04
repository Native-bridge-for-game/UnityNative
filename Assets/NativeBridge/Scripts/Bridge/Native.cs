using System.Collections;
using System.Collections.Generic;
using PJ.Native.Messenger;
using UnityEngine;

namespace PJ.Native.Bridge
{
    public class Native
    {
        private MessageCollector collector;

        public Native()
        {
            NativeBridge.Instance.AddNativeMessageListener(OnReceiveFromNative);
            collector = new MessageCollector();
            collector.SetHandler(OnReceiveAny);
        }

        private void OnReceiveFromNative(string rawData)
        {
            collector.Notify(ToMessage(rawData));
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

        private void OnReceiveAny(MessageHolder messageHolder)
        {
            this.SendToNative(messageHolder.Message);
        }

        private void SendToNative(Message message)
        {
            NativeBridge.Instance.Send(ToRawData(message));
        }

        
        
    }

}

