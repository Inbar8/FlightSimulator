using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Network
{
    class Connect
    {
        private TcpClient client;
        private BinaryWriter writer;
        public bool IsConnected { get; set; } = false;
        //the singelton implemented from AppSettingsModel
        #region Singleton
        private static Connect m_Instance = null;
        public static Connect Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Connect();
                }
                return m_Instance;
            }
        }
        #endregion
        //all the running client features
        #region Client
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
        public void Disconnect()
        {
            client.Close();
            m_Instance = null;
        }
        public void SendCommands(string data)
        {
            // Send data to server
            List<string> result = data.Split('\n').ToList();
            //sends command every 2 sec
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