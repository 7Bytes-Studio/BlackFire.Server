using BlackFireFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFireServer.Server.Interface
{
    public sealed class ClientEventArgs : RecyclableEventArgs
    {

        public IClient Client { get; internal set; }
        public string Key { get; internal set; }
        public string Body { get; internal set; }

        protected override void OnRecycle()
        {
            Client = null;
            Key = null;
            Body = null;
        }

        protected override void OnSpawn()
        {
            
        }
    }
}
