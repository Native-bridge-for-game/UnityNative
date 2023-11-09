#import <UIKit/UIKit.h>

typedef void (*NativeBridgeCallback)(const chat* message, int nonce)

NativeBridgeCallback* callback;

extern "C"
{
    void __iOSInitialize(NativeBridgeCallback unityCallback)
    {
        callback = unityCallback;
    }

    void __iOSSend(const char* message)
    {
        NSLog(@"(!!ios) : %s", message);
    }
    
    void __iOSSendAndNonce(const char* message, int nonce)
    {
        NSLog(@"(!!ios) : %d - %s", nonce, message);

        

        callback()
    }
}
