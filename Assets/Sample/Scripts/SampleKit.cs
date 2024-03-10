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
        handler = new Messenger(Tag.Game);
        handler.Subscribe("testReturn", OnTestReturn);
        handler.Subscribe("native", OnNative);
    } 

    private void OnTestReturn(MessageHolder messageHolder)
    {
        if(messageHolder.Message.Container.TryGetValue("data", out string data))
            Debug.Log("Unity... SampleNode : " + data);
        else
            Debug.Log("Unity... SampleNode : no data");
    }

    private void OnNative(MessageHolder messageHolder)
    {
        if(messageHolder.Message.Container.TryGetValue("data", out string data)){
            Debug.Log("Unity... Native : " + data);

            // Message reply = new Message("nativeReturn");
            // reply.Envelope.SenderID = handler.ID;
            // reply.Envelope.ReceiverID = messageHolder.Message.Envelope.SenderID;
            // messageHolder.Reply(reply);
        }
        else
            Debug.Log("Unity... Native : no data");
    }

    public void CallTest()
    {
        Container container1 = new Container();
        container1.Add("data", "first");
        Message message1 = new Message("test", container1);
        message1.Envelope.SenderID = handler.ID;
        handler.Publish(message1, Tag.Native);
        
        Container container2 = new Container();
        container2.Add("data", "second");
        Message message2 = new Message("testRecall", container2);
        message2.Envelope.SenderID = handler.ID;
        handler.Publish(message2, Tag.Native);
    }
}
