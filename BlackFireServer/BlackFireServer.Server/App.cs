using BlackFireServer.Client;
using BlackFireServer.Server.Business;
using BlackFireServer.Server.Connect;
using BlackFireServer.Server.Gateway;
using BlackFireServer.Server.Register;
using SuperSocket.ClientEngine;
using System;
using System.Net;
using System.Text;

namespace BlackFireServer.Server
{
    internal static class App
    {

        static void Main(string[] args)
        {
            if (0<args.Length)
            {
                if ("-r"== args[0])
                {
                    RegisterApp.Run(args);
                }
                else if ("-g" == args[0])
                {
                    GatewayApp.Run(args);
                }
                else if ("-b" == args[0])
                {
                    BusinessApp.Run(args);
                }
                else if ("-c" == args[0])
                {
                    ConnectApp.Run(args);
                }
                Console.ReadKey();
                return;
            }


            RegisterApp.Run(args);

            GatewayApp.Run(args);
            BusinessApp.Run(args);
            ConnectApp.Run(args);

            Console.ReadKey();
        }

    }
}
