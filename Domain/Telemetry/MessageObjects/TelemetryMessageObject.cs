namespace IoTSimulatedPnPDevice.Domain.Telemetry.MessageObjects
{
    public class TelemetryMessageObject
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
