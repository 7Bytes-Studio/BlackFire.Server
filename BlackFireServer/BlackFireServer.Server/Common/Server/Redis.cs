using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFireServer.Server
{
    public static class Redis
    {
        private static ConnectionMultiplexer s_Redis;

        private static IDatabase s_DB;

        public static void Init(string host)
        {
            s_Redis = ConnectionMultiplexer.Connect(host);
            s_DB = s_Redis.GetDatabase();
        }

        public static void Set(string key,string value)
        {
            s_DB.StringSet(key,value);
        }

        public static string Get(string key)
        {
            return s_DB.StringGet(key);
        }

    }
}
