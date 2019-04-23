using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class Server : IServer
    {

        private TcpListener listener;
        private TcpClient client;
        private IPEndPoint ep;

        private BinaryReader reader;
        public Server(int port)
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            listener = new TcpListener(ep);
            listener.Start();

        }

        //Blocker till the simulator connected
        public void Start()
        {
            // Console.WriteLine("Waiting for connections...");
            client = listener.AcceptTcpClient();
            // Console.WriteLine("Got new connection");
            reader = new BinaryReader(client.GetStream());
        }


        public string[] Read()
        {
            String buffer = "";
            char c;
            try
            {
                c = reader.ReadChar();
            }
            catch
            {
                Console.WriteLine("Reading from client failed");
                Stop();
                return null;

            }

            while (c != '\n')
            {
                buffer += c;
                try
                {
                    c = reader.ReadChar();
                }
                catch
                {
                    Console.WriteLine("Reading from client failed");
                    Stop();
                    return null;
                }

            }

            string[] retStr = buffer.Split(',');
            return retStr;

        }
        //To close the Accept Blocker
        public void Stop()
        {
            listener.Stop();
        }

    }
}
