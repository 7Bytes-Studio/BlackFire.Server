using BlackFireServer.Client;
using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Text;

namespace BlackFireServer.Server.Register
{
    internal static class RegisterApp
    {
        private static RegisterServer s_Register;

        internal static void Run(string[] args)
        {
            s_Register = new RegisterServer();
            s_Register.Setup(1000);
            s_Register.Start();
            s_Register.SessionClosed += Register_SessionClosed;
        }

        private static void Register_SessionClosed(RegisterServerSession session, SuperSocket.SocketBase.CloseReason value)
        {
           
        }
    }
}
