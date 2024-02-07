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
            collector = new MessageCollector(Tag.Native);
            collector.SetHandler(OnReceiveAny);
        }

        private void OnReceiveFromNative(string rawData)
        {
            collector.Notify(ToMessage(rawData), Tag.Game);
        }

        private string ToRawData(Message message)
        {
            return $"{message.Key}|{message.Data}";
        }

        private Message ToMessage(string rawData)
        {
            var splited = rawData.Split('|');
            Message message = new Message(splited[0], splited[1]); // (Key, Data)
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

