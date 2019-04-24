using FlightSimulator.Model.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class AutoPilotModel
    {
        public void SendCommands(string data)
        {
            if (Connect.Instance.IsConnected)
            {
                new Thread(delegate ()
                {
                    Connect.Instance.SendCommands(data);
                }).Start();
            }
        }
    }
}
