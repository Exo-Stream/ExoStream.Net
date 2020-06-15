using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ExoStream.Net.Rtmp.Serialization
{
    public class ByteSeriallizer
    {

        public static char[] ReturnRandomCharArray(int ArrayLength)
        {
            List<char> RandomArray = new List<char>();

            while (RandomArray.Count < ArrayLength)
            {
                long Now = DateTime.Now.ToBinary();
                foreach (byte Octet in BitConverter.GetBytes(Now))
                {
                    RandomArray.AddRange(Octet.ToString().ToCharArray());
                    
                   
                }
            }

            return RandomArray.ToArray();
        }

        public static byte[] ReturnRandomByteArray(int ArrayLength)
        {
            List<byte> RandomArray = new List<byte>();

            while (RandomArray.Count < ArrayLength)
            {
                long Now = DateTime.Now.ToBinary();
                foreach (byte Octet in BitConverter.GetBytes(Now))
                {
                    RandomArray.Add(Octet);
                }
            }

            return RandomArray.ToArray();
        }

        // Needs fixing
        public static byte[] ConcatByteArrays(List<byte[]> ByteArrays)
        {
            List<byte> NewArray = new List<byte>();


            return NewArray.ToArray();
        }

        public static byte[] Serialize<TStruct>(TStruct input) where TStruct : struct
        {
            BinaryFormatter ByteFormatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            ByteFormatter.Serialize(stream, input);
            return stream.ToArray();
        }

        public static TStruct Deserialize<TStruct>(byte[] input) where TStruct : struct
        {
            BinaryFormatter ByteFormatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(input);
            return (TStruct)ByteFormatter.Deserialize(stream);
        }
    }
}
