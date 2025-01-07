using RadioActivityMonitor.Classes;
using RadioActivityMonitor.Interfaces;
using RadioActivityMonitor.Tests.Helpers;

namespace RadioActivityMonitor.Tests;

[TestClass]
public class AlarmTests
{
    [TestMethod]
    public void Test_ValueBelowLowThreshold_AlarmIsOn()
    {
        // Arrange
        ISensor sensorStub = new SensorStub(new List<double> { 15 });
        IAlarm alarm = new Alarm(sensorStub);

        // Act
        alarm.Check();

        // Assert
        Assert.IsTrue(alarm.IsAlarmOn);
        Assert.AreEqual(1, alarm.AlarmTriggerCount);
    }

    [TestMethod]
    public void Test_ValueAboveHighThreshold_AlarmIsOn()
    {
        // Arrange
        ISensor sensorStub = new SensorStub(new List<double> { 22 });
        IAlarm alarm = new Alarm(sensorStub);

        // Act
        alarm.Check();

        // Assert
        Assert.IsTrue(alarm.IsAlarmOn);
        Assert.AreEqual(1, alarm.AlarmTriggerCount);
    }

    [TestMethod]
    public void Test_ValueWithinThreshold_AlarmIsOff()
    {
        // Arrange
        ISensor sensorStub = new SensorStub(new List<double> { 19 });
        IAlarm alarm = new Alarm(sensorStub);

        // Act
        alarm.Check();

        // Assert
        Assert.IsFalse(alarm.IsAlarmOn);
        Assert.AreEqual(0, alarm.AlarmTriggerCount);
    }

    [TestMethod]
    public void Test_MultipleTriggers_LowAndHighThreshold_AlarmIsOn()
    {
        // Arrange
        ISensor sensor = new SensorStub(new List<double> { 15, 22 }); 
        IAlarm alarm = new Alarm(sensor);

        // Act
        alarm.Check();
        alarm.Check();

        // Assert
        Assert.IsTrue(alarm.IsAlarmOn);
        Assert.AreEqual(2, alarm.AlarmTriggerCount);
    }

    [TestMethod]
    public void Test_MultipleTriggers_WithinThreshold_AlarmIsOff()
    {
        // Arrange
        ISensor sensor = new SensorStub(new List<double> { 18, 20 }); 
        IAlarm alarm = new Alarm(sensor);

        // Act
        alarm.Check();
        alarm.Check();

        // Assert
        Assert.IsFalse(alarm.IsAlarmOn);
        Assert.AreEqual(0, alarm.AlarmTriggerCount);
    }

    [TestMethod]
    public void Test_MultipleTriggers_OneWithinThreshold_OneBelowThreshold_AlarmIsOn()
    {
        // Arrange
        ISensor sensor = new SensorStub(new List<double> { 18, 10 }); 
        IAlarm alarm = new Alarm(sensor);

        // Act
        alarm.Check();
        alarm.Check();

        // Assert
        Assert.IsTrue(alarm.IsAlarmOn);
        Assert.AreEqual(1, alarm.AlarmTriggerCount);
    }

    [TestMethod]
    public void Test_MultipleTriggers_OneBelowThreshold_OneWithinThreshold_AlarmIsOff()
    {
        // Arrange
        ISensor sensor = new SensorStub(new List<double> { 10, 18 }); 
        IAlarm alarm = new Alarm(sensor);

        // Act
        alarm.Check();
        alarm.Check();

        // Assert
        Assert.IsFalse(alarm.IsAlarmOn);
        Assert.AreEqual(1, alarm.AlarmTriggerCount);
    }

    [TestMethod]
    public void Test_MultipleTriggers_OneWithinThreshold_OneAboveThreshold_AlarmIsOn()
    {
        // Arrange
        ISensor sensor = new SensorStub(new List<double> { 18, 23 }); 
        IAlarm alarm = new Alarm(sensor);

        // Act
        alarm.Check();
        alarm.Check();

        // Assert
        Assert.IsTrue(alarm.IsAlarmOn);
        Assert.AreEqual(1, alarm.AlarmTriggerCount);
    }

    [TestMethod]
    public void Test_MultipleTriggers_OneAboveThreshold_OneWithinThreshold_AlarmIsOff()
    {
        // Arrange
        ISensor sensor = new SensorStub(new List<double> { 23, 18 }); 
        IAlarm alarm = new Alarm(sensor);

        // Act
        alarm.Check();
        alarm.Check();

        // Assert
        Assert.IsFalse(alarm.IsAlarmOn);
        Assert.AreEqual(1, alarm.AlarmTriggerCount);
    }
}