#import "MiniPubSub/ObjcSide.h"

extern "C"
{
    void __iOSInitialize(NativeMessageCallback messageCallback)
    {
        [[ObjcSide sharedInstance] initializeWith:messageCallback];
    }

    void __iOSSend(const char* infoCStr, const char* jsonCStr)
    {
        [[ObjcSide sharedInstance] sendToNativeWithInfo:infoCStr AndData:jsonCStr];
    }
}
