using System;
using System.Collections;
using System.Collections.Generic;
using PJ.Native.PubSub;
using PJ.Native.Proto;
using UnityEngine;

public class SampleKit
{
    private Messenger handler;

    public SampleKit()
    {
        handler = new Messenger();
        Debug.Log("samplekit handler id : " + handler.ID);
        handler.Subscribe("testReturn", OnTestReturn);
        handler.Subscribe("native", OnNative);
    } 

    private void OnTestReturn(Channel channel)
    {
        if(channel.Message.Container.TryGetValue("data", out string data))
            Debug.Log("SampleKit... SampleNode : " + data);
        else
            Debug.Log("SampleKit... SampleNode : no data");
    }

    private void OnNative(Channel channel)
    {
        if(channel.Message.Container.TryGetValue("data", out string data))
        {
            Debug.Log("SampleKit... Native : " + data);

            Message reply = new Message("nativeReturn");
            channel.Reply(reply);
        }
        else
            Debug.Log("SampleKit... Native : no data");
    }

    public void CallTest()
    {
        Container container1 = new Container();
        container1.Add("data", "first");
        Message message1 = new Message("test", container1);
        handler.Publish(message1);
        
        Container container2 = new Container();
        container2.Add("data", "second");
        Message message2 = new Message("testRecall", container2);
        handler.Publish(message2);
    }
}
