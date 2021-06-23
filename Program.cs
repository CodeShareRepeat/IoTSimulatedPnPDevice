

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;
using SimulatedDevice.Infra;

namespace SimulatedDevice
{
    internal class Program
    {

        private static ILogger _logger;

        public static async Task Main(string[] args)
        {
            _logger = InitializeConsoleDebugLogger();
            _logger.LogInformation("Press Control+C to quit the sample.");

            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));

            SetCancelationAction(cts);

            _logger.LogDebug($"Set up the device client.");

            using DeviceClient deviceClient = ClientCreator.SetupDeviceClient(_logger);

            _logger.LogInformation($"Start Client Actions.");

            await ClientFlow.PerformClientActionsAsync(_logger, deviceClient, cts);

            _logger.LogInformation("Thank you and goodbye!");

        }

        private static void SetCancelationAction(CancellationTokenSource cts)
        {
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true;
                cts.Cancel();
                _logger.LogInformation("Sample execution cancellation requested; will exit.");
            };
        }

        private static ILogger InitializeConsoleDebugLogger()
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                .AddFilter(level => level >= LogLevel.Debug)
                .AddConsole();
            });

            return loggerFactory.CreateLogger<Program>();
        }




    }
}
