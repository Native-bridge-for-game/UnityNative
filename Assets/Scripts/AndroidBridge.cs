using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace PJ.Native
{
    public class AndroidBridgeProxy : AndroidJavaProxy
    {
        public NativeMessageCallback MessageCallback;

        public AndroidBridgeProxy() : base("com.pj.core.unity.NativeBridgeCallback")
        {
            
        }

        public void onReceive(string message)
        {
            MessageCallback?.Invoke(message);
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

        public void AddNativeMessageListener(NativeMessageCallback listener)
        {
            androidBridgeProxy.MessageCallback -= listener;
            androidBridgeProxy.MessageCallback += listener;
        }

        public void Send(string message)
        {
            androidBridge.Value.Call("send", message);           
        }

    }
    
}

