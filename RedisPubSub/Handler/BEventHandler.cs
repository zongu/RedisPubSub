
namespace RedisPubSub.Handler
{
    using System;
    using Newtonsoft.Json;
    using RedisPubSub.Doamin.Model;
    using RedisPubSub.Model;

    public class BEventHandler : IRedisPubSubHandler
    {
        public void Handle(RedisEventStream stream)
        {
            var @event = JsonConvert.DeserializeObject<BEvent>(stream.Data);
            Console.WriteLine(@event.Message);
        }
    }
}
