//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireServer.Server.Gateway;
using SuperSocket.SocketBase.Command;
using System.Text;

namespace BlackFireServer.Server.Register
{
    public sealed class CONNECTREGISTERADDRESS : CommandBase<RegisterServerSession,RegisterServerRequestInfo>
    {
        public override void ExecuteCommand(RegisterServerSession session,RegisterServerRequestInfo requestInfo)
        {
            RegisterStorage.SetConnectServerEntity(session);
            Command.SendRegisterCommand_Welcome(session);
            Command.SendRegisterCommand_UpdateAddress();
        }
    }
}
