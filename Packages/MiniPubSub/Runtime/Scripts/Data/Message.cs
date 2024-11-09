using Newtonsoft.Json;

namespace MiniSDK.PubSub.Data
{
    public struct MessageInfo
    {
        [JsonProperty(PropertyName = "key")]
        public string Key;
    }
    
    public struct Message
    {
        [JsonProperty(PropertyName = "info")] 
        public MessageInfo Info;
        [JsonProperty(PropertyName = "json")]
        public string Json;

        public string Key => Info.Key;
        public T Data<T>()
        {
            return JsonConvert.DeserializeObject<T>(Json);
        }
        
        public Message(string key, object data)
        {
            Info = new MessageInfo { Key = key };
            Json = JsonConvert.SerializeObject(data);
        }
    }
    
}
