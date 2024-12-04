using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void __iOSSampleKitLoad();
#endif
    private Messenger messenger;
    private bool isInitialized = false;

    public SampleKit()
    {
        messenger = new Messenger();
        Debug.Log("samplekit subscribe..  : native, testReturn" );
        messenger.Subscribe("SEND_TOAST_RESULT", OnNative);
    }

    private void InitializeModule()
    {
#if UNITY_ANDROID
        AndroidJavaClass javaClass = new AndroidJavaClass("com.pj.sample.SampleKitLoader");
        javaClass.CallStatic("load");
#elif UNITY_IOS
        __iOSSampleKitLoad(); 
#endif
    }

    private void OnNative(Message message)
    {
        Debug.Log("[unity pubsubtest] message toast count : " + message.Data<ToastResult>().ToastCount);
    }

    public void CallTest()
    {
        if (isInitialized == false)
        {
            isInitialized = true;
            InitializeModule();       
        }
        messenger.Publish(new Message("SEND_TOAST", new ToastData{ToastDuration = 1, ToastMessage = "toast of unity"}));
    }
}
