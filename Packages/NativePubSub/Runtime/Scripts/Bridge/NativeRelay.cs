using System.Collections;
using System.Collections.Generic;
using PJ.Core.Util;
using PJ.Native.PubSub;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using PJ.Native.Data;

namespace PJ.Native.Bridge
{
    public class NativeRelay : Singleton<NativeRelay>
    {
        private INativeBridge bridge;
        private Watcher watcher;

        private void OnReceiveFromNative(string data)
        {
            Message message = JsonConvert.DeserializeObject<Message>(data);
        
            watcher.Publish(message);
        }

        private void OnWatch(Message message)
        {
            string data = JsonConvert.SerializeObject(message);
            bridge.Send(data);
        }

        internal void Start()
        {
            bridge = new NativeBridge();
            bridge.SetNativeStringListener(OnReceiveFromNative);
            
            watcher = new Watcher();
            watcher.Watch(OnWatch);
            
        }
    }

}

