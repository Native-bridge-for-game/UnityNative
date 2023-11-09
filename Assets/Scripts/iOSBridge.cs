using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace PJ.Native
{
    public class iOSBridge : INativeBridge
    {
        private delegate void NativeBridgeCallback(string message, int nonce);

        private static Action<string, int> nativeEvent;

        [MonoPInvokeCallback(typeof(NativeBridgeCallback))]
        private static void OniOSEvent(string message, int nonce)
        {
            Debug.Log("oniOSEvent : " + message + "  " + nonce);
            nativeEvent?.Invoke(message, nonce);
        }

        [DllImport("__Internal")]
        private static extern void __iOSInitialize(NativeBridgeCallback del);

        [DllImport("__Internal")]
        private static extern void __iOSSend(string message, int nonce);

        private int nonce = 0;
        private int Nonce => nonce++;

        private Dictionary<int, Action<string>> dicRequest;

        private void OnNativeEvent(string message, int nonce)
        {
            if(dicRequest.Remove(nonce, out Action<string> responce))
            {
                responce.Invoke(message);
            }
        }

        public iOSBridge()
        {
            dicRequest = new Dictionary<int, Action<string>>();
            nativeEvent -= OnNativeEvent;
            nativeEvent += OnNativeEvent;
            __iOSInitialize(OniOSEvent);
        }

        public void Send(string message)
        {
            __iOSSend(message, -1);
        }

        public void Send(string message, Action<string> onReceive)
        {
            int nonce = Nonce;
            dicRequest.Add(nonce, onReceive);
            __iOSSend(message, nonce);
            
        }
    }
}
