using PJ.Native.Proto;
using Google.Protobuf;

namespace PJ.Native.Messenger
{
    public static class ContainerExtensions
    {
        public static void Add(this Container self, string key, bool value)
        {
            self.BoolMap.Add(key, value);
        }
        public static void Add(this Container self, string key, int value)
        {
            self.IntMap.Add(key, value);
        }
        public static void Add(this Container self, string key, float value)
        {
            self.FloatMap.Add(key, value);
        }
        public static void Add(this Container self, string key, string value)
        {
            self.StringMap.Add(key, value);
        }
        public static void Add(this Container self, string key, byte[] value)
        {
            self.BytesMap.Add(key, ByteString.CopyFrom(value));
        }
        public static void Add(this Container self, string key, Container container)
        {
            self.ContainerMap.Add(key, container);
        }

        public static bool TryGetValue(this Container self, string key, out bool value)
        {
            return self.BoolMap.TryGetValue(key, out value);
        }
        public static bool TryGetValue(this Container self, string key, out int value)
        {
            return self.IntMap.TryGetValue(key, out value);
        }
        public static bool TryGetValue(this Container self, string key, out float value)
        {
            return self.FloatMap.TryGetValue(key, out value);
        }
        public static bool TryGetValue(this Container self, string key, out string value)
        {
            return self.StringMap.TryGetValue(key, out value);
        }
        public static bool TryGetValue(this Container self, string key, out byte[] value)
        {
            if(self.BytesMap.TryGetValue(key, out ByteString byteString))
            {
                value = byteString.ToByteArray();
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
    }
}
