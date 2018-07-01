using BlackFireServer.Server.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFireServer.Server.Interface
{
    internal sealed class Client : IClient
    {
        private BusinessServerSession m_BusinessServerSession;

        public Client(BusinessServerSession businessServerSession)
        {
            m_BusinessServerSession = businessServerSession;
        }

        public string ClientId => m_BusinessServerSession.SessionID;

        public void Send(byte[] data, int startIndex, int length)
        {
            m_BusinessServerSession.TrySend(data,startIndex,length);
        }
    }
}
