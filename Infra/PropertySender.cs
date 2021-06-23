using System.Threading.Tasks;
using IoTSimulatedPnPDevice.MessageObjects.Properties;
using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Logging;
namespace SimulatedDevice.Infra
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

        public async Task SendPropertiesAsync()
        {
            var propertyMessage = PropertyMessage.Create();

            await _deviceClient.UpdateReportedPropertiesAsync(propertyMessage);
        }
    }
}
