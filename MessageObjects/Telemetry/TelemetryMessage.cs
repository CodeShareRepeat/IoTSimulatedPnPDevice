using System;
using System.Text;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SimulatedDevice.MessageObjects;

namespace SimulatedDevice.Infra
{
    internal class TelemetryMessage
    {
        internal static Message Create(double temp, double hum)
        {
            TelemetryMessageObject messageObject = new(temp, hum);

            var jsonMessage = JsonConvert.SerializeObject(messageObject);

            var iotMessage = new Message(Encoding.ASCII.GetBytes(jsonMessage));

            return iotMessage;
        }
    }
}
