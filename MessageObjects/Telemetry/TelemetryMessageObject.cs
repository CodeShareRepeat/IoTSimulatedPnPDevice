
namespace SimulatedDevice.MessageObjects
{

    /// <summary>
    /// Message class for the divice to the IoT hub
    /// </summary>
    internal class TelemetryMessageObject
    {
        public double Temperature { get; private set; }
        public double Humidity { get; private set; }

        public TelemetryMessageObject(double temperature, double humidity)
        {
            Temperature = temperature;
            Humidity = humidity;
        }
    }
}
