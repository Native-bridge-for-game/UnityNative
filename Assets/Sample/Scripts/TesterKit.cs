using System.Collections;
using System.Collections.Generic;
using PJ.Native.Proto;
using PJ.Native.PubSub;
using UnityEngine;

public class TesterKit
{
    private Messenger messenger;
    public TesterKit()
    {
        messenger = new Messenger(Tag.Game);
        messenger.Subscribe("native", OnNative);
        messenger.Subscribe("testReturn", OnTestReturn);
    }

    private void OnNative(Channel channel)
    {
        if(channel.Message.Container.TryGetValue("data", out string data))
        {
            Debug.Log("TesterKit... Native : " + data);
        }
        else
            Debug.Log("TesterKit... Native : no data");
    }

    private void OnTestReturn(Channel channel)
    {
        if(channel.Message.Container.TryGetValue("data", out string data))
            Debug.Log("TesterKit... Error arriving : " + data);
        else
            Debug.Log("TesterKit... Error arriving : no data");
    }
}
