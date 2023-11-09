using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace PJ.Native
{
    public class AndroidBridgeProxy : AndroidJavaProxy
    {
        public Action<string, int> NativeEvent;

        public AndroidBridgeProxy() : base("com.pj.nativecore.NativeBridgeCallback")
        {
            
        }

        public void onReceive(string message, int nonce)
        {
            NativeEvent?.Invoke(message, nonce);
        }
    }

    public class AndroidBridge : INativeBridge 
    {
        private Dictionary<int, Action<string>> dicRequest;
        private AndroidBridgeProxy androidBridgeProxy;
        private int nonce = 0;
        private int Nonce => nonce++;

        private Lazy<AndroidJavaObject> androidBridge = new Lazy<AndroidJavaObject>(()=>
        {
            AndroidJavaObject obj = new AndroidJavaObject("com.pj.nativecore.NativeBridge");
            return obj;
        }) ;

        private void OnNativeEvent(string message, int nonce)
        {
            if(dicRequest.Remove(nonce, out Action<string> responce))
            {
                responce.Invoke(message);
            }
        }

        public AndroidBridge()
        {
            dicRequest = new Dictionary<int, Action<string>>();
            androidBridgeProxy = new AndroidBridgeProxy();
            androidBridgeProxy.NativeEvent -= OnNativeEvent;
            androidBridgeProxy.NativeEvent += OnNativeEvent;
            androidBridge.Value.Call("initialize", androidBridgeProxy);
        }

        public void Send(string message)
        {
            androidBridge.Value.Call("send", message);           
        }

        public void Send(string message, Action<string> onReceive)
        {
            int nonce = Nonce;
            dicRequest.Add(nonce, onReceive);
            androidBridge.Value.Call("send", message, nonce);
        }
    }
    
}

