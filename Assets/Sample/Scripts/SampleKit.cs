using System;
using System.Collections;
using System.Collections.Generic;
using MiniSDK.PubSub;
using MiniSDK.PubSub.Data;
using Newtonsoft.Json;
using UnityEngine;


public struct ToastData
{
    [JsonProperty(PropertyName = "toastMessage")]
    public string ToastMessage;

    [JsonProperty(PropertyName = "toastDuration")]
    public int ToastDuration;
}

public struct ToastResult
{
    [JsonProperty(PropertyName = "toastCount")]
    public string ToastCount;
}

public class SampleKit
{
    private Messenger messenger;

    public SampleKit()
    {
        messenger = new Messenger();
        Debug.Log("samplekit subscribe..  : native, testReturn" );
        messenger.Subscribe("SEND_TOAST_RESULT", OnNative);
    }

    private void OnNative(Message message)
    {
        Debug.Log("[unity pubsubtest] message toast count : " + message.Data<ToastResult>().ToastCount);
    }

    public void CallTest()
    {
        messenger.Publish(new Message("SEND_TOAST", new ToastData{ToastDuration = 1, ToastMessage = "toast of unity"}));
    }
}
