using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJ.Core.Util;
using System;


namespace PJ.Native
{
    public class NativeBridge : Singleton<NativeBridge>
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

        public void Send(string message, Action<string> onReceive)
        {
            bridge?.Send(message, onReceive);
        }
    }
}