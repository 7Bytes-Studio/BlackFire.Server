using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Text;

namespace BlackFireServer.Client
{
    internal static class ClientApp
    {
        private static EasyClient s_Client;
        static void Main(string[] args)
        {
            s_Client = new EasyClient();
            s_Client.Initialize<BlackFireServerPackageInfo>(new BlackFireServerReceiveFilter(), r =>
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
