using System;
using System.Net;
using ExoStream.Net.Rtmp;
using ExoStream.Net.Rtmp.Configurations;
using System.Net.WebSockets;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//using RtmpSharp;
//using RtmpSharp.Net;

namespace ExoStream.Net.QAConsole
{
   

    public static class Program
    {
        private static Uri Rtmp = new Uri("rtmps://live-api-s.facebook.com:443/rtmp/966270657109504?s_bl=1&s_sc=966270673776169&s_sw=0&s_vt=api-s&a=Aby0IFYvvkAhMD7K");
        private static string StreamKey = "966270657109504?s_bl=1&s_sc=966270673776169&s_sw=0&s_vt=api-s&a=Aby0IFYvvkAhMD7K";


        public static async Task Main()
        {

            Console.WriteLine($"Started: {DateTime.Now}");

            RtmpStreamContent Content = new RtmpStreamContent()
            {
                RtmpUri = Rtmp
                
            };

            NetStreamConfigurations configurations = new NetStreamConfigurations()
            {
                EnableSsl = true
            };

            RtmpConnectionRequest Request = new RtmpConnectionRequest(Content, configurations);


            RtmpClient client = new RtmpClient(Request);
            await client.ConnectAsync();
            await client.StreamAsync();


            Console.WriteLine($"Finished: {DateTime.Now}");

            Console.ReadKey();


           
        }
    }
}

/*
 
    RtmpConnectionRequest Request = new RtmpConnectionRequest()
            {
                Uri = RtmpUri,
                EnableSsl = true

            };


            using (RtmpClient client = new RtmpClient(Request))
            {
                await client.ConnectAsync();
                await client.StreamAsync();
            }
     */




/*
            var context = new SerializationContext();
            var options = new RtmpClient.Options()
            {
                // required parameters:
                Url = "rtmps://live-api-s.facebook.com:443/rtmp/966270657109504?s_bl=1&s_sc=966270673776169&s_sw=0&s_vt=api-s&a=Aby0IFYvvkAhMD7K",
                Context = context,

                // optional parameters:
                AppName = "demo-app",                                  // optional app name, passed to the remote server during connect.
                PageUrl = "",   // optional page url, passed to the remote server during connect.
                SwfUrl = "",                                          // optional swf url,  passed to the remote server during connect.
                ChunkLength = 4192,                                        // optional outgoing rtmp chunk length.
                Validate = (sender, certificate, chain, errors) => true // optional certificate validation callback. used only in tls connections.
            };

            var client = await RtmpClient.ConnectAsync(options);
            var exists = await client.InvokeAsync<bool>("storage", "exists", new { name = "music.pdf" });
*/
