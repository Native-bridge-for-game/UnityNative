#if UNITY_IOS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace PJ.Native.Bridge
{
    public class iOSBridge : INativeBridge
    {

        private static Action<string> nativeEvent;

        [MonoPInvokeCallback(typeof(NativeMessageCallback))]
        private static void OniOSEvent(string message)
        {
            Debug.Log("oniOSEvent : " + message + "  ");
            nativeEvent?.Invoke(message);
        }

        [DllImport("__Internal")]
        private static extern void __iOSInitialize(NativeMessageCallback del);

        [DllImport("__Internal")]
        private static extern void __iOSSend(string message);

        private NativeMessageCallback messageCallback;

        private void OnNativeEvent(string message)
        {
            messageCallback?.Invoke(message);
        }

        public iOSBridge()
        {
            nativeEvent -= OnNativeEvent;
            nativeEvent += OnNativeEvent;
            __iOSInitialize(OniOSEvent);
        }
        public void AddNativeMessageListener(NativeMessageCallback listener)
        {
            this.messageCallback -= listener;
            this.messageCallback += listener;
        }

        public void Send(string message)
        {
            __iOSSend(message);
        }

    }
}

#endif