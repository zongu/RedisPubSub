﻿
namespace RedisPubSub.Doamin.Applibs
{
    using Newtonsoft.Json;

    public static class RedisProducer
    {
        /// <summary>
        /// 發布事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="topicName">發布Topic目標</param>
        /// <param name="data">事件內容</param>
        /// <param name="rmqExpiration">訊息存活時間(預設1天)</param>
        public static void Publish<T>(string topicName, T data, string rmqExpiration = "86400000")
        {
            var sub = RedisFactory.RedisSubscriber;
            sub.Publish(topicName, JsonConvert.SerializeObject(data));
        }
    }
}
