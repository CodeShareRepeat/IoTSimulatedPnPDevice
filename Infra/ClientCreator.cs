using System;
using System.Threading;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;

namespace SimulatedDevice.Infra
{
    internal class ClientCreator
    {

        public const string deviceConnectionString = "HostName=iotc-dc3468c2-6d71-4cd6-9099-c3734e5cbf2a.azure-devices.net;DeviceId=1ls7qbmgeyl;SharedAccessKey=T9Kt72fYv0B8jXcFZTc3ABRUEVFf0onr2U4YvKZYimg=";

        internal static DeviceClient SetupDeviceClient(ILogger _logger)
        {
            var options = new ClientOptions
            {
                ModelId = "dtmi:devIotCentral:MightySensorDevice13x7;2",
            };

            var deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString, TransportType.Mqtt, options);

            deviceClient.SetConnectionStatusChangesHandler((status, reason) =>
            {
                _logger.LogDebug($"Connection status change registered - status={status}, reason={reason}.");
            });

            return deviceClient;
        }
    }
}
