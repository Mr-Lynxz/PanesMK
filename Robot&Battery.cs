using System;
using System.Collections.Generic;

// INTERFACE
interface IBattery
{
    int RemainingEnergy { get; }

    void Consume(int amount);
    void Recharge(int amount);
}

// LITHIUM BATTERY
class LithiumBattery : IBattery
{
    private int _remainingEnergy;

    public int RemainingEnergy
    {
        get { return _remainingEnergy; }
    }

    public LithiumBattery(int initialEnergy)
    {
        _remainingEnergy = Math.Clamp(initialEnergy, 0, 100);
    }

    public void Consume(int amount)
    {
        if (amount < 0)
            return;

        _remainingEnergy = Math.Max(0, _remainingEnergy - amount);
    }

    public void Recharge(int amount)
    {
        if (amount < 0)
            return;

        _remainingEnergy = Math.Min(100, _remainingEnergy + amount);
    }
}

// SOLAR BATTERY
class SolarBattery : IBattery
{
    private int _remainingEnergy;

    public int RemainingEnergy
    {
        get { return _remainingEnergy; }
    }

    public SolarBattery(int initialEnergy)
    {
        _remainingEnergy = Math.Clamp(initialEnergy, 0, 100);
    }

    public void Consume(int amount)
    {
        if (amount < 0)
            return;

        _remainingEnergy = Math.Max(0, _remainingEnergy - amount);
    }

    public void Recharge(int amount)
    {
        if (amount < 0)
            return;

        _remainingEnergy = Math.Min(100, _remainingEnergy + amount);
    }
}

// ABSTRACT CLASS
abstract class Robot
{
    private readonly IBattery _battery;

    public string Name { get; set; }

    public int RemainingEnergy
    {
        get { return _battery.RemainingEnergy; }
    }

    public Robot(string name, IBattery battery)
    {
        Name = name;
        _battery = battery;
    }

    public void Recharge(int amount)
    {
        _battery.Recharge(amount);

        Console.WriteLine(
            $"{Name} recharged. Energy: {RemainingEnergy}%"
        );
    }

    protected void UseEnergy(int amount)
    {
        _battery.Consume(amount);

        Console.WriteLine(
            $"{Name} used {amount}% energy. Remaining: {RemainingEnergy}%"
        );
    }

    public abstract void PerformTask();
}

// CLEANING ROBOT
class CleaningRobot : Robot
{
    public CleaningRobot(string name, IBattery battery)
        : base(name, battery)
    {
    }

    public override void PerformTask()
    {
        Console.WriteLine($"\n{Name} is cleaning...");
        UseEnergy(10);
    }
}

// DELIVERY ROBOT
class DeliveryRobot : Robot
{
    public DeliveryRobot(string name, IBattery battery)
        : base(name, battery)
    {
    }

    public override void PerformTask()
    {
        Console.WriteLine($"\n{Name} is delivering a package...");
        UseEnergy(25);
    }
}

// MAIN PROGRAM
class Program 
{
    static void Main()
    {
        // Create robots with different battery types
        CleaningRobot cleaner = new CleaningRobot(
            "Cleaning Robot",
            new LithiumBattery(80)
        );

        DeliveryRobot delivery = new DeliveryRobot(
            "Delivery Robot",
            new SolarBattery(60)
        );

        // Demonstrate PerformTask()
        cleaner.PerformTask();
        delivery.PerformTask();

        // Demonstrate Recharge()
        cleaner.Recharge(20);
        delivery.Recharge(30);

        // Demonstrate polymorphism
        List<Robot> robots = new List<Robot>
        {
            cleaner,
            delivery
        };

        Console.WriteLine("\n=== POLYMORPHISM DEMONSTRATION ===");

        foreach (Robot robot in robots)
        {
            robot.PerformTask();
        }

        Console.WriteLine("\n=== FINAL ENERGY LEVELS ===");

        foreach (Robot robot in robots)
        {
            Console.WriteLine(
                $"{robot.Name}: {robot.RemainingEnergy}%"
            );
        }
    }
}
