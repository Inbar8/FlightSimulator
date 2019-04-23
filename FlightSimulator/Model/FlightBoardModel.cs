using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightBoardModel : BaseNotify
    {

        private static FlightBoardModel instance = null;
        private IServer server;
        private IClient client;
        private FlightBoardModel() { }

        public string[] Values { get; private set; }
        public static FlightBoardModel getInstance()
        {
            if (instance == null)
            {
                instance = new FlightBoardModel();
            }
            return instance;
        }
        private double lon = 0;
        public double Lon
        {
            get
            {
                return lon;
            }
            private set
            {
                lon = value;

                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;


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

        public void Connect()
        {
            ISettingsModel model = ApplicationSettingsModel.Instance;
            server = new Server(model.FlightInfoPort);
            //wait till the server is connected
            server.Start();
            Thread thread = new Thread(() =>
            {
                //Read value from the simulator and update lon and lat 
                while (true)
                {
                    Values = server.Read();

                    Lon = Convert.ToDouble(Values[0]);
                    Lat = Convert.ToDouble(Values[1]);
                }
            });
            thread.Start();

            client = Client.getInstance();
           // client.Connect(model.FlightServerIP, model.FlightCommandPort);
        }
    }
}
