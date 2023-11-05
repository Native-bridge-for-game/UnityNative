package com.pj.nativecore;

import android.util.Log;

public class NativeBridge{

    // private static AndroidBridge instance;

    // public static AndroidBridge Instance(){
    //     if(instance == null){
    //         instance = new AndroidBridge();
    //     }
    //     return instance;
    // }

    private NativeBridgeCallback unityCallback;

    public void initialize(NativeBridgeCallback unityCallback){
        this.unityCallback = unityCallback;
    }

    public void send(String message){
        Log.d("AndroidBridge", "android - java - message : " + message);
    }

    public void send(String message, int nonce){
        message += " ~~~ from java ~~~";
        Log.d("AndroidBridge", "android - java - message : " + message + " and return~~");
        this.unityCallback.onReceive(message, nonce);
    }
}
