//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;
using BlackFireServer.Server.Interface;
using SuperSocket.SocketBase;

namespace BlackFireServer.Server.Business
{
    public class BusinessServerSession : AppSession<BusinessServerSession, BusinessServerRequestInfo>
    {
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
            var args = ClientEventArgs.Spawn<ClientEventArgs>();
            args.Client = new Interface.Client(this);
            Event.Fire("BusinessServer/OnConnect",this, args);
        }

        public override void Close()
        {
            base.Close();
            var args = ClientEventArgs.Spawn<ClientEventArgs>();
            args.Client = new Interface.Client(this);
            Event.Fire("BusinessServer/OnClose",this, args);
        }
    }
}
