using BlackFireServer.Server.Register;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFireServer.Server
{
    public static class ServerStorage
    {
        private static List<ServerEntity> s_ConnectServers = new List<ServerEntity>();
        public static List<ServerEntity> ConnectServers { get { return s_ConnectServers; } }

        public static void DelAll()
        {
            ConnectServers.Clear();
        }

        public static void Add(string json)
        {
            var entity = Newtonsoft.Json.JsonConvert.DeserializeObject<ServerEntity>(json);
            ConnectServers.Add(entity);
        }

        public static void UpdateConnectServerList(string json)
        {
            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(json.Trim());
                if (null != jo && null != jo["Connects"])
                {
                    JArray jar = jo["Connects"] as JArray;
                    ServerStorage.DelAll();
                    for (int i = 0; i < jar.Count; i++)
                    {
                        ServerStorage.Add(jar[i].ToString());
                    }
                }
            }
            catch (Exception)
            {

            }
        }

    }





}
