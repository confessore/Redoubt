using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading;

namespace Redoubt.Server
{
    public class Server
    {
        public TcpClient client;
        public NetworkStream networkStream;
        public SslStream sslStream;
        public BinaryReader br;
        public BinaryWriter bw;

        async void SetupConnection()
        {
            try
            {
                Console.WriteLine("[{0}] New Connection!", DateTime.Now);
                networkStream = client.GetStream();
                sslStream = new SslStream(networkStream, false);
                await sslStream.AuthenticateAsServerAsync(prgm.certificate, false, SslProtocols.Tls, true);
                Console.WriteLine("[{0}] Connection Authenticated", DateTime.Now);

                br = new BinaryReader(sslStream, Encoding.UTF8);
                bw = new BinaryWriter(sslStream, Encoding.UTF8);

                bw.Write(PKT_Hello);
                Console.WriteLine("Sending hello packet");
                bw.Flush();

                int hello = br.ReadInt32();
                Console.WriteLine("Reading hello packet");

                if (hello == PKT_Hello)
                {
                    Console.WriteLine("Received hello packet");
                    byte logMode = br.ReadByte();
                    string userName = br.ReadString();
                    string password = br.ReadString();
                }
            }

            catch { CloseConnection(); }
        }

        void CloseConnection()
        {
            try
            {
                br.Dispose();
                bw.Dispose();
                sslStream.Dispose();
                networkStream.Dispose();
                client.Dispose();
                Console.WriteLine("[{0}] End of connection!", DateTime.Now);
            }
            catch { }
        }

        public const int PKT_Hello = 2012;      // Hello
        public const byte IM_OK = 0;           // OK
        public const byte IM_Login = 1;        // Login
        public const byte IM_Register = 2;     // Register
        public const byte IM_TooUsername = 3;  // Too long username
        public const byte IM_TooPassword = 4;  // Too long password
        public const byte IM_Exists = 5;       // Already exists
        public const byte IM_NoExists = 6;     // Doesn't exists
        public const byte IM_WrongPass = 7;    // Wrong password
        public const byte IM_IsAvailable = 8;  // Is user available?
        public const byte IM_Send = 9;         // Send message
        public const byte IM_Received = 10;    // Message received
    }
}
