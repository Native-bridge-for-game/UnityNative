using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public class Message
    {
        public string Key;
        public  string Data;

        public Message(string key, string data)
        {
            this.Key = key;
            this.Data = data;
        }
    }

}
