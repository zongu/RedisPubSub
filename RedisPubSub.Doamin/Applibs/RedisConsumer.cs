
namespace RedisPubSub.Doamin.Applibs
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using RedisPubSub.Doamin.Model;

    public class RedisConsumer
    {

        private IEnumerable<string> topics;

        private IPubSubDispatcher<RedisEventStream> dispatcher;

        public RedisConsumer(IEnumerable<string> topics, IPubSubDispatcher<RedisEventStream> dispatcher)
        {
            this.topics = topics;
            this.dispatcher = dispatcher;
        }

        public void Register()
        {
            this.topics.ToList().ForEach(t =>
            {
                var sub = RedisFactory.RedisSubscriber;
                sub.Subscribe(t, (topic, message) =>
                {
                    var @event = JsonConvert.DeserializeObject<RedisEventStream>(message.ToString());
                    this.dispatcher.DispatchMessage(@event);
                });
            });
        }
    }
}
