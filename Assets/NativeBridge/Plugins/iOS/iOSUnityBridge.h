//
//  iOSUnityBridge.h
//  UnityFramework
//
//  Created by sangmin on 11/16/23.
//

#ifndef iOSUnityBridge_h
#define iOSUnityBridge_h

#import <Foundation/Foundation.h>

typedef void (*NativeMessageCallback)(const char* message);

@interface iOSUnityBridge : NSObject
{
    NativeMessageCallback messageCallback;
}

-(void) initializeWith : (NativeMessageCallback) bridgeCallback;
-(void) send : (NSString*) message;
@end

#endif /* iOSUnityBridge_h */
