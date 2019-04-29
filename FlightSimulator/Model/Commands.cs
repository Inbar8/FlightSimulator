using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;

// Here is a part of the Network between the application and the simulator
namespace FlightSimulator.Model
{
    class Commands
    {
        // members of Commands Class
        private TcpClient client;
        private BinaryWriter writer;
        public bool IsConnected { get; set; } = false;

        // This part was taken from your ApplicationSettingsModel 
        #region Singleton
        private static Commands m_Instance = null;
        public static Commands Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Commands();
                }
                return m_Instance;
            }
        }
        #endregion

        // Client Part - ConnectToHost, Disconnect and SendCommands functions
        #region Client
        //ConnectToHost function according to the ip and port given
        public void ConnectToHost(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            this.client = new TcpClient();
            while (!IsConnected)
            {
                try
                {
                    client.Connect(ep);
                }
                catch (Exception) { }
            }
            IsConnected = true;
            writer = new BinaryWriter(client.GetStream());
        }

        //Disconnect function
        public void Disconnect()
        {
            client.Close();
            m_Instance = null;
        }

        //SendCommands function according to the given data
        public void SendCommands(string data)
        {
            if (data == "")
            {
                return;
            }
            List<string> result = data.Split('\n').ToList();
            foreach (var x in result)
            {
                string tmp = x + "\r\n";
                writer.Write(System.Text.Encoding.ASCII.GetBytes(tmp));
                System.Threading.Thread.Sleep(2000);
            }
        }
        #endregion
    }
}