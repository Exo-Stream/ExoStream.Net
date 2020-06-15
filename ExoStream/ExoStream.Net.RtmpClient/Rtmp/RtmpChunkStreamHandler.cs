using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using ExoStream.Net.Rtmp.MessageModel;
using System.Net.Sockets;

namespace ExoStream.Net.Rtmp
{
    
    public class RtmpChunkStreamHandler
    {
        public RtmpMessageHandler MessageHandler { get; set; }
        public byte ChunkHeaderType { get; set; }


        public Dictionary<string, Socket> ChunkStreams;


        public void NewSocket()
        {

            Socket socket = new Socket(
                AddressFamily.InterNetworkV6,
                SocketType.Stream,
                ProtocolType.Tcp);


           
        }



    }


    
}

/*
    RtmpChunkingHandler
    {




        internal IRtmpMessageFormat MessageFormat;

        internal MemoryStream Stream;
        internal readonly string FileLocation;
        internal readonly byte[] BufferSize;
        internal const int MaxBufferSize = 4096;

        public RtmpChunkingHandler()
        {




        }



        public async Task BeginStreamingAsync(Stream DestinationStream)
        {
            int BytesRead;

            using(FileStream filestream = File.Open(FileLocation, FileMode.Open, FileAccess.Read))
            {
                using(BufferedStream bufferstream = new BufferedStream(filestream))
                {
                    while((BytesRead = bufferstream.Read(BufferSize, 0, MaxBufferSize)) != 0)
                    {
                        await bufferstream.CopyToAsync(DestinationStream);
                    }
                }
            }
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

    */
