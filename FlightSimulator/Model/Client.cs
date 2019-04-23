using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace FlightSimulator.Model
{
    class Client : IClient
    {
        private TcpClient tcpClient;
        private static Client instance = null;
        private NetworkStream stream;
        private BinaryWriter writer;
        private Client() { }



        public static Client getInstance()
        {

            if (instance == null)
            {
                instance = new Client();
            }
            return instance;
        }

        public void Connect(string ip, int port)
        {

            tcpClient = new TcpClient();


            try
            {
                Console.WriteLine("trying to connect..");
                tcpClient.Connect(ip, port);

            }
            catch (SocketException e)
            {


            }

            Console.WriteLine("new Connection");
            stream = tcpClient.GetStream();
            writer = new BinaryWriter(stream);


        }

        public void Disconnect()
        {
            tcpClient.Dispose();
        }

        public void Write(string command)
        {
            // Console.Write("Starting TO write...");
            string[] lines = command.Split('\n');

            Byte[] buffer = new byte[1024];
            for (int i = 0; i < lines.Length; i++)
            {
                buffer = Encoding.ASCII.GetBytes(lines[i]);
                if (lines[i].EndsWith("\n"))
                {
                    lines[i].Remove(lines[i].Length - 1);
                }
                string send = lines[i] + "\r\n";
                // Console.WriteLine("Sends: " + send);
                //send the message to the server
                if (tcpClient != null && tcpClient.Connected)
                {
                    writer.Write(System.Text.Encoding.ASCII.GetBytes(send));


                    //check the pilot response
                    // Byte[] data = new Byte[256];

                    // String to store the response ASCII representation.
                    //   String responseData = String.Empty;

                    // Read the first batch of the TcpServer response bytes.
                    //  Int32 bytes = stream.Read(data, 0, data.Length);
                    // responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    //  Console.WriteLine("Received: {0}", responseData);
                }
            }
            Array.Clear(lines, 0, lines.Length);
        }
    }
}
