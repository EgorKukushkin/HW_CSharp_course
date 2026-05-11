using System;

public enum CarType
{
    Tesla,
    Mercedes,
    Lada,
    BMW,
    Toyota
}

public interface ICar
{
    string GetDescription();
}

public interface IElectric
{
    string GetBatteryDescription();
}

public interface IGas
{
    string GetFuelDescription();
}

public interface IMechanical
{
    string GetTransmissionDescription();
}

public interface IAutomatical
{
    string GetTransmissionDescription();
}

public abstract class ACar : ICar
{
    public string Brand { get; protected set; }
    public int SeatsCount { get; protected set; }
    public string OperatingSystem { get; protected set; }

    protected ACar(string brand, int seatsCount, string operatingSystem)
    {
        Brand = brand;
        SeatsCount = seatsCount;
        OperatingSystem = operatingSystem;
    }

    public virtual string GetBrandDescription()
    {
        return Brand;
    }

    public virtual string GetSeatsDescription()
    {
        return $"{SeatsCount}";
    }

    public virtual string GetOperatingSystemDescription()
    {
        return $"{OperatingSystem}";
    }

    public abstract string GetEngineDescription();

    public abstract string GetTransmissionDescription();

    public virtual string GetDescription()
    {
        return $"{GetBrandDescription()}: {GetEngineDescription()}, {GetTransmissionDescription()}, {GetSeatsDescription()} мест, {GetOperatingSystemDescription()} на борту";
    }
}

public abstract class AutomaticElectricCar : ACar, IElectric, IAutomatical
{
    protected AutomaticElectricCar(string brand, int seatsCount, string operatingSystem)
        : base(brand, seatsCount, operatingSystem)
    {
    }

    public string GetBatteryDescription()
    {
        return "electrical car";
    }

    public override string GetEngineDescription()
    {
        return GetBatteryDescription();
    }

    public override string GetTransmissionDescription()
    {
        return "автоматическая коробка передач";
    }
}

public abstract class AutomaticGasCar : ACar, IGas, IAutomatical
{
    protected AutomaticGasCar(string brand, int seatsCount, string operatingSystem)
        : base(brand, seatsCount, operatingSystem)
    {
    }

    public string GetFuelDescription()
    {
        return "gas car";
    }

    public override string GetEngineDescription()
    {
        return GetFuelDescription();
    }

    public override string GetTransmissionDescription()
    {
        return "автоматическая коробка передач";
    }
}

public abstract class MechanicalGasCar : ACar, IGas, IMechanical
{
    protected MechanicalGasCar(string brand, int seatsCount, string operatingSystem)
        : base(brand, seatsCount, operatingSystem)
    {
    }

    public string GetFuelDescription()
    {
        return "gas car";
    }

    public override string GetEngineDescription()
    {
        return GetFuelDescription();
    }

    public override string GetTransmissionDescription()
    {
        return "механическая коробка передач";
    }
}

public class Tesla : AutomaticElectricCar
{
    public Tesla()
        : base("Tesla", 5, "Android")
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", запас хода 600 км";
    }
}

public class Mercedes : AutomaticGasCar
{
    public Mercedes()
        : base("Mercedes", 5, "Mercedes-Benz User Experience")
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", премиальный салон";
    }
}

public class Lada : MechanicalGasCar
{
    public Lada()
        : base("Lada", 5, "без мультимедийной системы")
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", бюджетный автомобиль";
    }
}

public class BMW : AutomaticGasCar
{
    public BMW()
        : base("BMW", 5, "BMW iDrive")
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", спортивный характер";
    }
}

public class Toyota : AutomaticGasCar
{
    public Toyota()
        : base("Toyota", 5, "Toyota Multimedia")
    {
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", высокая надежность";
    }
}

public static class CarFactory
{
    public static ICar CreateCar(CarType carType)
    {
        switch (carType)
        {
            case CarType.Tesla:
                return new Tesla();

            case CarType.Mercedes:
                return new Mercedes();

            case CarType.Lada:
                return new Lada();

            case CarType.BMW:
                return new BMW();

            case CarType.Toyota:
                return new Toyota();

            default:
                throw new ArgumentException("Неизвестная марка");
        }
    }
}

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Введите марку автомобиля или done для остановки ввода: ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Пустой ввод");
                continue;
            }
            if (input.ToLower() == "done")
            {
                break;
            }
            
            bool isParsed = Enum.TryParse(input, true, out CarType carType);
            if (!isParsed)
            {
                Console.WriteLine("Такой марки нет в базе");
                Console.WriteLine("Доступные марки: Tesla, Mercedes, Lada, BMW, Toyota");
                continue;
            }

            ICar car = CarFactory.CreateCar(carType);

            Console.WriteLine(car.GetDescription());
            Console.WriteLine();
        }

        Console.WriteLine("Программа завершена.");
    }
}