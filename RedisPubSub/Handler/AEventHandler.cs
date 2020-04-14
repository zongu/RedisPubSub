
namespace RedisPubSub.Handler
{
    using System;
    using Newtonsoft.Json;
    using RedisPubSub.Doamin.Model;
    using RedisPubSub.Model;

    /// <summary>
    /// 事件A解析
    /// </summary>
    public class AEventHandler : IRedisPubSubHandler
    {
        public void Handle(RedisEventStream stream)
        {
            var @event = JsonConvert.DeserializeObject<AEvent>(stream.Data);
            Console.WriteLine(@event.Message);
        }
    }
}
