#import <UIKit/UIKit.h>

typedef void (*NativeBridgeCallback)(const char* message, int nonce);

NativeBridgeCallback callback;

extern "C"
{
    void __iOSInitialize(NativeBridgeCallback unityCallback)
    {
        callback = unityCallback;
    }

    void __iOSSend(const char* message, int nonce)
    {
        NSLog(@"(!!ios) : %s", message);
        callback(message, nonce);
    }
}
