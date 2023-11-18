//
//  iOSUnityBridge.h
//  UnityFramework
//
//  Created by sangmin on 11/16/23.
//

#ifndef iOSUnityBridge_h
#define iOSUnityBridge_h

#import <Foundation/Foundation.h>

typedef void (*NativeBridgeCallback)(const char* message);

@interface iOSUnityBridge : NSObject
{
    NativeBridgeCallback callback;
}

-(void) initializeWith : (NativeBridgeCallback) bridgeCallback;
-(void) send : (NSString*) message;
@end

#endif /* iOSUnityBridge_h */
