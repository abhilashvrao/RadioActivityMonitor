using RadioActivityMonitor.Interfaces;

namespace RadioActivityMonitor.Classes
{
    public class Alarm(ISensor? sensor = null) : IAlarm
    {
        private readonly ISensor _sensor = sensor ?? new Sensor();
        const double _lowThreshold = 17;
        const double _highThreshold = 21;
        bool _isAlarmOn = false;
        long _alarmTriggerCount;

        public void Check()
        {
            double value = _sensor.NextMeasure();

            Console.WriteLine($"Sensor value is : {value}");

            if (value < _lowThreshold || _highThreshold  < value)
            {
                _isAlarmOn = true;
                _alarmTriggerCount += 1;
            }
            else
            {
                _isAlarmOn = false;
            }
        }

        public bool IsAlarmOn => _isAlarmOn;

        public long AlarmTriggerCount => _alarmTriggerCount;
    }
}