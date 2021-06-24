using System;
using System.Threading;
using System.Threading.Tasks;
using IoTSimulatedPnPDevice.Domain.Command;
using IoTSimulatedPnPDevice.Domain.Properties.SendData;
using IoTSimulatedPnPDevice.Domain.Telemetry.Sender;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;

namespace SimulatedDevice.Infra
{
    internal class ClientFlow
    {
        internal static async Task PerformClientActionsAsync(ILogger _logger, DeviceClient deviceClient, CancellationToken ctx)
        {
            MessageSender messageSender = new(deviceClient, _logger);
            PropertySender propertySender = new(deviceClient, _logger);
            CommandHandler commandHandler = new(deviceClient, _logger);

            await commandHandler.RegisterCommandsAsync(ctx);
            await propertySender.SendProperties();
            await messageSender.SendTelemetryAsync(ctx);

        }
    }
}