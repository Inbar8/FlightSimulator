using FlightSimulator.ViewModels;
using System;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightBoardModel : BaseNotify
    {
        private Connect connection;

        public FlightBoardModel()
        {
            this.connection = new Connect();
        }

        private double lon;
        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }
        public double lat;
        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        //Connect function
        public void Connect(string ip, int port)
        {
            connection.ConnectToHost(ip, port);
            Reader();
        }

        //Reader function
        public void Reader()
        {
            new Task(delegate ()
            {
                while (connection.IsRunning)
                {
                    string[] param = connection.ReadData();
                    Lon = Convert.ToDouble(param[0]);
                    Lat = Convert.ToDouble(param[1]);
                }
            }).Start();
        }
    }
}
