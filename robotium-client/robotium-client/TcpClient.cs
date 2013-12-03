using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace robotium_client
{
    public class RobotiumTcpClient
    {
        private string host;
        private int port;

        public RobotiumTcpClient(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public string Send(string json)
        {
            string responseData = null;

            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(host), port);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ip);
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());

            }

            using (NetworkStream ns = new NetworkStream(server))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {

                sw.WriteLine(json);
                sw.Flush();
                //responseData = sr.ReadLine();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                while ((responseData = sr.ReadLine()) == null && stopwatch.Elapsed < TimeSpan.FromSeconds(10))
                {
                    
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                
            }

            server.Shutdown(SocketShutdown.Both);
            //server.Close();

            return responseData;
        }
    }
}
