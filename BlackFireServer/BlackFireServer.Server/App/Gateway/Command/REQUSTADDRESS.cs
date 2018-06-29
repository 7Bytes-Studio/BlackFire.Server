//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase.Command;

namespace BlackFireServer.Server.Command
{
    public sealed class REQUSTADDRESS : CommandBase<BlackFireServerSession, BlackFireServerRequestInfo>
    {
        public override void ExecuteCommand(BlackFireServerSession session, BlackFireServerRequestInfo requestInfo)
        {
            System.Console.WriteLine(requestInfo.Key);
            System.Console.WriteLine(requestInfo.Body);           
        }
    }
}
