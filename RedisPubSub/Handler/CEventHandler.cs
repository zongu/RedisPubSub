
namespace RedisPubSub.Handler
{
    using System;
    using Newtonsoft.Json;
    using RedisPubSub.Doamin.Model;
    using RedisPubSub.Model;

    public class CEventHandler : IRedisPubSubHandler
    {
        public void Handle(RedisEventStream stream)
        {
            var @event = JsonConvert.DeserializeObject<CEvent>(stream.Data);
            Console.WriteLine(@event.Message);
        }
    }
}
