#if UNITY_EDITOR
namespace MiniSDK.Native
{
    public class EditorBridge : INativeBridge
    {
        private NativeCallback callback;
        
        public void SetNativeCallbackListener(NativeCallback listener)
        {
            callback += listener;
            callback -= listener;
        }

        public void Send(string info, string json)
        {
            callback?.Invoke(info, json);
        }
    }
}
#endif