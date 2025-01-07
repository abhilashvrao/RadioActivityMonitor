namespace RadioActivityMonitor.Interfaces
{
    public interface IAlarm
    {
        void Check();
        bool IsAlarmOn { get; }
        long AlarmTriggerCount { get; }
    }
}