using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Redoubt.Server
{
    public class Program
    {
        public X509Certificate2 certificate = new X509Certificate2("server.pfx", "instant");
        //public IPAddress ip = IPAddress.Parse("149.56.13.236");
        public IPAddress ip = IPAddress.Parse("127.0.0.1");
        public int port = 5588;
        public Dictionary<string, UserInfo> users = new Dictionary<string, UserInfo>();
        string usersFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "users.dat");

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void SaveUsers()
        {
            try
            {
                Console.WriteLine("[{0}] Saving users...", DateTime.Now);

                using (StreamWriter file = File.CreateText(usersFileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, users.Values.ToArray());
                }

                Console.WriteLine("[{0}] Users saved!", DateTime.Now);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void LoadUsers()
        {
            try
            {
                Console.WriteLine("[{0}] Loading users...", DateTime.Now);

                using (StreamReader file = File.OpenText(usersFileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    UserInfo[] info = (UserInfo[])serializer.Deserialize(file, typeof(UserInfo[]));
                    users = info.ToDictionary((u) => u.userName, (u) => u);
                }

                Console.WriteLine("[{0}] Users loaded! ({1})", DateTime.Now, users.Count);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
