namespace IoTSimulatedPnPDevice.MessageObjects.Telemetry
{
    internal class TelemetryMessageObject
    {
        internal double Temperature { get; private set; }
        internal double Humidity { get; private set; }
        internal TelemetryMessageObject(double temperature, double humidity)
        {
            Temperature = temperature;
            Humidity = humidity;
        }
    }
}
