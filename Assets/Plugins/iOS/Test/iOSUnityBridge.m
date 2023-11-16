//
//  iOSUnityBridge.m
//  UnityFramework
//
//  Created by sangmin on 11/16/23.
//

#import <Foundation/Foundation.h>
#import <iOSUnityBridge.h>

@implementation iOSUnityBridge
- (void)initializeWith:(NativeBridgeCallback)bridgeCallback {
    self->callback = bridgeCallback;
}
- (void)send:(NSString *)message{
    self->callback([message UTF8String]);
}

@end
