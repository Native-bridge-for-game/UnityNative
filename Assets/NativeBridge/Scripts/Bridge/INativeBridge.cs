using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ.Native.Bridge
{
    public delegate void NativeMessageCallback(string message);
    public interface INativeBridge
    {
        // NativeMessageCallback MessageCallback {get; set;}
        void AddNativeMessageListener(NativeMessageCallback listener);
        void Send(string message);

    }
}

 