//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.ProtoBase;
using System.Text;

namespace BlackFireServer.Client
{
    public sealed class BlackFireClientReceiveFilter : IReceiveFilter<BlackFireClientPackageInfo>
    {
        public IReceiveFilter<BlackFireClientPackageInfo> NextReceiveFilter => null;

        public FilterState State { get; private set; }

        public BlackFireClientPackageInfo Filter(BufferList data, out int rest)
        {
            rest = 0;
            State = FilterState.Normal;
            try
            {
                var cmdStr = Encoding.UTF8.GetString(data, 0, data.Total);
                //System.Console.Write(cmdStr);
                if (cmdStr.Contains(" "))
                {
                    var s = cmdStr.Split(' ');
                    if (1 <= s.Length)
                    {
                        return new BlackFireClientPackageInfo(s[0], s[1]);
                    }
                }
                return new BlackFireClientPackageInfo(cmdStr.Trim(),string.Empty);
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
