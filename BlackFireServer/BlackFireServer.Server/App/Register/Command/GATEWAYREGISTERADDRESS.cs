//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase.Command;

namespace BlackFireServer.Server.Register
{
    public sealed class GATEWAYREGISTERADDRESS : CommandBase<RegisterServerSession,RegisterServerRequestInfo>
    {
        public override void ExecuteCommand(RegisterServerSession session,RegisterServerRequestInfo requestInfo)
        {
            RegisterStorage.SetGatewayServerEntity(session);
            Command.SendRegisterCommand_Welcome(session);
            Command.SendRegisterCommand_UpdateAddress();
        }
    }
}
