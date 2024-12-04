#import "sample/sample-Swift.h"

extern "C"
{
    void __iOSSampleKitLoad()
    {
        [SampleKitLoader loadModule];
    }
}