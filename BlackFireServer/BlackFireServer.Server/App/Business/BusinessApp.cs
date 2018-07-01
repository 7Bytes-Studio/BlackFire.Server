using BlackFireServer.Client;
using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Text;

namespace BlackFireServer.Server.Business
{
    internal static class BusinessApp
    {
        private static EasyClient s_Client;
        private static BusinessServer s_business;

        internal static void Run(string[] args)
        {
            s_business = new BusinessServer();
            s_business.Setup(4000);
            s_business.Start();


            s_Client = new EasyClient();
            s_Client.Initialize<BlackFireClientPackageInfo>(new BlackFireClientReceiveFilter(), r =>
            {
                Console.WriteLine(r.Key + " " + r.Json);
                if ("UPDATECONNECTADDRESS" == r.Key)
                {
                    ServerStorage.UpdateConnectServerList(r.Json);
                }
            });
            s_Client.Connected += Client_Connected;
            s_Client.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"),1000));
        }

        private static void Client_Connected(object sender, EventArgs e)
        {
            s_Client.Send(Encoding.UTF8.GetBytes("BUSINESSREGISTERADDRESS"));
        }
    }
}
