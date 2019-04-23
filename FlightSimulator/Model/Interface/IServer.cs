using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    internal interface IServer
    {
        void Start();
        string[] Read();
    }
}
