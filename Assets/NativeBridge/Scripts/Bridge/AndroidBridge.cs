#if UNITY_ANDROID
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace PJ.Native.Bridge
{
    public class AndroidBridgeProxy : AndroidJavaProxy
    {
        public NativeDataCallback DataCallback;

        public AndroidBridgeProxy() : base("com.pj.core.unity.NativeBridgeCallback")
        {
            
        }

        public void onReceive(byte[] data)
        {
            DataCallback?.Invoke(data);
        }
    }

    public class AndroidBridge : INativeBridge 
    {
        private AndroidBridgeProxy androidBridgeProxy;

        private Lazy<AndroidJavaObject> androidBridge = new Lazy<AndroidJavaObject>(()=>
        {
            AndroidJavaObject obj = new AndroidJavaObject("com.pj.core.unity.NativeBridge");
            return obj;
        }) ;

        public AndroidBridge()
        {
            androidBridgeProxy = new AndroidBridgeProxy();
            androidBridge.Value.Call("initialize", androidBridgeProxy);
        }

        public void SetNativeDataListener(NativeDataCallback listener)
        {
            androidBridgeProxy.DataCallback -= listener;
            androidBridgeProxy.DataCallback -= listener;
        }

        public void Send(byte[] data)
        {
            androidBridge.Value.Call("send", data);
        }

    }
    
}

#endif