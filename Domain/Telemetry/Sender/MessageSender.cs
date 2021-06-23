using System;
using System.Threading;
using System.Threading.Tasks;
using IoTSimulatedPnPDevice.Domain.Telemetry.MessageObjects;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;


namespace IoTSimulatedPnPDevice.Domain.Telemetry.Sender
{
    public class MessageSender
    {
        private static readonly Random _random = new();
        private readonly ILogger _logger;
        private readonly DeviceClient _deviceClient;
        public MessageSender(DeviceClient deviceClient, ILogger logger)
        {
            _deviceClient = deviceClient;
            _logger = logger;
        }
        public async Task SendTelemetryAsync(CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                var randomTemperature = Math.Round(_random.NextDouble() * 40.0 + 5.0, 1);
                var randomHumidity = Math.Round(_random.NextDouble() * 70.0, 1);

                await SendDeviceTelemetryAsync(randomTemperature, randomHumidity, cancellationToken);

                await Task.Delay(5 * 1000, cancellationToken);
            }
        }

        private async Task SendDeviceTelemetryAsync(double temperature, double humidity, CancellationToken cancellationToken)
        {
            using Message msg = TelemetryMessage.Create(temperature, humidity);

            await _deviceClient.SendEventAsync(msg, cancellationToken);

            _logger.LogInformation($"Send temp: {temperature} Celcius & humidity: {humidity} % at {DateTime.Now}");
        }
    }
}
