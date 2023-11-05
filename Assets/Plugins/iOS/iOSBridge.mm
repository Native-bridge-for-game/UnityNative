#import <UIKit/UIKit.h>

extern "C"
{
    void __iOSSend(const char* message)
    {
        NSLog(@"%s", message);
    }
    
    void __iOSSendAndNonce(const char* message, int nonce)
    {
        NSLog(@"%d - %s", nonce, message);
    }
}
