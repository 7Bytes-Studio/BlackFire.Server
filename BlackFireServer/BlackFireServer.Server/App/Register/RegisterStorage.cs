//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using BlackFireServer.Server.Gateway;
using BlackFireServer.Server.Business;

namespace BlackFireServer.Server.Register
{
    public static class RegisterStorage
    {
        private static ServerEntity s_GatewayServer = null;

        private static LinkedList<ServerEntity> s_ConnectServerEntityLinkedList = new LinkedList<ServerEntity>();
        private static LinkedList<ServerEntity> s_BusinessServerEntityLinkedList = new LinkedList<ServerEntity>();

        public static void Set(ServerType serverType,ServerEntity serverEntity)
        {
            switch (serverType)
            {
                case ServerType.Gateway:
                    s_GatewayServer = serverEntity;
                    break;
                case ServerType.Connect:
                    if (!HasServerEntity(s_ConnectServerEntityLinkedList,serverEntity.Ip,serverEntity.Port))
                    {
                        s_ConnectServerEntityLinkedList.AddLast(serverEntity);
                    }
                    break;
                case ServerType.Business:
                    if (!HasServerEntity(s_BusinessServerEntityLinkedList,serverEntity.Ip,serverEntity.Port))
                    {
                        s_BusinessServerEntityLinkedList.AddLast(serverEntity);
                    }
                    break;
                default:
                    break;
            }
        }

        public static void SetGatewayServerEntity(RegisterServerSession session)
        {
            RegisterStorage.Set(ServerType.Gateway, new ServerEntity()
            {
                Ip = session.RemoteEndPoint.Address.ToString(),
                Port = session.RemoteEndPoint.Port,
                AppSession = session,
                ServerType = ServerType.Gateway
            });
        }

        public static void SetConnectServerEntity(RegisterServerSession session)
        {
            RegisterStorage.Set(ServerType.Connect, new ServerEntity()
            {
                Ip = session.RemoteEndPoint.Address.ToString(),
                Port = session.RemoteEndPoint.Port,
                AppSession = session,
                ServerType = ServerType.Connect
            });
        }

        public static void SetBusinessServerEntity(RegisterServerSession session)
        {
            RegisterStorage.Set(ServerType.Business, new ServerEntity()
            {
                Ip = session.RemoteEndPoint.Address.ToString(),
                Port = session.RemoteEndPoint.Port,
                AppSession = session,
                ServerType = ServerType.Business
            });
        }

        public static void Del(string ip, int port)
        {
            var current = s_ConnectServerEntityLinkedList.First;
            while (null != current)
            {
                if (current.Value.Ip == ip && current.Value.Port == port)
                {
                    s_ConnectServerEntityLinkedList.Remove(current);
                }
                current = current.Next;
            }
            current = s_BusinessServerEntityLinkedList.First;
            while (null != current)
            {
                if (current.Value.Ip == ip && current.Value.Port == port)
                {
                    s_ConnectServerEntityLinkedList.Remove(current);
                }
                current = current.Next;
            }
        }

        private static bool HasServerEntity(LinkedList<ServerEntity> serverEntities,string ip,int port)
        {
            var current = serverEntities.First;
            while (null!=current)
            {
                if ( current.Value.Ip == ip && current.Value.Port == port)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public static void Foreach(ServerType serverType,Action<ServerEntity> action)
        {
            switch (serverType)
            {
                case ServerType.Gateway:
                    if(null!=s_GatewayServer)
                        action.Invoke(s_GatewayServer);
                    break;
                case ServerType.Connect:
                    var current1 = s_ConnectServerEntityLinkedList.First;
                    while (null != current1)
                    {
                        action.Invoke(current1.Value);
                        current1 = current1.Next;
                    }
                    break;
                case ServerType.Business:
                    var current2 = s_BusinessServerEntityLinkedList.First;
                    while (null != current2)
                    {
                        action.Invoke(current2.Value);
                        current2 = current2.Next;
                    }
                    break;
                default:
                    break;
            }
        }

        public static string GetConnectsSerializeString()
        {
            JObject jo = new JObject();
            JArray jar = new JArray();
            var current = s_ConnectServerEntityLinkedList.First;
            while (null != current)
            {
                jar.Add(JsonConvert.SerializeObject(current.Value));
                current = current.Next;
            }
            jo.Add("Connects",jar);
            return jo.ToString(Formatting.None);
            //" {\"Connects\":[\"{\\\"ServerType\\\":3,\\\"Ip\\\":\\\"127.0.0.1\\\",\\\"Port\\\":50410,\\\"load\\\":0.0}\"]}"
        }

        public static string GetBusinessSerializeString()
        {
            JObject jo = new JObject();
            JArray  jar = new JArray();

            var current = s_BusinessServerEntityLinkedList.First;
            while (null != current)
            {
                jar.Add(JsonConvert.SerializeObject(current.Value));
                current = current.Next;
            }

            jo.Add("Businesses",jar);
            return jo.ToString(Formatting.None);
        }

    }
}
