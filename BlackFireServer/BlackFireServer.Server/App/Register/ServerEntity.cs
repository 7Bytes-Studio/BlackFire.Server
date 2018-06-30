//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase;

namespace BlackFireServer.Server.Register
{
    [System.Serializable]
    public class ServerEntity
    {


        public ServerType ServerType { get; private set; }
        public string Ip { get; private set; }
        public string Port { get; private set; }
        public AppSession AppSession { get; private set; }

    }

}
