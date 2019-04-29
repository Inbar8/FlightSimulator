using System;
using FlightSimulator.Model;


namespace FlightSimulator.ViewModels
{
    class ManualPilotViewModel:BaseNotify
    {
        // all the paths were the simulator properties are saved
        private readonly string aileronPath = " /controls/flight/aileron ";
        private readonly string throttlePath = " /controls/engines/current-engine/throttle ";
        private readonly string elevatorPath = " /controls/flight/elevator ";
        private readonly string rudderPath = " /controls/flight/rudder ";
        private ManualPilotModel model = new ManualPilotModel();

        // Sets all the simulator properties to the sampled values in the manual pilot
        public double AileronValue {
            set {
                model.SendCommands("set" + aileronPath + Convert.ToString(value));
            }
        }

        public double ThrottleValue {
            set {
                model.SendCommands("set" + throttlePath + Convert.ToString(value));
            }
        }

        public double ElevatorValue {
            set {
                model.SendCommands("set" + elevatorPath + Convert.ToString(value));
            }
        }

        public double RudderValue {
            set {
                model.SendCommands("set" + rudderPath + Convert.ToString(value));
            }
        }
    }
}
