#if UNITY_IOS
using System;
using System.Runtime.InteropServices;
using AOT;

namespace MiniSDK.Native
{
    public class iOSBridge : INativeBridge
    {
        // private delegate void ObjcStringDelegate(string data);
        private static event NativeCallback iOSNativeCallback;
        [MonoPInvokeCallback(typeof(NativeCallback))]
        private static void OnIOSStringEvent(string info, string json)
        {
            iOSNativeCallback?.Invoke(info, json);
        }
        
        [DllImport("__Internal")]
        private static extern void __iOSInitialize(NativeCallback stringDel);
        [DllImport("__Internal")]
        private static extern void __iOSSend(string info, string data);

        public iOSBridge()
        {
            __iOSInitialize(OnIOSStringEvent);
        }

        public void SetNativeStringListener(NativeCallback listener)
        {
            iOSNativeCallback -= listener;
            iOSNativeCallback += listener;
        }

        public void Send(string info, string json)
        {
            __iOSSend(info, json);
        }
    }
}

#endif