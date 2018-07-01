using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFireServer.Server.Business
{
    internal sealed class Login : CommandBase<BusinessServerSession, BusinessServerRequestInfo>
    {
        public override void ExecuteCommand(BusinessServerSession session, BusinessServerRequestInfo requestInfo)
        {

        }
    }
}
