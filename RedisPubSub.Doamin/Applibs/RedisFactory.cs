
namespace RedisPubSub.Doamin.Applibs
{
    using StackExchange.Redis;

    public static class RedisFactory
    {
        private static ConnectionMultiplexer redisConn;

        public static ISubscriber RedisSubscriber
        {
            get
            {
                return redisConn == null ? null : redisConn.GetSubscriber();
            }
        }

        public static void Start(ConnectionMultiplexer conn)
        {
            if(redisConn != null)
            {
                return;
            }

            redisConn = conn;
        }

        public static void Stop()
        {
            if(redisConn == null)
            {
                return;
            }

            redisConn.Close();
            redisConn.Dispose();
        }
    }
}
