//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase;
using System;

namespace BlackFireServer.Server
{
    [System.Serializable]
    public class ServerEntity
    {
        public ServerType ServerType;
        public string Ip;
        public int Port;
        public float load;//负载0f~1f
        [NonSerialized]
        public object AppSession;
    }

}
