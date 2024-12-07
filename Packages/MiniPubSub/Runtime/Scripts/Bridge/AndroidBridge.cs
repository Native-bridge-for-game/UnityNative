#if UNITY_ANDROID
using System;
using UnityEngine;

namespace MiniSDK.Native
{
    public class AndroidBridgeProxy : AndroidJavaProxy
    {
        public event NativeCallback StringCallback;

        public AndroidBridgeProxy() : base("com.minisdk.pubsub.bridge.NativeBridgeCallback")
        {
            
        }

        public void onReceive(string info, string json)
        {
            StringCallback?.Invoke(info, json);
        }
    }

    public class AndroidBridge : INativeBridge 
    {
        private AndroidBridgeProxy androidBridgeProxy;

        private Lazy<AndroidJavaObject> androidBridge = new Lazy<AndroidJavaObject>(()=>
        {
            AndroidJavaObject obj = new AndroidJavaObject("com.minisdk.pubsub.bridge.UnityNativeBridge");
            return obj;
        });

        public AndroidBridge()
        {
            androidBridgeProxy = new AndroidBridgeProxy();
            androidBridge.Value.Call("initialize", androidBridgeProxy);
        }

        public void SetNativeStringListener(NativeCallback listener)
        {
            androidBridgeProxy.StringCallback -= listener;
            androidBridgeProxy.StringCallback += listener;
        }

        public void Send(string info, string json)
        {
            androidBridge.Value.Call("send", info, json);
        }
    }
    
}

#endif