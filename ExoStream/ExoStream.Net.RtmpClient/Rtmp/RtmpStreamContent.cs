using System;
using System.Collections.Generic;
using System.Text;



namespace ExoStream.Net.Rtmp
{
    

    public class RtmpStreamContent
    {
        public Uri RtmpUri { get; set; }
        public ContentType ContentType { get; set; }
        public int ChunkSize { get; set; }
        public int BufferSize { get; set; }
        public Uri ShockWaveFlashUri { get; set; } // SWF (ShockWave Flash) URL [Extension .swf]
    }
}
