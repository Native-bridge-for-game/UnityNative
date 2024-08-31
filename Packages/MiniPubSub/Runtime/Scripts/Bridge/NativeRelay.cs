using MiniSDK.Core.Util;
using MiniSDK.PubSub;
using Newtonsoft.Json;
using MiniSDK.PubSub.Data;

namespace MiniSDK.Native
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

