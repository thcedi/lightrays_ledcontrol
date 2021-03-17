using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightRays
{
    public class SerialHelper
    {
        SerialPort _serialPort;
        public SerialHelper(string portName)
        {
            _serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
            _serialPort.Handshake = Handshake.None;   
        }

        public void Write(string effect)
        {
            if (!(_serialPort.IsOpen))
                _serialPort.Open();

            _serialPort.Write(effect);
        }
    }
}
