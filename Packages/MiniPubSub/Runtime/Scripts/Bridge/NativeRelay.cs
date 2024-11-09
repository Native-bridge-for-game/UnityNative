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

        private void OnReceiveFromNative(string info, string json)
        {
            Message message = new Message
            {
                Info = JsonConvert.DeserializeObject<MessageInfo>(info), 
                Json = json
            };
        
            watcher.Publish(message);
        }

        private void OnWatch(Message message)
        {
            string info = JsonConvert.SerializeObject(message.Info);
            bridge.Send(info, message.Json);
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

