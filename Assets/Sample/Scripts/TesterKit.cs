using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PJ.Native.Data;
using PJ.Native.PubSub;
using Unity.VisualScripting;
using UnityEngine;

public class TesterKit
{
    private Messenger messenger;
    public TesterKit()
    {
        messenger = new Messenger();
        Debug.Log("Testerkit handler id : ");
        messenger.Subscribe("test", OnNative);
        messenger.Subscribe("testRecall", OnTestReturn);
    }

    private void OnNative(Message message)
    {
        string data = message.Data as string;
        Debug.Log("TesterKit... arriving test : " + data);
    }

    private void OnTestReturn(Message message)
    {
        int data = (int) message.Data;
        Debug.Log("TesterKit... arriving testReturn : " + data);
    }
}
