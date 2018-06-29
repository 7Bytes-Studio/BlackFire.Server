//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase.Protocol;
using System.Text;

namespace BlackFireServer.Server
{
    public class GatewayReceiveFilter : IReceiveFilter<GatewayRequestInfo>
    {
        public int LeftBufferSize { get; protected set; }

        public IReceiveFilter<GatewayRequestInfo> NextReceiveFilter => null;

        public FilterState State { get; protected set; }

        public GatewayRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            rest = 0;
            try
            {
                var cmdStr = Encoding.UTF8.GetString(readBuffer, offset, length);
                var s = cmdStr.Split(' ');
                State = FilterState.Normal;
                return new GatewayRequestInfo(s[0], s[1]);
            }
            catch (System.Exception)
            {
                State = FilterState.Error;
                return null;
            }
            
        }

        public void Reset()
        {
            State = FilterState.Normal;
        }
    }
}
