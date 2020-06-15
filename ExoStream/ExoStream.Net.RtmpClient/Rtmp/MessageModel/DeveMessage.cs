using System;
using System.Collections.Generic;
using System.Text;

namespace ExoStream.Net.Rtmp.MessageModel
{
    public class DevMessage : IRtmpMessageFormat
    {

        public DevMessage(int time)
        {
            MessageStreamId = new byte[] { 10,10,10,10 };
            MessageType = new byte[] { 9 };
            MessageTimestamp = new byte[] { 10, 10, 10 };
            MessageLength = new byte[]{32,32,32};
            
        }

        public byte[] MessageStreamId { get; set; }
        public byte[] MessageType { get; set; }
        public byte[] MessageTimestamp { get; set; }
        public byte[] MessageLength { get; set; }
        public byte[] MessagePayload { get; set; }

        public byte[] CncatMessage()
        {
            List<byte> array = new List<byte>();
            array.AddRange(MessageStreamId);
            array.AddRange(MessageType);
            array.AddRange(MessageTimestamp);
            array.AddRange(MessageLength);

            return array.ToArray();
        }
    }
}
