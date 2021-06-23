using System;
using Microsoft.Azure.Devices.Shared;

namespace IoTSimulatedPnPDevice.MessageObjects.Properties
{
    internal class PropertyMessage
    {
        internal static TwinCollection Create()
        {
            TwinCollection properties = new();
            properties["Name"] = "Chris_Sensor1_ABCD";
            return properties;
        }
    }

}