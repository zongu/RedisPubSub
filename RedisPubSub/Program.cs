﻿
namespace RedisPubSub
{
    using System;
    using RedisPubSub.Applibs;
    using RedisPubSub.Doamin.Applibs;
    using RedisPubSub.Doamin.Model;
    using RedisPubSub.Model;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RedisFactory.Start(NoSqlService.RedisConnections, NoSqlService.RedisAffixKey, NoSqlService.RedisDataBase);
                var consumer = new RedisConsumer(ConfigHelper.SubscribTopics, new PubSubDispatcher<RedisEventStream>(AutofacConfig.Container));
                consumer.Register();

                RedisProducer.Publish("A", new AEvent() { Message = $"{nameof(AEvent)}:{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}" });
                RedisProducer.Publish("B", new AEvent() { Message = $"{nameof(BEvent)}:{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}" });
                RedisProducer.Publish("C", new AEvent() { Message = $"{nameof(CEvent)}:{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
