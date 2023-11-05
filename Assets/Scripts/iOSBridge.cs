using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace PJ.Native
{
    public class iOSBridge : INativeBridge
    {

        [DllImport("__Internal")]
        private static extern void __iOSSend(string message);
        [DllImport("__Internal")]
        private static extern void __iOSSendAndNonce(string message, int nonce);

        private int nonce = 0;
        private int Nonce => nonce++;

        private Dictionary<int, Action<string>> dicRequest;

        public void Send(string message)
        {
            __iOSSend(message);
        }

        public void Send(string message, Action<string> onReceive)
        {
            int nonce = Nonce;
            dicRequest.Add(nonce, onReceive);
            __iOSSendAndNonce(message, nonce);
            
        }
    }
}
