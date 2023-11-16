#import <UIKit/UIKit.h>
#import <iOSUnityBridge.h>

//typedef void (*NativeBridgeCallback)(const char* message, int nonce);

NativeBridgeCallback callback;

iOSUnityBridge* unityBridge;

extern "C"
{
    void __iOSInitializeTest(NativeBridgeCallback unityCallback)
    {
        unityBridge = [[iOSUnityBridge alloc] init];
        [unityBridge initializeWith:unityCallback];
    }

    void __iOSSendTest(const char* message, int nonce)
    {
        [unityBridge send:[NSString stringWithUTF8String:message]];
    }
}
