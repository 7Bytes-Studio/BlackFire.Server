//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using SuperSocket.SocketBase.Protocol;

namespace BlackFireServer.Server
{
    public sealed class GatewayRequestInfo : IRequestInfo
    {
        public GatewayRequestInfo(string key, string json)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Json = json ?? throw new ArgumentNullException(nameof(json));
        }

        public string Key { get; private set; }

        public string Json { get; private set; }
    }
}
