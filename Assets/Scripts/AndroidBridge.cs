using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace PJ.Native
{
    public class AndroidBridgeProxy : AndroidJavaProxy
    {
        public Action<string, int> AnonymouseEvent;

        public AndroidBridgeProxy() : base("com.pj.nativecore.NativeBridgeCallback")
        {
            
        }

        public void onReceive(string message, int nonce)
        {
            AnonymouseEvent?.Invoke(message, nonce);
        }
    }

    public class AndroidBridge : INativeBridge 
    {
        private Dictionary<int, Action<string>> anonymousRequests;
        private AndroidBridgeProxy androidBridgeProxy;
        private int nonce = 0;
        private int Nonce => nonce++;

        private Lazy<AndroidJavaObject> androidBridge = new Lazy<AndroidJavaObject>(()=>
        {
            AndroidJavaObject obj = new AndroidJavaObject("com.pj.nativecore.NativeBridge");
            return obj;
        }) ;

        private void OnAnonymouseEvent(string message, int nonce)
        {
            if(anonymousRequests.Remove(nonce, out Action<string> responce))
            {
                responce.Invoke(message);
            }
        }

        public AndroidBridge()
        {
            anonymousRequests = new Dictionary<int, Action<string>>();
            androidBridgeProxy = new AndroidBridgeProxy();
            androidBridgeProxy.AnonymouseEvent += OnAnonymouseEvent;
            androidBridge.Value.Call("initialize", androidBridgeProxy);
        }

        public void Send(string message)
        {
            androidBridge.Value.Call("send", message);           
        }

        public void Send(string message, Action<string> onReceive)
        {
            int nonce = Nonce;
            anonymousRequests.Add(nonce, onReceive);
            androidBridge.Value.Call("send", message, nonce);
        }
    }
    
}

