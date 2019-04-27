using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System.Windows.Input;


namespace FlightSimulator.ViewModels
{
    class ManualViewModel:BaseNotify
    {
        private double aileron;
        private double throttle;
        private double elevator;
        private double rudder;
       //need another member to send the values to the client through it.

        public ManualViewModel()
        {
            //init that member. ^^
            this.aileron = 0;
            this.throttle = 0;
            this.elevator = 0;
            this.rudder = 0;
        }

        public double AileronValue
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                NotifyPropertyChanged("AileronValue");
               //send the info via the missing member
            }
        }

        public double ThrottleValue
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                NotifyPropertyChanged("ThrottleValue");
                //send the info via the missing member
            }
        }

        public double ElevatorValue
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                NotifyPropertyChanged("ElevatorValue");
                //send the info via the missing member
            }
        }

        public double RudderValue
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                NotifyPropertyChanged("RudderValue");
                //send the info via the missing member
            }
        }
    }
}
