//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase.Command;

namespace BlackFireServer.Server.Register
{
    public sealed class BUSINESSREGISTERADDRESS : CommandBase<RegisterServerSession,RegisterServerRequestInfo>
    {
        public override void ExecuteCommand(RegisterServerSession session,RegisterServerRequestInfo requestInfo)
        {
            var data = "REGISTERRESPONSEADDRESS {返回基本状态给业务服务器}".ToUTF8Bytes();
            session.Send(data, 0, data.Length);
        }
    }
}
