
namespace MiniSDK.Native
{
    public class NativeBridge : INativeBridge
    {
        private INativeBridge bridge;

        public NativeBridge()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            bridge = new AndroidBridge();
#elif UNITY_IOS && !UNITY_EDITOR
            bridge = new iOSBridge();
#else
            bridge = new EditorBridge();
#endif 
        }

        public void SetNativeStringListener(NativeCallback listener)
        {
            bridge?.SetNativeStringListener(listener);
        }

        public void Send(string info, string json)
        {
            bridge?.Send(info, json);
        }
    }
}
