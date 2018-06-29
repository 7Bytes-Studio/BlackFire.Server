using BlackFireServer.Client;
using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Text;

namespace BlackFireServer.Server
{
    internal static class GatewayApp
    {
        private static EasyClient s_Client;
        private static Gateway s_gateway;

        static void Main(string[] args)
        {
            s_gateway = new Gateway();
            s_Client = new EasyClient();

            s_gateway.Setup(1994);
            s_gateway.Start();

            s_Client.Initialize<BlackFireClientPackageInfo>(new BlackFireClientReceiveFilter(), r =>
            {
                Console.WriteLine(r.Key);
                Console.WriteLine(r.Json);
            });

            s_Client.Connected += Client_Connected;
            s_Client.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1994));
            Console.Read();
        }

        private static void Client_Connected(object sender, EventArgs e)
        {
            s_Client.Send(Encoding.UTF8.GetBytes("REQUSTADDRESS"));
        }
    }
}
