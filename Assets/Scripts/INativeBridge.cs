using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ.Native
{
    public interface INativeBridge
    {
        void Send(string message);
        void Send(string message, Action<string> onReceive);
    }
}

 