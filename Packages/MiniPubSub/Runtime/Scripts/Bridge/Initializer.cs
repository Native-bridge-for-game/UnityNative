using UnityEngine;

namespace MiniSDK.Native
{
    public static class Initializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        public static void Initialize()
        {
            NativeRelay.Instance.Start();
        }
    }
}