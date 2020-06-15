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


using ExoStream.Net.Rtmp.Serialization;
using ExoStream.Net.Rtmp.Configurations;

namespace ExoStream.Net.Rtmp
{
    internal static class RtmpStreamExtensions
    {
        // [Finished] : Create eiter a SSL Stream or standard Network Stream
        public static async Task<Stream> ResolveStreamTypeAsync(this TcpClient protocol, RtmpConnectionRequest request)
        {
            Stream NetStream = protocol.GetStream();

            if (request.StreamConfigurations.EnableSsl.Equals(true))
            {
                // Request a Callback Delegate to Vallidate Remote Certificate
                RemoteCertificateValidationCallback ValidationCallback = (sender, certificate, chain, errors) => true;

                // Instantiate a New SSL Stream [Transfer Current Stream to SSL Stream then close]
                SslStream Sslstream = new SslStream(NetStream, false, ValidationCallback);

                // Authenticate Server through Client Request [Set Configure Await to 'True' to return context before returning stream]
                await Sslstream.AuthenticateAsClientAsync(request.Content.RtmpUri.Host).ConfigureAwait(true);

                return Sslstream;
            }
            else
            {
                return NetStream;
            }
        }

        // [InProgress] : 
        public static async Task ValidateStreamPropertiesAsync(this Stream stream, NetStreamConfigurations configurations)
        {
            Task task = Task.Run(() =>
            {

                if (!stream.CanRead.Equals(configurations.CanReadRequired))
                    throw new Exception("TCP Read Requirements do not match with RTMP Request.");

            });

            await task;
        }

        // [Finished] : Initial main conneciton 
        public static async Task InitializeHandshakeSequenceAsync(this Stream stream, CancellationToken token)
        {
            // Create Random Byte Array for both Client Packet 1 & 2
            using (RtmpHandshakeHandler PacketHandler = new RtmpHandshakeHandler())
            {
                await stream.WriteAsync(PacketHandler.C1Packet(), 0, 1537, token);

                if (PacketHandler.ValidatePacketReturn(stream, RtmpHanshakeSequence.C1))
                    await stream.WriteAsync(PacketHandler.C2Packet(), 0, 1536);
                else
                    throw new Exception("");

                if (!PacketHandler.ValidatePacketReturn(stream, RtmpHanshakeSequence.C2))
                    throw new Exception("");
            }
        }

        // [InProgress] : 
        public static async Task InitializeChunkingSequenceAsync(this Stream stream, CancellationToken token)
        {

        }
    }
}
