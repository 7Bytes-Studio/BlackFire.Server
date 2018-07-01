using BlackFireFramework;
using BlackFireServer.Client;
using BlackFireServer.Server.Interface;
using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Text;

namespace BlackFireServer.Server.Business
{
    internal static class BusinessApp
    {
        private static BusinessServer s_business;

        internal static void Run(string[] args)
        {
            Console.Title = "BusinessServer";
            Redis.Init("127.0.0.1:6379");
            s_business = new BusinessServer();
            s_business.NewRequestReceived += NewRequestReceived;
            s_business.Setup(4000);
            s_business.Start();
        }

        private static void NewRequestReceived(BusinessServerSession session, BusinessServerRequestInfo requestInfo)
        {
            var args = ClientEventArgs.Spawn<ClientEventArgs>();
            args.Client = new Interface.Client(session);
            args.Key = requestInfo.Key;
            args.Body = requestInfo.Body;
            Event.Fire("BusinessServer/OnMessage","BusinessApp",args);
        }
    }
}
