using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ.Native.Messenger
{
    public interface MessageHolder
    {
        Message Message {get;}
        void GiveBack(Message message);
    }    
}
