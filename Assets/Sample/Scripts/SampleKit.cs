using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MiniSDK.Core.Module;
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

public class SampleKit : MessengerModuleBase
{
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void __iOSSampleKitLoad();
#endif

    public override void Initialize()
    {
        base.Initialize();
        Messenger.Subscribe("SEND_TOAST_RESULT", OnNative);
    }

    protected override void InitializeNativeModule()
    {
        base.InitializeNativeModule();
#if UNITY_ANDROID
        AndroidJavaObject loaderObject = new AndroidJavaObject("com.pj.sample.SampleKitLoader");
        loaderObject.Call<string>("loadModule");
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
        Messenger.Publish(new Message("SEND_TOAST", new ToastData{ToastDuration = 1, ToastMessage = "toast of unity"}));
    }
}
