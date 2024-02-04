using System;
using System.Collections;
using System.Collections.Generic;
using PJ.Native.Messenger;
using UnityEngine;

public class SampleKit
{
    private MessageHandler handler;

    public SampleKit()
    {
        handler = new MessageHandler();
        handler.SetHandler("testReturn", OnTestReturn);
    } 

    private void OnTestReturn(MessageHolder messageHolder)
    {
        Debug.Log("Unity... SampleNode : " + messageHolder.Message.Data);
    }

    public void CallTest()
    {
        Message message1 = new Message();
        message1.Type = "test";
        message1.Data = "first";
        handler.Notify(message1);
        Message message2 = new Message();
        message2.Type = "testRecall";
        message2.Data = "second";
        handler.Notify(message2);
    }
}
