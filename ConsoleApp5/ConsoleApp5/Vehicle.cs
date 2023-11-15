using System;
using System.Collections.Generic;

public abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}

public class Human
{
    public int Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is moving...");
    }
}

public class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Car is moving...");
    }
}

public class Bus : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Bus is moving...");
    }
}

public class Train : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Train is moving...");
    }
}


public class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
}


public class TransportNetwork
{
    private List<Vehicle> vehicles;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void MoveAllVehicles()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }

    public void CalculateOptimalRoute(Route route, Vehicle vehicle)
    {
        
        Console.WriteLine($"Optimal route for {vehicle.GetType().Name} from {route.StartPoint} to {route.EndPoint} calculated.");
    }

    public void PassengerBoardingAndDisembarkation(Vehicle vehicle)
    {
        
        Console.WriteLine($"Passengers are boarding and disembarking from {vehicle.GetType().Name}...");
    }
}


class Program
{
    static void Main(string[] args)
    {
        TransportNetwork transportNetwork = new TransportNetwork();

        Car car = new Car();
        car.Speed = 120;
        car.Capacity = 4;

        Bus bus = new Bus();
        bus.Speed = 80;
        bus.Capacity = 40;

        Train train = new Train();
        train.Speed = 200;
        train.Capacity = 300;

        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        transportNetwork.MoveAllVehicles();

        Route route = new Route { StartPoint = "A", EndPoint = "B" };
        transportNetwork.CalculateOptimalRoute(route, car);
        transportNetwork.CalculateOptimalRoute(route, bus);
        transportNetwork.CalculateOptimalRoute(route, train);

        transportNetwork.PassengerBoardingAndDisembarkation(bus);
    }
}

