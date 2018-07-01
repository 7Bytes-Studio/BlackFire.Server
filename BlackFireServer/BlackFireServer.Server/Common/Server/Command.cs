using BlackFireServer.Server.Register;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFireServer.Server
{
    public static class Command
    {
        public static void SendRegisterCommand(RegisterServerSession session, string cmd_key,string cmd_body) 
        {
            var data = string.Format("{0} {1}", cmd_key,cmd_body).ToUTF8Bytes();
            session.TrySend(data, 0, data.Length);
        }

        public static void SendRegisterCommand_Welcome(RegisterServerSession session)
        {
            Command.SendRegisterCommand(session,"REGISTERRESPONSEADDRESS", "{\"msg:\"\"Welcome!\"}");
        }

        public static void SendRegisterCommand_UpdateAddress()
        {
            RegisterStorage.Foreach(ServerType.Gateway, entity => {
                Command.SendRegisterCommand(entity.AppSession as RegisterServerSession, "UPDATECONNECTADDRESS", RegisterStorage.GetConnectsSerializeString());
            });

            RegisterStorage.Foreach(ServerType.Business, entity => {
                Command.SendRegisterCommand(entity.AppSession as RegisterServerSession, "UPDATECONNECTADDRESS", RegisterStorage.GetConnectsSerializeString());
            });
        }



    }
}
