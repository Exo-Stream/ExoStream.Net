using System;
using System.Collections.Generic;
using System.Text;

namespace ExoStream.Net.Rtmp.MessageModel
{
    public class GenericImageMessage : IRtmpMessageFormat
    {
        public byte[] MessageType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] MessageLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] MessageTimestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] MessageStreamId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public byte[] MessagePayload { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
