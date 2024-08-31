#if UNITY_EDITOR
namespace MiniSDK.Native
{
    public class EditorBridge : INativeBridge
    {
        private NativeByteCallback byteCallback;
        private NativeStringCallback stringCallback;
        public void SetNativeByteListener(NativeByteCallback listener)
        {
            byteCallback -= listener;
            byteCallback += listener;
        }
        
        public void SetNativeStringListener(NativeStringCallback listener)
        {
            stringCallback += listener;
            stringCallback -= listener;
        }

        public void Send(byte[] data)
        {
            byteCallback?.Invoke(data);
        }

        public void Send(string json)
        {
            stringCallback?.Invoke(json);
        }
    }
}
#endif