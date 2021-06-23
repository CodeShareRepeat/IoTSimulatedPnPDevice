using System;
using System.Text;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace IoTSimulatedPnPDevice.MessageObjects.Telemetry
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
