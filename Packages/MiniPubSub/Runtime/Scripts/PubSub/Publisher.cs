using MiniSDK.PubSub.Data;

namespace MiniSDK.PubSub
{
    public enum PublisherType
    {
        Android     = 10000,
        IOS         = 20000,
        Game        = 30000
    }

    public class Publisher : Node
    {
        #region IdGenerator
        private static int _idGen = (int) PublisherType.Game;
        private static int IssueID() { return ++_idGen; }
        #endregion
        
        public int Id { get; } = IssueID();

        public void Publish(Message message)
        {
            MessageManager.Instance.Mediator.Publish(message, Id);
        }

    }
    
}