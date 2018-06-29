//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using SuperSocket.SocketBase.Protocol;

namespace BlackFireServer.Server
{
    public sealed class BlackFireServerRequestInfo : IRequestInfo
    {
        public BlackFireServerRequestInfo(string key, string body)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public string Key { get; private set; }

        public string Body { get; private set; }

    }
}
