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
using System.Linq;

using ExoStream.Net.Rtmp.Serialization;

namespace ExoStream.Net.Rtmp
{
    public enum RtmpHanshakeSequence
    {
        C1,
        C2
    }

    internal class RtmpHandshakeHandler : IDisposable
    {

        public byte Version { get; set; } = 3;
        public byte[] Time { get; set; } = new byte[] { 0, 0, 0, 0 };
        public byte[] Zero { get; set; } = new byte[] { 0, 0, 0, 0 };
        public byte[] Random { get; set; } = ByteSeriallizer.ReturnRandomByteArray(1528);

        private byte[] TimeTwo { get; set; }    // Property will be set on Response from Server
        private byte[] RandomEcho { get; set; } // Property will be set on Response from Server

 


        public byte[] C1Packet()
        {
            List<byte> packet = new List<byte>();
            packet.Add(Version);
            packet.AddRange(Time);
            packet.AddRange(Zero);
            packet.AddRange(Random);
            return packet.ToArray();
        }

        public byte[] C2Packet()
        {
            List<byte> packet = new List<byte>();
            //packet.Add(Version);
            packet.AddRange(Time);
            packet.AddRange(TimeTwo);
            packet.AddRange(RandomEcho);
            return packet.ToArray();
        }

        public bool ValidatePacketReturn(Stream stream, RtmpHanshakeSequence sequence)
        {
            bool IsValid = false;



            // Validate Packet Sequence C1
            if (sequence.Equals(RtmpHanshakeSequence.C1))
            {
                byte[] C01 = C1Packet();
                int[] S01 = new int[1537];

                for (int i = 0; i < 1537; i++)
                {
                    S01[i] = stream.ReadByte();
                }

                if (C01[0] == Convert.ToByte(S01[0]))
                    IsValid = true;

                Time = new byte[]
                {
                    Convert.ToByte(S01[1]),
                    Convert.ToByte(S01[2]),
                    Convert.ToByte(S01[3]),
                    Convert.ToByte(S01[4])
                };

                TimeTwo  = new byte[4]
                {
                    Convert.ToByte(S01[1]),
                    Convert.ToByte(S01[2]),
                    Convert.ToByte(S01[3]),
                    Convert.ToByte(S01[4])
                };

                byte[] Echo = new byte[1528];

                for (int i = 9; i < 1529; i++)
                {
                    Echo[i - 9] = Convert.ToByte(S01[i]);
                }

                RandomEcho = Echo;
               
            }

            // Validate Packet Sequence C2
            if (sequence.Equals(RtmpHanshakeSequence.C2))
            {
                IsValid = true;
                int[] S02 = new int[1536];

                for (int i = 0; i < 1536; i++)
                {
                    S02[i] = stream.ReadByte();
                }

                for(int i = 0; i < Random.Length;i++)
                {
                    if (!Random[i].Equals(Convert.ToByte(S02[i+8])))
                        IsValid = false;
                }
            }
            return IsValid;
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
