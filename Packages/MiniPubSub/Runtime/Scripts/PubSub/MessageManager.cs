using System;

using MiniSDK.Core.Util;

namespace MiniSDK.PubSub
{
    public class MessageManager : Singleton<MessageManager>
    {
        private Lazy<MessageMediator> lazyMediator = new Lazy<MessageMediator>(()=> new MessageMediatorImpl());
        public MessageMediator Mediator => lazyMediator.Value;
    }
}