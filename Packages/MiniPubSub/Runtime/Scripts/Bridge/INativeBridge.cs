
namespace MiniSDK.Native
{
    public delegate void NativeCallback(string info, string json);
    
    public interface INativeBridge
    {
        void SetNativeStringListener(NativeCallback listener);
        void Send(string info, string json);
    }
}

 