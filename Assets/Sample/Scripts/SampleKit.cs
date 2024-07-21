using System;
using System.Collections;
using System.Collections.Generic;
using PJ.Native.PubSub;
using PJ.Native.Data;
using UnityEngine;

public class SampleKit
{
    private Messenger messenger;

    public SampleKit()
    {
        messenger = new Messenger();
        Debug.Log("samplekit handler id : " );
        messenger.Subscribe("native", OnNative);
    } 

    private void OnTestReturn(Message message)
    {
        
    }

    private void OnNative(Message message)
    {
        Debug.Log($"[pubsubtest] form native key :{message.Key}   Data : {message.Data}");
    }

    public void CallTest()
    {
        // messenger.Publish(message2);
        messenger.Publish(new Message("test", "hi"));
        messenger.Publish(new Message("testRecall", 1234));
    }
}
