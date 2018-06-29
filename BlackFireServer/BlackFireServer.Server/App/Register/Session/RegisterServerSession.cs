//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using SuperSocket.SocketBase;

namespace BlackFireServer.Server.Register
{
    public class RegisterServerSession : AppSession<RegisterServerSession,RegisterServerRequestInfo>
    {
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
        }
    }
}
