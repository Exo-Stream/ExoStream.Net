using System;
using System.Collections.Generic;
using System.Text;

namespace ExoStream.Net.Rtmp.Configurations
{
    public class NetProtocolConfigurations
    {
        public bool NoDelay { get; set; } = true;
        public bool ExclusiveAddressUse { get; set; } = true;
        public int ReceiveTimeout { get; set; }
        public int SendTimeout { get; set; }
        public int RecieveBufferSize { get; set; }
        public int SendBufferSize { get; set; }
    }
}
