#import <UIKit/UIKit.h>
#import <iOSUnityBridge.h>

iOSUnityBridge* unityBridge;

extern "C"
{
    void __iOSInitialize(NativeMessageCallback unityCallback)
    {
        unityBridge = [[iOSUnityBridge alloc] init];
        [unityBridge initializeWith:unityCallback];
    }

    void __iOSSend(const char* message, int nonce)
    {
        [unityBridge send:[NSString stringWithUTF8String:message]];
    }
}
