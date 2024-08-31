
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

        public void SetNativeByteListener(NativeByteCallback listener)
        {
            bridge?.SetNativeByteListener(listener);
        }

        public void SetNativeStringListener(NativeStringCallback listener)
        {
            bridge?.SetNativeStringListener(listener);
        }

        public void Send(byte[] data)
        {
            bridge?.Send(data);
        }

        public void Send(string json)
        {
            bridge?.Send(json);
        }
    }
}
