//
//  iOSUnityBridge.m
//  UnityFramework
//
//  Created by sangmin on 11/16/23.
//

#import <Foundation/Foundation.h>
#import <iOSUnityBridge.h>

@implementation iOSUnityBridge
- (void)initializeWith:(NativeMessageCallback)bridgeCallback {
    self->messageCallback = bridgeCallback;
    self->messageCallback("ios native - init complete");
}
- (void)send:(NSString *)message{
    NSLog(@"from unity message : %@", message);
    self->messageCallback([message UTF8String]);
}

@end
