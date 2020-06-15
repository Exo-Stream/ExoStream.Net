using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

using ExoStream.Net.Rtmp.Configurations;

namespace ExoStream.Net.Rtmp
{
    public class RtmpConnectionRequest
    {
        public RtmpConnectionRequest(RtmpStreamContent content)
        {
            Content = content;
        }

        public RtmpConnectionRequest(RtmpStreamContent content, NetStreamConfigurations streamconfigurations)
        {
            Content = content;
            StreamConfigurations = streamconfigurations;

        }

        public RtmpConnectionRequest(RtmpStreamContent content, NetProtocolConfigurations protocolconfigurations)
        {
            Content = content;
            ProtocolConfigurations = protocolconfigurations;
        }

        public RtmpConnectionRequest(RtmpStreamContent content, NetStreamConfigurations streamconfigurations, NetProtocolConfigurations protocolconfigurations)
        {
            Content = content;
            StreamConfigurations = streamconfigurations;
            ProtocolConfigurations = protocolconfigurations;
        }

        public RtmpStreamContent Content { get; set; }
        public NetStreamConfigurations StreamConfigurations { get; set; } = new NetStreamConfigurations();
        public NetProtocolConfigurations ProtocolConfigurations { get; set; } = new NetProtocolConfigurations();
    }
}
