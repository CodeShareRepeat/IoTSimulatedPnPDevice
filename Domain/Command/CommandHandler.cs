using System;
using System.Threading;
using System.Threading.Tasks;
using IoTSimulatedPnPDevice.Infra;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IoTSimulatedPnPDevice.Domain.Command
{

    internal class CommandHandler
    {

        private readonly DeviceClient _deviceClient;
        private readonly ILogger _logger;

        public CommandHandler(DeviceClient deviceClient, ILogger logger)
        {
            _deviceClient = deviceClient;
            _logger = logger;
        }

        internal async Task RegisterCommandsAsync(CancellationToken cancellationToken)
        {

            await _deviceClient.SetMethodHandlerAsync("start", HandleStartCommand, _deviceClient, cancellationToken);
            await _deviceClient.SetMethodHandlerAsync("stop", HandleStopCommand, _deviceClient, cancellationToken);
            await _deviceClient.SetMethodHandlerAsync("setintervall", HandleIntervallCommand, _deviceClient, cancellationToken);

            _logger.LogInformation("Command 'start' succsessfully registered");
        }

        protected Task<MethodResponse> HandleStartCommand(MethodRequest request, object userContext)
        {

            try
            {
                SimpleCache.Send = true;
                var delay = JsonConvert.DeserializeObject<string>(request.DataAsJson);
                _logger.LogDebug($"Command: Received - START TRANSMITION of telemetry data {delay}");

            }
            catch (JsonReaderException ex)
            {
                _logger.LogDebug($"Command input is invalid: {ex.Message}.");
                return Task.FromResult(new MethodResponse((int)404));
            }

            return Task.FromResult(new MethodResponse((int)200));
        }

        protected Task<MethodResponse> HandleStopCommand(MethodRequest request, object userContext)
        {

            try
            {
                SimpleCache.Send = false;
                _logger.LogDebug($"Command: Received - STOP TRANSMITION of telemetry data.");

            }
            catch (JsonReaderException ex)
            {
                _logger.LogDebug($"Command input is invalid: {ex.Message}.");
                return Task.FromResult(new MethodResponse((int)404));
            }

            return Task.FromResult(new MethodResponse((int)200));
        }

        protected Task<MethodResponse> HandleIntervallCommand(MethodRequest request, object userContext)
        {

            try
            {
                var intervall = JsonConvert.DeserializeObject<int>(request.DataAsJson);

                SimpleCache.IntervallSeconds = intervall;

                _logger.LogDebug($"Command: Received - SET INTERVALL TO {intervall} Seconds.");

            }
            catch (JsonReaderException ex)
            {
                _logger.LogDebug($"Command input is invalid: {ex.Message}.");
                return Task.FromResult(new MethodResponse((int)404));
            }

            return Task.FromResult(new MethodResponse((int)200));
        }



    }
}