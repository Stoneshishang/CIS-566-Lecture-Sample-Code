using System;
using System.Collections;

namespace BuilderPatternExercise
{
    class Program
    {
        // Director: "Shop"
        class Shop
        {
            // VehicleBuilder uses a complex series of steps
            public void Construct(VehicleBuilder VehicleBuilder)
            {
                VehicleBuilder.BuildDoors();
                VehicleBuilder.BuildSeat();
                VehicleBuilder.BuildWheel();
            }
        }

        // Builder: "VehicleBuilder"
        abstract class VehicleBuilder
        {
            public abstract void BuildDoors();
            public abstract void BuildSeat();
            public abstract void BuildWheel();
            public abstract Vehicle GetResult();
        }

        // Product: "Vehicle"
        class Vehicle
        {
            ArrayList parts = new ArrayList();
            public void Add(string part)
            {
                parts.Add(part);
            }
            public void Show()
            {
                foreach (string part in parts)
                    Console.WriteLine(part);
            }
        }

        // "MiniVan"
        class MiniVan : VehicleBuilder
        {
            private Vehicle Vehicle = new Vehicle();
            public override void BuildDoors()
            {
                Vehicle.Add("Doors: 4 Doors");
            }
            public override void BuildSeat()
            {
                Vehicle.Add("Seat: 7 Seats");
            }
            public override void BuildWheel()
            {
                Vehicle.Add("Wheel: 4 Wheels");
            }
            public override Vehicle GetResult()
            {
                return Vehicle;
            }
        }

        // "SportsCar"
        class SportsCar : VehicleBuilder
        {
            private Vehicle Vehicle = new Vehicle();
            public override void BuildDoors()
            {
                Vehicle.Add("Doors: 2 Doors");
            }
            public override void BuildSeat()
            {
                Vehicle.Add("Seat: 4 Seats");
            }
            public override void BuildWheel()
            {
                Vehicle.Add("Wheel: 4 Wheels");
            }
            public override Vehicle GetResult()
            {
                return Vehicle;
            }
        }

        // "Motocycle"
        class Motocycle : VehicleBuilder
        {
            private Vehicle Vehicle = new Vehicle();
            public override void BuildDoors()
            {
                Vehicle.Add("Doors: 0 Doors");
            }
            public override void BuildSeat()
            {
                Vehicle.Add("Seat: 2 Seats");
            }
            public override void BuildWheel()
            {
                Vehicle.Add("Wheel: 2 Wheels");
            }
            public override Vehicle GetResult()
            {
                return Vehicle;
            }
        }
        public static void Main()
        {
            // Create Shop and VehicleBuilders
            Shop Shop = new Shop();
            VehicleBuilder bMiniVan = new MiniVan();
            VehicleBuilder bSportsCar = new SportsCar();
            VehicleBuilder bMotocycle = new Motocycle();
            // Construct three Vehicles
            Shop.Construct(bMiniVan);
            Vehicle pMiniVan = bMiniVan.GetResult();
            Console.WriteLine("\nMiniVan -------");
            pMiniVan.Show();
            Shop.Construct(bSportsCar);
            Vehicle pSportsCar = bSportsCar.GetResult();
            Console.WriteLine("\nSportsCar -------");
            pSportsCar.Show();
            Shop.Construct(bMotocycle);
            Vehicle pMotocycle = bMotocycle.GetResult();
            Console.WriteLine("\nMotocycle -------");
            pMotocycle.Show();
            // Wait for user
            Console.Read();
        }
    }
}
