using System.Collections;
using System.Collections.Generic;
using PJ.Core.Util;
using PJ.Native.Messenger;
using UnityEngine;

namespace PJ.Native.Bridge
{
    public class Native : Singleton<Native>
    {
        private INativeBridge bridge;
        private MessageCollector collector;

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

        private void OnReceiveFromNative(MessageHolder messageHolder)
        {
            this.SendToNative(messageHolder.Message);
        }

        private void SendToNative(Message message)
        {
            bridge.Send(ToRawData(message));
        }

        internal void Start()
        {
            bridge = new NativeBridge();
            bridge.AddNativeMessageListener(OnReceiveFromNative);
            collector = new MessageCollector(Tag.Native);
            collector.SetHandler(OnReceiveFromNative);
        }
    }

}

