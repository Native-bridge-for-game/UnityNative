package com.pj.nativecore;

import android.util.Log;

public interface NativeBridgeCallback{
    public void onReceive(String message, int nonce);
}