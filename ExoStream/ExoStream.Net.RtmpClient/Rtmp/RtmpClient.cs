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

using ExoStream.Net.Rtmp.Configurations;
using ExoStream.Net.Rtmp.MessageModel;
using ExoStream.Net.Rtmp.Serialization;
using ExoStream.Net.Rtmp.Providers;
using System.Xml.Xsl;

/*
 
Developer Process:
- Instantiate Rtmp Request
- Instanciate Rtmp Client
- Connect to Rtmp Host
- Calidate Rtmp Connection
- Begin Rtmp Streaming 
 
Internal Process:
 RTMP Request & Response Process 

    S01: Instantiate a RTMP Request
    S02: Instantiate the RTMP Client
        - SS01: Instantiate a TCP Client
        - SS02: Identify HOST & Port From URI
        - SS03: Make TCP Connection
        - SS04: Request Stream [either SSL Stream or Network Stream]
        - SS05: Make a TCP Hanshake [This establishes the protocols of a communication link] 
            > SB01: 
        - SS06: Call a Command Name
    S03: If Handhsake IsValid, begin constructing RTMP Stream Handler [This will be the object which will maintain connection and send data]
    S04: Request Build
    S05: Response Interpretation
    S06: Respomse Interpretation

     
 */

namespace ExoStream.Net.Rtmp
{

    public class RtmpClient : IDisposable
    {

        #region Constant Fields
        internal const int DefaultPort = 1935;

        #endregion 


        #region Internal Fields
        internal RtmpConnectionRequest RtmpRequest;
        //internal RtmpClientResponse RtmpResponse;
        #endregion


        #region Constructers
        public RtmpClient() { }

        public RtmpClient(RtmpConnectionRequest Request)
        {
            RtmpRequest = Request;
            ProtocolClient.NoDelay = Request.ProtocolConfigurations.NoDelay;
            ProtocolClient.ExclusiveAddressUse = Request.ProtocolConfigurations.ExclusiveAddressUse;

            if (!Request.ProtocolConfigurations.ReceiveTimeout.Equals(0))
                ProtocolClient.ReceiveTimeout = Request.ProtocolConfigurations.ReceiveTimeout;

            if (!Request.ProtocolConfigurations.SendTimeout.Equals(0))
                ProtocolClient.SendTimeout = Request.ProtocolConfigurations.SendTimeout;

            if (!Request.ProtocolConfigurations.RecieveBufferSize.Equals(0))
                ProtocolClient.ReceiveBufferSize = Request.ProtocolConfigurations.RecieveBufferSize;

            if (!Request.ProtocolConfigurations.SendBufferSize.Equals(0))
                ProtocolClient.SendBufferSize = Request.ProtocolConfigurations.SendBufferSize;


        }
        #endregion


        #region Properties
        internal static Stream RtmpStream { get; set; }
        internal TcpClient ProtocolClient { get; set; } = new TcpClient();
        internal TcpListener ProtocolListener { get; set; }
        internal CancellationToken StopToken { get; set; } = new CancellationToken();
        #endregion 


        // [FInished] : Connection Complete
        public async Task ConnectAsync()
        {
            try
            {
                // Step 01 : Make connection to socket on Server-Side TCP Listener if URI Schema is valid
                await ProtocolClient.ValidateClientRequestAsync(RtmpRequest);

                // Step 02 : Connect to Host Socket
                await ProtocolClient.ConnectAsync(RtmpRequest.Content.RtmpUri.Host,RtmpRequest.Content.RtmpUri.Port != -1 ? RtmpRequest.Content.RtmpUri.Port : DefaultPort);

                // Step 03 : Validate Socket Connection
                await ProtocolClient.ValidateClientConnectionAsync(RtmpRequest.ProtocolConfigurations);

                // Step 04 : Set the Resolved Stream
                RtmpStream = await ProtocolClient.ResolveStreamTypeAsync(RtmpRequest);

                // Step 05 : Validate Stream Properties Match with request
                await RtmpStream.ValidateStreamPropertiesAsync(RtmpRequest.StreamConfigurations);

                // Step 06 : Initialize the Handshake Sequence
                await RtmpStream.InitializeHandshakeSequenceAsync(StopToken);

            }
            catch(Exception exception)
            {
                throw new Exception("RMTP Connection was Unsuccessful.", exception);
            }
        }

        // [FInished] : Connection Complete
        public async Task ConnectAsync(RtmpConnectionRequest Request)
        {
            RtmpRequest = Request;
            ProtocolClient.NoDelay = Request.ProtocolConfigurations.NoDelay;
            ProtocolClient.ExclusiveAddressUse = Request.ProtocolConfigurations.ExclusiveAddressUse;

            if (Request.ProtocolConfigurations.ReceiveTimeout != -1)
                ProtocolClient.ReceiveTimeout = Request.ProtocolConfigurations.ReceiveTimeout;

            if (Request.ProtocolConfigurations.SendTimeout != -1)
                ProtocolClient.SendTimeout = Request.ProtocolConfigurations.SendTimeout;

            if (Request.ProtocolConfigurations.RecieveBufferSize != -1)
                ProtocolClient.ReceiveBufferSize = Request.ProtocolConfigurations.RecieveBufferSize;

            if (Request.ProtocolConfigurations.SendBufferSize != -1)

            try
            {
                // Step 01: Make connection to socket on Server-Side TCP Listener if URI Schema is valid
                await ProtocolClient.ValidateClientRequestAsync(RtmpRequest);

                // Step 02: Connect to Host Socket
                await ProtocolClient.ConnectAsync(RtmpRequest.Content.RtmpUri.Host,RtmpRequest.Content.RtmpUri.Port != -1 ? RtmpRequest.Content.RtmpUri.Port : DefaultPort);

                // Step 03: Validate Socket Connection
                await ProtocolClient.ValidateClientConnectionAsync(RtmpRequest.ProtocolConfigurations);

                // Step 04: Set the Resolved Stream
                RtmpStream = await ProtocolClient.ResolveStreamTypeAsync(RtmpRequest);

                // Step 05: Validate Stream Properties Match with request
                await RtmpStream.ValidateStreamPropertiesAsync(RtmpRequest.StreamConfigurations);

                // Step 06: Initialize the Handshake Sequence
                await RtmpStream.InitializeHandshakeSequenceAsync(StopToken);

            }
            catch(Exception exception)
            {
                throw new Exception("Connection was unsuccessful.", exception);
            }
        }


        // This method is for static File Types
        public async Task StreamAsync()
        {
            


        }

        // This mehtod will be used to pipe continous stream of data
        public async Task StreamLiveAsync()
        {

            
        }

        #region Disposable Interface Implementation

        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            disposed = true;
        }

        #endregion
    }
}


/*
 * > Set Chunk Format - Single Byte
 * > Stream ID
 * 
 * 
 * 
 */