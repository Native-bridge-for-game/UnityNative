
namespace MiniSDK.Native
{
    public delegate void NativeByteCallback(byte[] data);

    public delegate void NativeStringCallback(string data);
    
    public interface INativeBridge
    {
        void SetNativeByteListener(NativeByteCallback listener);
        void SetNativeStringListener(NativeStringCallback listener);
        void Send(byte[] data);
        void Send(string json);
    }
}

 