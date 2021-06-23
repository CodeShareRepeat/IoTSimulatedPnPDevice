using System;
using System.Threading;
using System.Threading.Tasks;
using IoTSimulatedPnPDevice.Domain.Properties.SendData;
using IoTSimulatedPnPDevice.Domain.Telemetry.Sender;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;

namespace SimulatedDevice.Infra
{
    internal class ClientFlow
    {
        internal static async Task PerformClientActionsAsync(ILogger _logger, DeviceClient deviceClient, CancellationTokenSource cts)
        {
            MessageSender messageSender = new(deviceClient, _logger);
            PropertySender propertySender = new(deviceClient, _logger);

            await propertySender.SendProperties();
            await messageSender.SendTelemetryAsync(cts.Token);
            await deviceClient.CloseAsync();
        }
    }
}