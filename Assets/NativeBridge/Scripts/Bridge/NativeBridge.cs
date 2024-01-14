using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJ.Core.Util;
using System;


namespace PJ.Native.Bridge
{
    public class NativeBridge : Singleton<NativeBridge>, INativeBridge
    {
        private INativeBridge bridge;

        protected override void Initialize()
        {
#if UNITY_ANDROID 
            bridge = new AndroidBridge();
#elif UNITY_IOS
            bridge = new iOSBridge();
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
