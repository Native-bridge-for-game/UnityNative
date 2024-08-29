using System.Collections.Generic;

namespace PJ.Native.Data
{
    public class Message
    {
        public string Key;
        public object Data;
        
        public Message(string key, object data)
        {
            Key = key;
            Data = data;
        }
    }
    
}