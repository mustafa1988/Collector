using Collector.TollCalculator.Domain.Interfaces;

namespace Collector.TollCalculator.Domain;

public class Car : IVehicle
{
    public string GetVehicleType()
    {
        return "Car";
    }
}