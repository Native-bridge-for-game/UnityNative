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
        handler = new MessageHandler(Tag.Game);
        handler.SetHandler("testReturn", OnTestReturn);
        handler.SetHandler("native", OnNative);
    } 

    private void OnTestReturn(MessageHolder messageHolder)
    {
        Debug.Log("Unity... SampleNode : " + messageHolder.Message.Data);
    }

    private void OnNative(MessageHolder messageHolder)
    {
        Debug.Log("Unity... Native : " + messageHolder.Message.Data);
    }

    public void CallTest()
    {
        Message message1 = new Message("test", "first");
        handler.Notify(message1, Tag.Native);
        Message message2 = new Message("testRecall", "second");
        handler.Notify(message2, Tag.Native);
    }
}
