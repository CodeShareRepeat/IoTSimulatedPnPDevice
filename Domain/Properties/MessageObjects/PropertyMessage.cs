using System;
using Microsoft.Azure.Devices.Shared;

namespace IoTSimulatedPnPDevice.Domain.Properties.MessageObjects
{
    internal class PropertyMessage
    {
        internal static TwinCollection Create()
        {
            TwinCollection properties = new();
            properties["Name"] = "Chris_Sensor1_ABCD";
            properties["SerialNumber"] = "123-456-789";
            return properties;
        }
    }

}
