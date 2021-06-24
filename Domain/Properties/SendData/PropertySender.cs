using System.Threading.Tasks;
using IoTSimulatedPnPDevice.Domain.Properties.MessageObjects;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;

namespace IoTSimulatedPnPDevice.Domain.Properties.SendData
{
    public class PropertySender
    {
        private readonly ILogger _logger;
        private readonly DeviceClient _deviceClient;

        public PropertySender(DeviceClient deviceClient, ILogger logger)
        {
            _deviceClient = deviceClient;
            _logger = logger;
        }

        public async Task SendProperties()
        {
            var propertyMessage = PropertyMessage.Create();

            await _deviceClient.UpdateReportedPropertiesAsync(propertyMessage);

            _logger.LogInformation("Initital Properties sent.");

        }
    }
}
