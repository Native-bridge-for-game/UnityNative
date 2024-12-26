using MiniSDK.Core.Module;
using Newtonsoft.Json;
using MiniSDK.PubSub.Data;

namespace MiniSDK.Native
{
    public class NativeRelay : WatcherModuleBase
    {
        private INativeBridge bridge;

        protected override void InitializeNativeModule()
        {
            base.InitializeNativeModule();
            bridge = new NativeBridge();
            bridge.SetNativeCallbackListener(OnReceiveFromNative);
        }

        public override void Initialize()
        {
            base.Initialize();
            Watcher.Watch(OnWatch);
        }

        private void OnReceiveFromNative(string info, string json)
        {
            Message message = new Message
            {
                Info = JsonConvert.DeserializeObject<MessageInfo>(info), 
                Json = json
            };
        
            Watcher.Publish(message);
        }

        private void OnWatch(Message message)
        {
            string info = JsonConvert.SerializeObject(message.Info);
            bridge.Send(info, message.Json);
        }

    }

}

