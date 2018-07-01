using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFireServer.Server.Interface
{
    public interface IBusinessServerEvent
    {
        string ClientId { get; }

        void Send(byte[] data,int startIndex,int length);
    }
}
