using BlackFireServer.Client;
using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Text;

namespace BlackFireServer.Server.Connect
{
    internal static class ConnectApp
    {
        private static ConnectServer s_Connect;
        private static EasyClient s_Client;

        internal static void Run(string[] args)
        {
            s_Connect = new ConnectServer();
            s_Connect.Setup(new Random().Next(3000,4000));
            s_Connect.Start();

            s_Client = new EasyClient();
            s_Client.Initialize<BlackFireClientPackageInfo>(new BlackFireClientReceiveFilter(), r =>
            {
                Console.WriteLine(r.Key+" "+ r.Json);
            });
            s_Client.Connected += Client_Connected;
            s_Client.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"),1000));
        }

        private static void Client_Connected(object sender, EventArgs e)
        {
            s_Client.Send(Encoding.UTF8.GetBytes("CONNECTREGISTERADDRESS"));
        }
    }
}
