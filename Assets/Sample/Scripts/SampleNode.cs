using System;
using System.Collections;
using System.Collections.Generic;
using PJ.Native.Messenger;
using UnityEngine;

public class SampleNode : FilterNode
{
    protected override Dictionary<string, Action<MessageHolder>> OnInitialize()
    {
        return new Dictionary<string, Action<MessageHolder>>
        {
            {"testReturn", OnTestReturn}
        };
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
        this.Notify(message1);
        Message message2 = new Message();
        message2.Type = "testRecall";
        message2.Data = "second";
        this.Notify(message2);
    }
}
