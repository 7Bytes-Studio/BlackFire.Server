//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase.Protocol;
using System.Text;

namespace BlackFireServer.Server.Business
{
    public class BusinessServerReceiveFilter : IReceiveFilter<BusinessServerRequestInfo>
    {
        public int LeftBufferSize { get; protected set; }

        public IReceiveFilter<BusinessServerRequestInfo> NextReceiveFilter => null;

        public FilterState State { get; protected set; }

        public BusinessServerRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            rest = 0;
            LeftBufferSize = length;
            State = FilterState.Normal;
            try
            {
                var cmdStr = Encoding.UTF8.GetString(readBuffer, offset, length);
                //System.Console.Write(cmdStr);
                if (cmdStr.Contains(" "))
                {
                    var s = cmdStr.Split(' ');
                    if (1 <= s.Length)
                    {
                        return new BusinessServerRequestInfo(s[0],cmdStr.Substring(s[0].Length));
                    }
                }
                return new BusinessServerRequestInfo(cmdStr.Trim(), string.Empty);
            }
            catch (System.Exception)
            {
                //日志打印
                State = FilterState.Error;
            }
            return null;
        }

        public void Reset()
        {
            State = FilterState.Normal;
        }
    }
}
