using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFireServer.Server.Interface
{
    public static class IClientExtension
    {
        public static void Send(this IClient client,string cmd_key,string cmd_body)
        {
            var cmd = string.Format("{0} {1}",cmd_key,cmd_body);
            var data = cmd.ToUTF8Bytes();
            client.Send(data,0,data.Length);
        }
    }
}
