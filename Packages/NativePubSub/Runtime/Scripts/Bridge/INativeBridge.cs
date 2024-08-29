using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ.Native.Bridge
{
    public delegate void NativeByteCallback(byte[] data);

    public delegate void NativeStringCallback(string data);
    
    public interface INativeBridge
    {
        void SetNativeByteListener(NativeByteCallback listener);
        void SetNativeStringListener(NativeStringCallback listener);
        void Send(byte[] data);
        void Send(string json);
    }
}

 