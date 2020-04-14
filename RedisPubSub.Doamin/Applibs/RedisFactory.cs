
namespace RedisPubSub.Doamin.Applibs
{
    using StackExchange.Redis;

    public static class RedisFactory
    {
        private static ConnectionMultiplexer redisConn;

        private static int _dataBase;

        private static string _affixKey;

        public static string AffixKey
        {
            get
                => _affixKey;
        }

        public static ISubscriber RedisSubscriber
        {
            get
            {
                if(redisConn == null)
                {
                    return null;
                }

                redisConn.GetDatabase(_dataBase);
                return redisConn.GetSubscriber();
            }
        }

        public static void Start(ConnectionMultiplexer conn, string affixKey, int dataBase)
        {
            if(redisConn != null)
            {
                return;
            }

            redisConn = conn;
            _affixKey = affixKey;
            _dataBase = dataBase;
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
