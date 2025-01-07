using RadioActivityMonitor.Classes;
using RadioActivityMonitor.Interfaces;

ISensor sensor = new Sensor();
IAlarm alarm = new Alarm(sensor);

Console.WriteLine("Monitoring started. Press Ctrl+C to exit.\n");

while (true)
{
    alarm.Check();

    Console.WriteLine($"Alarm On: {alarm.IsAlarmOn}");
    Console.WriteLine($"Alarm Trigger Count: {alarm.AlarmTriggerCount}");
    Console.WriteLine("----------------------------");

    Thread.Sleep(3000);
}