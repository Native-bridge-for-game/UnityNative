using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJ.Core.Util;
using System;


namespace PJ.Native.Bridge
{
    public class NativeBridge : INativeBridge
    {
        private INativeBridge bridge;

        public NativeBridge()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            bridge = new AndroidBridge();
#elif UNITY_IOS && !UNITY_EDITOR
            bridge = new iOSBridge();
#else
            bridge = new EditorBridge();
#endif 
        }
    
        public void Send(string message)
        {
            bridge?.Send(message);
        }

        public void AddNativeMessageListener(NativeMessageCallback listener)
        {
            bridge.AddNativeMessageListener(listener);
        }
    }
}
