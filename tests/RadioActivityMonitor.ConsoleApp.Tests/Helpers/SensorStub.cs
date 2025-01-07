using RadioActivityMonitor.Interfaces;

namespace RadioActivityMonitor.Tests.Helpers
{
    public class SensorStub(IEnumerable<double> values) : ISensor
    {
        private readonly Queue<double> _values = new(values);

        public double NextMeasure()
        {
            return _values.Count > 0 ? _values.Dequeue() : 0;
        }
    }
}