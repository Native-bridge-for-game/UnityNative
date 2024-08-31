#if UNITY_IOS
using System;
using System.Runtime.InteropServices;
using AOT;

namespace MiniSDK.Native
{
    public class iOSBridge : INativeBridge
    {
        private delegate void ObjcByteDelegate(IntPtr ptr, int length);
        private static event NativeByteCallback ByteCallback;
        [MonoPInvokeCallback(typeof(ObjcByteDelegate))]
        private static void OnIOSByteEvent(IntPtr ptr, int length)
        {
            byte[] data = new byte[length];
            Marshal.Copy(ptr, data, 0, length);
            ByteCallback?.Invoke(data);
        }
        
        private delegate void ObjcStringDelegate(string data);
        private static event NativeStringCallback StringCallback;
        [MonoPInvokeCallback(typeof(ObjcStringDelegate))]
        private static void OnIOSStringEvent(string data)
        {
            StringCallback?.Invoke(data);
        }
        
        

        [DllImport("__Internal")]
        private static extern void __iOSInitialize(ObjcByteDelegate del);
        [DllImport("__Internal")]
        private static extern void __iOSInitializeWithString(ObjcStringDelegate stringDel);
        [DllImport("__Internal")]
        private static extern void __iOSByteSend(IntPtr data, int length);
        [DllImport("__Internal")]
        private static extern void __iOSStringSend(string data);

        public iOSBridge()
        {
            __iOSInitializeWithString(OnIOSStringEvent);
        }

        public void SetNativeByteListener(NativeByteCallback listener)
        {
            ByteCallback -= listener;
            ByteCallback += listener;
        }

        public void SetNativeStringListener(NativeStringCallback listener)
        {
            StringCallback -= listener;
            StringCallback += listener;
        }

        public void Send(byte[] data)
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            __iOSByteSend(handle.AddrOfPinnedObject(), data.Length);
            handle.Free();
        }

        public void Send(string json)
        {
            __iOSStringSend(json);
        }
    }
}

#endif