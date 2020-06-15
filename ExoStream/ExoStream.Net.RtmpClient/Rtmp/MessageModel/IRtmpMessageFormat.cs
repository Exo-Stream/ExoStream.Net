using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace ExoStream.Net.Rtmp.MessageModel
{
    public interface IRtmpMessageFormat
    {
        // Message Header
        byte[] MessageType { get; set; }        // One Byte Field
        byte[] MessageLength { get; set; }      // Three Byte Field [Represents Size of Payload (Big-Endian Format)]
        byte[] MessageTimestamp { get; set; }   // Four Byte Field [Timestamp of Message (Big-Endian Order)]
        byte[] MessageStreamId { get; set; }    // Three Byte Field 

        // Message Body
        byte[] MessagePayload { get; set; }

    }
}
