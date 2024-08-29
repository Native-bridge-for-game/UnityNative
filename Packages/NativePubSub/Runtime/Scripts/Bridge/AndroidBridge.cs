#if UNITY_ANDROID
using System;
using UnityEngine;

namespace PJ.Native.Bridge
{
    public class AndroidBridgeProxy : AndroidJavaProxy
    {
        public event NativeByteCallback ByteCallback;
        public event NativeStringCallback StringCallback;

        public AndroidBridgeProxy() : base("com.pj.pubsub.data.NativeBridgeCallback")
        {
            
        }

        public void onReceive(sbyte[] sbytes)
        {
            byte[] bytes = new byte[sbytes.Length];
            for (int i = 0; i < sbytes.Length; i++)
            {
                bytes[i] = (byte) sbytes[i];
            }
            ByteCallback?.Invoke(bytes);
        }

        public void onReceiveString(string data)
        {
            StringCallback?.Invoke(data);
        }
    }

    public class AndroidBridge : INativeBridge 
    {
        private AndroidBridgeProxy androidBridgeProxy;

        private Lazy<AndroidJavaObject> androidBridge = new Lazy<AndroidJavaObject>(()=>
        {
            AndroidJavaObject obj = new AndroidJavaObject("com.pj.pubsub.unity.NativeBridge");
            return obj;
        });

        public AndroidBridge()
        {
            androidBridgeProxy = new AndroidBridgeProxy();
            androidBridge.Value.Call("initialize", androidBridgeProxy);
        }

        public void SetNativeByteListener(NativeByteCallback listener)
        {
            androidBridgeProxy.ByteCallback -= listener;
            androidBridgeProxy.ByteCallback += listener;
        }

        public void SetNativeStringListener(NativeStringCallback listener)
        {
            androidBridgeProxy.StringCallback -= listener;
            androidBridgeProxy.StringCallback += listener;
        }

        public void Send(byte[] data)
        {
            sbyte[] sbytes = new sbyte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                sbytes[i] = (sbyte) data[i];
            }
            androidBridge.Value.Call("send", sbytes);
        }

        public void Send(string json)
        {
            androidBridge.Value.Call("send", json);
        }
    }
    
}

#endif