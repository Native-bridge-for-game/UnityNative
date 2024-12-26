using MiniSDK.PubSub;

namespace MiniSDK.Core.Module
{
    public abstract class ModuleBase
    {
        protected bool IsInitialized { get; private set; }
        protected virtual void InitializeNativeModule()
        {
            
        }

        public virtual void Initialize()
        {
            IsInitialized = true;
            InitializeNativeModule();
        }
    }

    public abstract class MessengerModuleBase : ModuleBase
    {

        protected Messenger Messenger { get; private set; }
        
        public override void Initialize()
        {
            base.Initialize();
            Messenger = new Messenger();           
        }
    }
    
    public abstract class WatcherModuleBase : ModuleBase
    {
        protected Watcher Watcher { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
            Watcher = new Watcher();
        }
    }
}