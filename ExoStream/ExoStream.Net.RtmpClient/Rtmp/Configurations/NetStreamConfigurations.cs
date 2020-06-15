using System;
using System.Collections.Generic;
using System.Text;

namespace ExoStream.Net.Rtmp.Configurations
{
    public class NetStreamConfigurations
    {
        public bool EnableSsl { get; set; } = false;
        public bool CanWriteRequired { get; set; } = true;
        public bool CanReadRequired { get; set; } = true;
        public bool CanTimeoutRequired { get; set; } = true;
        public int ReadTimeout { get; set; } = 60000;           // In Miliseconds [One Minute to Allocated]
        public int WriteTimeout { get; set; } = 60000;          // In Miliseconds [One Minute to Allocated]
    }
}
