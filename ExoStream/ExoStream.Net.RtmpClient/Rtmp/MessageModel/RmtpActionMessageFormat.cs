using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ExoStream.Net.Rtmp.MessageModel
{
    public class RmtpActionMessageFormat
    {

        public string Command { get; set; }



        //public override byte[] ToByteArray();
    }

    public class Sample
    {
        public static byte[] Serialize()
        {
            BinaryFormatter Formatter = new BinaryFormatter();
            

        }
    }

}
