using BlackFireFramework;
using BlackFireServer.Client;
using BlackFireServer.Server.Business;
using BlackFireServer.Server.Connect;
using BlackFireServer.Server.Gateway;
using BlackFireServer.Server.Register;
using Newtonsoft.Json;
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

            InitServer(args);
            InitFramework();

        }










        private static void InitServer(string[] args)
        {

            if (0 < args.Length)
            {
                if ("-r" == args[0])
                {
                    Console.Title = "RegisterApp";
                    RegisterApp.Run(args);
                }
                else if ("-g" == args[0])
                {
                    Console.Title = "GatewayApp";
                    GatewayApp.Run(args);
                }
                else if ("-b" == args[0])
                {
                    Console.Title = "BusinessApp";
                    BusinessApp.Run(args);
                }
                else if ("-c" == args[0])
                {
                    Console.Title = "ConnectApp";
                    ConnectApp.Run(args);
                }
                Console.ReadKey();
                return;
            }
            else
            {
                RegisterApp.Run(args);
                GatewayApp.Run(args);
                BusinessApp.Run(args);
                ConnectApp.Run(args);
            }

        }



        private static readonly object s_God = new object();
        private static float s_RealElapsedDeltaTime = 0.02f;
        private static float s_VirsulElapsedDeltaTime;
        private static void InitFramework()
        {
            TimeSpan timeSpan;
            DateTime dateTime;
            var realElapsedDeltaTime = (int)(s_RealElapsedDeltaTime * 1000);

            Framework.Act(s_God, s_RealElapsedDeltaTime, s_VirsulElapsedDeltaTime);
            while (true)
            {
                dateTime = DateTime.Now;
                System.Threading.Thread.Sleep(realElapsedDeltaTime);
                timeSpan = DateTime.Now - dateTime;
                s_VirsulElapsedDeltaTime = timeSpan.Milliseconds / 1000f;
                Framework.Act(s_God, s_RealElapsedDeltaTime, s_VirsulElapsedDeltaTime);
                //if (!Framework.State.Working) break;
            }
            //Framework.Die(s_God,s_RealElapsedDeltaTime,s_VirsulElapsedDeltaTime);
        }

    }
}
