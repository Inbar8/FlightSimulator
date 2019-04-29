using FlightSimulator.ViewModels;
using System.Threading;

namespace FlightSimulator.Model
{
    class ManualPilotModel : BaseNotify
    {
        public void SendCommands(string data)
        {
            if (Connect.Instance.IsConnected)
            {
                new Thread(delegate ()
                {
                    Commands.Instance.SendCommands(data);
                }).Start();
            }
        }
    }
}
