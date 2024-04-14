using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PJ.Native.Proto;
using PJ.Native.PubSub;
using UnityEngine;

public class TesterKit
{
    private Messenger messenger;
    public TesterKit()
    {
        messenger = new Messenger();
        string[] t = {"aa","bb","cc"};
        // var at = t.Aggregate("", (a,b) => a + b);
        // Debug.Log(at);
        Debug.Log("Testerkit handler id : " + messenger.ID);
        messenger.Subscribe("native", OnNative);
        messenger.Subscribe("testReturn", OnTestReturn);
    }

    private void OnNative(Message message)
    {
        if(message.Container.TryGetValue("data", out string data))
        {
            Debug.Log("TesterKit... Native : " + data);
        }
        else
            Debug.Log("TesterKit... Native : no data");
    }

    private void OnTestReturn(Message message)
    {
        if(message.Container.TryGetValue("data", out string data))
            Debug.Log("TesterKit... Error arriving : " + data);
        else
            Debug.Log("TesterKit... Error arriving : no data");
    }
}
