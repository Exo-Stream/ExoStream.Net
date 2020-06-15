using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace ExoStream.Net.Rtmp
{

    public enum RtmpExceptionCode
    {
        UnOpenedMemoryAllocation = -2,          // RTMP client could not allocate memory for rtmp context structure
        UnOpenedConnectionStream = -3,          // RTMP client could not open the stream on server
        UnknownRmtpOption = -4,                 // Received an unknown option from the RTMP server
        UnknownRmtpAmfType = -5,                // RTMP server sent a packet with unknown AMF (Action Message Format) type            
        UnreachableDns = -6,                    // DNS (Domain Named Server) is unreachable
        SocketConnectionFailure = -7,           // Could not establish a socket connection to the server
        SocketNegotiationFailure = -8,          // SOCKS negotiation failed
        SocketCreationFailure = -9,
        NoSslTlsSupplied = -10,
        HandshakeConnectionFailure = -11,
        HandshakeFailure = -12,
        ConnectionFailure = -13,
        ConnectionLost = -14,
        RtmpKeyframeTsMismatch = -15,
        StreamCorrupted = -16,
        MemoryAllocationFailure = -17,
        InvalidDataSize = -18,
        PacketTooSmall = -19,
        PacketDispatchFailure = -20,
        AmfEncodingFailure = -21,
        UrlProtocolMissing = -22,
        UrlMissingHostName = -23,
        InvalidUrlPort = -24,
        RtmpRequestIgnored = -25,
        GenericError = -26,
        RtmpSanityFailure = -27
    }

    public enum ContentType : byte
    {
        PacketSizeSet = 1,
        Abort = 2,
        Acknowledge = 3,
        ControlMessage = 0,
        ServerBandwidt = 5,
        ClientBandwidth = 6,
        VirtualControl = 7,
        AudioPacket = 8,
        VideoPacket = 9,
        //DataExtended = 0x0F,
        ContainerExtended = 10,
        CommandExtended = 11,
        DataIvoked = 12,
        Container = 13,
        Command = 14,
        UDP = 15,
        Aggregate = 16,
        Present = 17
    }

    enum PacketContentType : byte
    {
        SetChunkSize = 1,
        AbortMessage = 2,
        Acknowledgement = 3,
        UserControlMessage = 4,
        WindowAcknowledgementSize = 5,
        SetPeerBandwith = 6,

        Audio = 8,
        Video = 9,

        DataAmf3 = 15, // 0x0f | stream send
        SharedObjectAmf3 = 16, // 0x10 | shared obj
        CommandAmf3 = 17, // 0x11 | aka invoke

        DataAmf0 = 18, // 0x12 | stream metadata
        SharedObjectAmf0 = 19, // 0x13 | shared object
        CommandAmf0 = 20, // 0x14 | aka invoke

        Aggregate = 22,
    }

    public enum MessageType // This will be the Message Type ID [This is the command]
    {

    }


    public enum RtmpEvent
    {

    }

    public class RtmpMessageHandler
    {

        


        public RtmpMessageHandler()
        {
            




        }



        public partial class HandlerOne
        {





            public partial class HandlerTwo
            {






                public partial class HandlerThree
                {





                    public partial class HandlerFour
                    {







                    }
                }
            }
        }
    }
}
