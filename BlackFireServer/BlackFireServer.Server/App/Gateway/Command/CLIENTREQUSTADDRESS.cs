//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase.Command;

namespace BlackFireServer.Server.Gateway
{
    public sealed class CLIENTREQUSTADDRESS : CommandBase<GatewayServerSession, GatewayServerRequestInfo>
    {
        public override void ExecuteCommand(GatewayServerSession session, GatewayServerRequestInfo requestInfo)
        {
            System.Console.WriteLine(requestInfo.Key);
            System.Console.WriteLine(requestInfo.Body);   
            //返回以获取到的Connect地址。
        }
    }
}
