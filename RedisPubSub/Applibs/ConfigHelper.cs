
namespace RedisPubSub.Applibs
{
    using System.Collections.Generic;

    internal static class ConfigHelper
    {
        public static readonly string RedisConn = @"localhost:6379";

        /// <summary>
        /// Redis前贅詞
        /// </summary>
        public static readonly string RedisAffixKey = "RedisPubSub";

        /// <summary>
        /// REDIS DB
        /// </summary>
        public static readonly int RedisDataBase = 15;

        public static IEnumerable<string> SubscribTopics = new string[] { "A", "B", "C" };
    }
}
