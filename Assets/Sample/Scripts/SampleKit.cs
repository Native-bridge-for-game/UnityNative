using System;
using System.Collections;
using System.Collections.Generic;
using PJ.Native.PubSub;
using PJ.Native.Proto;
using UnityEngine;

public class SampleKit
{
    private Messenger messenger;

    public SampleKit()
    {
        messenger = new Messenger();
        Debug.Log("samplekit handler id : " + messenger.ID);
        messenger.SetTagRule(Tag.Game);
        messenger.SetBaseTag(Tag.Native);
        messenger.Subscribe("testReturn", OnTestReturn);
        messenger.Subscribe("native", OnNative);
    } 

    private void OnTestReturn(Message message)
    {
        if(message.Container.TryGetValue("data", out string data))
            Debug.Log("SampleKit... SampleNode : " + data);
        else
            Debug.Log("SampleKit... SampleNode : no data");
    }

    private void OnNative(Message message)
    {
        if(message.Container.TryGetValue("data", out string data))
        {
            Debug.Log("SampleKit... Native : " + data);

            Message reply = new Message("nativeReturn");
            messenger.Publish(reply);
        }
        else
            Debug.Log("SampleKit... Native : no data");
    }

    public void CallTest()
    {
        Container container1 = new Container();
        container1.Add("data", "first");
        Message message1 = new Message("test", container1);
        messenger.Publish(message1);
        
        Container container2 = new Container();
        container2.Add("data", "second");
        Message message2 = new Message("testRecall", container2);
        messenger.Publish(message2);
    }
}
