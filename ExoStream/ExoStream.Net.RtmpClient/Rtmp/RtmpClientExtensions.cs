
#region External Dependencies

using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Net.NetworkInformation;

using System.Net.Http.Headers;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

#endregion


#region Internal Dependencies

using ExoStream.Net.Rtmp.Serialization;
using ExoStream.Net.Rtmp.Configurations;


#endregion

namespace ExoStream.Net.Rtmp
{
    internal static class RtmpClientExtensions
    {

        public static async Task ValidateClientRequestAsync(this TcpClient client, RtmpConnectionRequest request)
        {
            Task task = Task.Run(() =>
            {
                // Validation Steps:
                // Validate URI Scheme Request
                //  * Validate EnableSsl matches with Protocol Type RTMPs (cannot be RTMP)

            });

            await task;
        }

        public static async Task ValidateClientConnectionAsync(this TcpClient client, NetProtocolConfigurations configurations)
        {
            Task task = Task.Run(() =>
            {

                if(!client.Connected)
                    throw new Exception("Rtmp Client was unable to make TCP connection to requested Host. Please make sure the the requested URI is valid.");


            });

            await task;
        }
    }
}
