using BlackFireFramework;
using BlackFireServer.Server.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFireServer.GameLogic
{
    internal sealed class App : ExportedAssemblyBase
    {
        #region LifeCircle

        protected override void OnExport(ISparrowIoC ioc)
        {
            Console.WriteLine("OnExport");
        }

        protected override void OnBorn()
        {
            Console.WriteLine("OnBorn");
            Event.On<ClientEventArgs>("BusinessServer/OnConnect", this, (sender, args) => { OnConnect(args.Client); });
            Event.On<ClientEventArgs>("BusinessServer/OnMessage", this, (sender, args) => { OnMessage(args.Client,args.Key,args.Body); });
            Event.On<ClientEventArgs>("BusinessServer/OnClose",   this, (sender, args) => { OnClose(args.Client); });
        }

        protected override void OnDie()
        {
            Console.WriteLine("OnDie");
            Event.Off("BusinessServer/OnConnect",this);
            Event.Off("BusinessServer/OnMessage", this);
            Event.Off("BusinessServer/OnClose", this);
        }

        #endregion




        #region Event

        public static void OnConnect(IClient client)
        {

        }

        public static void OnMessage(IClient client,string cmd_key,string cmd_body)
        {
            Console.WriteLine("GameLogic:::"+ cmd_key+"  "+cmd_body);
        }
        public static void OnClose(IClient client)
        {

        }

        #endregion

    }
}
