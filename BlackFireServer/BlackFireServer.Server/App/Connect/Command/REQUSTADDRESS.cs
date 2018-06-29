//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase.Command;

namespace BlackFireServer.Server.Connect
{
    public sealed class CLIENTREQUSTADDRESS : CommandBase<ConnectServerSession,ConnectServerRequestInfo>
    {
        public override void ExecuteCommand(ConnectServerSession session,ConnectServerRequestInfo requestInfo)
        {
            session.TrySend("RESPONSEADDRESS");
        }
    }
}
